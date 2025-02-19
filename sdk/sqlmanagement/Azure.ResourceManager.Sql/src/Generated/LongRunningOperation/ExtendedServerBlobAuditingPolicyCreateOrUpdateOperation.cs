// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Sql;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> Creates or updates an extended server&apos;s blob auditing policy. </summary>
    public partial class ExtendedServerBlobAuditingPolicyCreateOrUpdateOperation : Operation<ExtendedServerBlobAuditingPolicy>, IOperationSource<ExtendedServerBlobAuditingPolicy>
    {
        private readonly OperationInternals<ExtendedServerBlobAuditingPolicy> _operation;

        private readonly ArmResource _operationBase;

        /// <summary> Initializes a new instance of ExtendedServerBlobAuditingPolicyCreateOrUpdateOperation for mocking. </summary>
        protected ExtendedServerBlobAuditingPolicyCreateOrUpdateOperation()
        {
        }

        internal ExtendedServerBlobAuditingPolicyCreateOrUpdateOperation(ArmResource operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<ExtendedServerBlobAuditingPolicy>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "ExtendedServerBlobAuditingPolicyCreateOrUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override ExtendedServerBlobAuditingPolicy Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ExtendedServerBlobAuditingPolicy>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<ExtendedServerBlobAuditingPolicy>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        ExtendedServerBlobAuditingPolicy IOperationSource<ExtendedServerBlobAuditingPolicy>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return new ExtendedServerBlobAuditingPolicy(_operationBase, ExtendedServerBlobAuditingPolicyData.DeserializeExtendedServerBlobAuditingPolicyData(document.RootElement));
        }

        async ValueTask<ExtendedServerBlobAuditingPolicy> IOperationSource<ExtendedServerBlobAuditingPolicy>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return new ExtendedServerBlobAuditingPolicy(_operationBase, ExtendedServerBlobAuditingPolicyData.DeserializeExtendedServerBlobAuditingPolicyData(document.RootElement));
        }
    }
}
