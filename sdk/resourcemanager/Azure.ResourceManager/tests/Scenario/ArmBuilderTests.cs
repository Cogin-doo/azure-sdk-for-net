﻿using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ArmBuilderTests : ResourceManagerTestBase
    {
        public ArmBuilderTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase(null)]
        [TestCase("  ")]
        [RecordedTest]
        public void TestCreateOrUpdate(string value)
        {
            Assert.ThrowsAsync<ArgumentException>(async delegate 
            {
                Subscription subscription = await Client.GetDefaultSubscriptionAsync();
                ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
                ResourceGroupBuilder rgBuilder = rgCollection.Construct(Location.WestUS2);
                await rgBuilder.CreateOrUpdateAsync(value);
            });
        }

        [TestCase(null)]
        [TestCase("    ")]
        [RecordedTest]
        public void TestStartCreateOrUpdate(string value)
        {
            Assert.ThrowsAsync<ArgumentException>(async delegate { await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(value, false); });
        }
    }
}
