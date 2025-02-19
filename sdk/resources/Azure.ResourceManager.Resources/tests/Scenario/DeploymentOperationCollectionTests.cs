﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentOperationCollectionTests : ResourcesTestBase
    {
        public DeploymentOperationCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deployName, deploymentData)).Value;
            int count = 0;
            await foreach (var tempDeploymentOperation in deployment.GetDeploymentOperationsAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2); //One deployment contains two operations: Create and EvaluteDeploymentOutput
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deployName, deploymentData)).Value;
            await foreach (var tempDeploymentOperation in deployment.GetDeploymentOperationsAsync())
            {
                DeploymentOperation getDeploymentOperation = await deployment.GetDeploymentOperationAsync(tempDeploymentOperation.OperationId);
                AssertValidDeploymentOperation(tempDeploymentOperation, getDeploymentOperation);
            }
        }

        private static void AssertValidDeploymentOperation(DeploymentOperation model, DeploymentOperation getResult)
        {
            Assert.AreEqual(model.Id, getResult.Id);
            Assert.AreEqual(model.OperationId, getResult.OperationId);
            if (model.Properties != null || getResult.Properties != null)
            {
                Assert.NotNull(model.Properties);
                Assert.NotNull(getResult.Properties);
                Assert.AreEqual(model.Properties.ProvisioningState, getResult.Properties.ProvisioningState);
                Assert.AreEqual(model.Properties.ProvisioningOperation, getResult.Properties.ProvisioningOperation);
                Assert.AreEqual(model.Properties.Timestamp, getResult.Properties.Timestamp);
                Assert.AreEqual(model.Properties.Duration, getResult.Properties.Duration);
                Assert.AreEqual(model.Properties.ServiceRequestId, getResult.Properties.ServiceRequestId);
                Assert.AreEqual(model.Properties.StatusCode, getResult.Properties.StatusCode);
                //Assert.AreEqual(model.Data.Properties.StatusMessage, getResult.Data.Properties.StatusMessage);
                if (model.Properties.TargetResource != null || getResult.Properties.TargetResource != null)
                {
                    Assert.NotNull(model.Properties.TargetResource);
                    Assert.NotNull(getResult.Properties.TargetResource);
                    Assert.AreEqual(model.Properties.TargetResource.Id, getResult.Properties.TargetResource.Id);
                    Assert.AreEqual(model.Properties.TargetResource.ResourceName, getResult.Properties.TargetResource.ResourceName);
                    Assert.AreEqual(model.Properties.TargetResource.ResourceType, getResult.Properties.TargetResource.ResourceType);
                }
                if (model.Properties.Request != null || getResult.Properties.Request != null)
                {
                    Assert.NotNull(model.Properties.Request);
                    Assert.NotNull(getResult.Properties.Request);
                    Assert.AreEqual(model.Properties.Request.Content, getResult.Properties.Request.Content);
                }
                if (model.Properties.Response != null || getResult.Properties.Response != null)
                {
                    Assert.NotNull(model.Properties.Response);
                    Assert.NotNull(getResult.Properties.Response);
                    Assert.AreEqual(model.Properties.Response.Content, getResult.Properties.Response.Content);
                }
            }
        }
    }
}
