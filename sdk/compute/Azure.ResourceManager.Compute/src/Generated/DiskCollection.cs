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
    /// <summary> A class representing collection of Disk and their operations over its parent. </summary>
    public partial class DiskCollection : ArmCollection, IEnumerable<Disk>, IAsyncEnumerable<Disk>

    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly DisksRestOperations _disksRestClient;

        /// <summary> Initializes a new instance of the <see cref="DiskCollection"/> class for mocking. </summary>
        protected DiskCollection()
        {
        }

        /// <summary> Initializes a new instance of DiskCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DiskCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _disksRestClient = new DisksRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// <summary> Creates or updates a disk. </summary>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="disk"> Disk object supplied in the body of the Put disk operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskName"/> or <paramref name="disk"/> is null. </exception>
        public virtual DiskCreateOrUpdateOperation CreateOrUpdate(string diskName, DiskData disk, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }
            if (disk == null)
            {
                throw new ArgumentNullException(nameof(disk));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _disksRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, diskName, disk, cancellationToken);
                var operation = new DiskCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _disksRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, diskName, disk).Request, response);
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

        /// <summary> Creates or updates a disk. </summary>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="disk"> Disk object supplied in the body of the Put disk operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskName"/> or <paramref name="disk"/> is null. </exception>
        public async virtual Task<DiskCreateOrUpdateOperation> CreateOrUpdateAsync(string diskName, DiskData disk, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }
            if (disk == null)
            {
                throw new ArgumentNullException(nameof(disk));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _disksRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, diskName, disk, cancellationToken).ConfigureAwait(false);
                var operation = new DiskCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _disksRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, diskName, disk).Request, response);
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

        /// <summary> Gets information about a disk. </summary>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskName"/> is null. </exception>
        public virtual Response<Disk> Get(string diskName, CancellationToken cancellationToken = default)
        {
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskCollection.Get");
            scope.Start();
            try
            {
                var response = _disksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Disk(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets information about a disk. </summary>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskName"/> is null. </exception>
        public async virtual Task<Response<Disk>> GetAsync(string diskName, CancellationToken cancellationToken = default)
        {
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskCollection.Get");
            scope.Start();
            try
            {
                var response = await _disksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Disk(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskName"/> is null. </exception>
        public virtual Response<Disk> GetIfExists(string diskName, CancellationToken cancellationToken = default)
        {
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _disksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, diskName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<Disk>(null, response.GetRawResponse())
                    : Response.FromValue(new Disk(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskName"/> is null. </exception>
        public async virtual Task<Response<Disk>> GetIfExistsAsync(string diskName, CancellationToken cancellationToken = default)
        {
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _disksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, diskName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<Disk>(null, response.GetRawResponse())
                    : Response.FromValue(new Disk(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskName"/> is null. </exception>
        public virtual Response<bool> Exists(string diskName, CancellationToken cancellationToken = default)
        {
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(diskName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskName"> The name of the managed disk that is being created. The name can&apos;t be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string diskName, CancellationToken cancellationToken = default)
        {
            if (diskName == null)
            {
                throw new ArgumentNullException(nameof(diskName));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(diskName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all the disks under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Disk" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Disk> GetAll(CancellationToken cancellationToken = default)
        {
            Page<Disk> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _disksRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Disk(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Disk> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _disksRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Disk(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the disks under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Disk" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Disk> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Disk>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _disksRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Disk(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Disk>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _disksRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Disk(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="Disk" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Disk.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Disk" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(Disk.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Disk> IEnumerable<Disk>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Disk> IAsyncEnumerable<Disk>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.ResourceManager.ResourceIdentifier, Disk, DiskData> Construct() { }
    }
}
