// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Describes main public IP address and any extra virtual IPs. </summary>
    public partial class AddressResponse : ProxyOnlyResource
    {
        /// <summary> Initializes a new instance of AddressResponse. </summary>
        public AddressResponse()
        {
            OutboundIpAddresses = new ChangeTrackingList<string>();
            VipMappings = new ChangeTrackingList<VirtualIPMapping>();
        }

        /// <summary> Initializes a new instance of AddressResponse. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <param name="serviceIpAddress"> Main public virtual IP. </param>
        /// <param name="internalIpAddress"> Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode. </param>
        /// <param name="outboundIpAddresses"> IP addresses appearing on outbound connections. </param>
        /// <param name="vipMappings"> Additional virtual IPs. </param>
        internal AddressResponse(ResourceIdentifier id, string name, ResourceType type, string kind, string serviceIpAddress, string internalIpAddress, IList<string> outboundIpAddresses, IList<VirtualIPMapping> vipMappings) : base(id, name, type, kind)
        {
            ServiceIpAddress = serviceIpAddress;
            InternalIpAddress = internalIpAddress;
            OutboundIpAddresses = outboundIpAddresses;
            VipMappings = vipMappings;
        }

        /// <summary> Main public virtual IP. </summary>
        public string ServiceIpAddress { get; set; }
        /// <summary> Virtual Network internal IP address of the App Service Environment if it is in internal load-balancing mode. </summary>
        public string InternalIpAddress { get; set; }
        /// <summary> IP addresses appearing on outbound connections. </summary>
        public IList<string> OutboundIpAddresses { get; }
        /// <summary> Additional virtual IPs. </summary>
        public IList<VirtualIPMapping> VipMappings { get; }
    }
}
