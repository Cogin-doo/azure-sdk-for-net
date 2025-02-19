// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing collection of DiskAccess and their operations over its parent. </summary>
    public partial class DiskAccessCollection : ArmCollection, IEnumerable<DiskAccess>, IAsyncEnumerable<DiskAccess>

    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly DiskAccessesRestOperations _diskAccessesRestClient;

        /// <summary> Initializes a new instance of the <see cref="DiskAccessCollection"/> class for mocking. </summary>
        protected DiskAccessCollection()
        {
        }

        /// <summary> Initializes a new instance of DiskAccessCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DiskAccessCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _diskAccessesRestClient = new DiskAccessesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// <summary> Creates or updates a disk access resource. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="diskAccess"> disk access object supplied in the body of the Put disk access operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> or <paramref name="diskAccess"/> is null. </exception>
        public virtual DiskAccessCreateOrUpdateOperation CreateOrUpdate(string diskAccessName, DiskAccessData diskAccess, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }
            if (diskAccess == null)
            {
                throw new ArgumentNullException(nameof(diskAccess));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _diskAccessesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, diskAccess, cancellationToken);
                var operation = new DiskAccessCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _diskAccessesRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, diskAccess).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a disk access resource. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="diskAccess"> disk access object supplied in the body of the Put disk access operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> or <paramref name="diskAccess"/> is null. </exception>
        public async virtual Task<DiskAccessCreateOrUpdateOperation> CreateOrUpdateAsync(string diskAccessName, DiskAccessData diskAccess, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }
            if (diskAccess == null)
            {
                throw new ArgumentNullException(nameof(diskAccess));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _diskAccessesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, diskAccess, cancellationToken).ConfigureAwait(false);
                var operation = new DiskAccessCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _diskAccessesRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, diskAccess).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets information about a disk access resource. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public virtual Response<DiskAccess> Get(string diskAccessName, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.Get");
            scope.Start();
            try
            {
                var response = _diskAccessesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DiskAccess(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets information about a disk access resource. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public async virtual Task<Response<DiskAccess>> GetAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.Get");
            scope.Start();
            try
            {
                var response = await _diskAccessesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DiskAccess(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public virtual Response<DiskAccess> GetIfExists(string diskAccessName, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _diskAccessesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<DiskAccess>(null, response.GetRawResponse())
                    : Response.FromValue(new DiskAccess(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public async virtual Task<Response<DiskAccess>> GetIfExistsAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _diskAccessesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskAccessName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<DiskAccess>(null, response.GetRawResponse())
                    : Response.FromValue(new DiskAccess(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public virtual Response<bool> Exists(string diskAccessName, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(diskAccessName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskAccessName"> The name of the disk access resource that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskAccessName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string diskAccessName, CancellationToken cancellationToken = default)
        {
            if (diskAccessName == null)
            {
                throw new ArgumentNullException(nameof(diskAccessName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(diskAccessName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all the disk access resources under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DiskAccess" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DiskAccess> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DiskAccess> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _diskAccessesRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DiskAccess> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _diskAccessesRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the disk access resources under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DiskAccess" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DiskAccess> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DiskAccess>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _diskAccessesRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DiskAccess>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _diskAccessesRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskAccess(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="DiskAccess" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DiskAccess.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="DiskAccess" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskAccessCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DiskAccess.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DiskAccess> IEnumerable<DiskAccess>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DiskAccess> IAsyncEnumerable<DiskAccess>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, DiskAccess, DiskAccessData> Construct() { }
    }
}
