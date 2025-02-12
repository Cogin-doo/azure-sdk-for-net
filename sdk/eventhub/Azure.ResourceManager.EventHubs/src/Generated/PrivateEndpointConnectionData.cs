// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.EventHubs
{
    /// <summary> A class representing the PrivateEndpointConnection data model. </summary>
    public partial class PrivateEndpointConnectionData : ProxyResource
    {
        /// <summary> Initializes a new instance of PrivateEndpointConnectionData. </summary>
        public PrivateEndpointConnectionData()
        {
        }

        /// <summary> Initializes a new instance of PrivateEndpointConnectionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="systemData"> The system meta data relating to this resource. </param>
        /// <param name="privateEndpoint"> The Private Endpoint resource for this Connection. </param>
        /// <param name="privateLinkServiceConnectionState"> Details about the state of the connection. </param>
        /// <param name="provisioningState"> Provisioning state of the Private Endpoint Connection. </param>
        internal PrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType type, string location, SystemData systemData, WritableSubResource privateEndpoint, ConnectionState privateLinkServiceConnectionState, EndPointProvisioningState? provisioningState) : base(id, name, type, location)
        {
            SystemData = systemData;
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
            ProvisioningState = provisioningState;
        }

        /// <summary> The system meta data relating to this resource. </summary>
        public SystemData SystemData { get; }
        /// <summary> The Private Endpoint resource for this Connection. </summary>
        public WritableSubResource PrivateEndpoint { get; set; }
        /// <summary> Details about the state of the connection. </summary>
        public ConnectionState PrivateLinkServiceConnectionState { get; set; }
        /// <summary> Provisioning state of the Private Endpoint Connection. </summary>
        public EndPointProvisioningState? ProvisioningState { get; set; }
    }
}
