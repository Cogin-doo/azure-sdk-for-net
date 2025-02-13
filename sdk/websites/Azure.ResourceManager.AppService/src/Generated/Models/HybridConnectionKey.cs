// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Hybrid Connection key contract. This has the send key name and value for a Hybrid Connection. </summary>
    public partial class HybridConnectionKey : ProxyOnlyResource
    {
        /// <summary> Initializes a new instance of HybridConnectionKey. </summary>
        public HybridConnectionKey()
        {
        }

        /// <summary> Initializes a new instance of HybridConnectionKey. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <param name="sendKeyName"> The name of the send key. </param>
        /// <param name="sendKeyValue"> The value of the send key. </param>
        internal HybridConnectionKey(ResourceIdentifier id, string name, ResourceType type, string kind, string sendKeyName, string sendKeyValue) : base(id, name, type, kind)
        {
            SendKeyName = sendKeyName;
            SendKeyValue = sendKeyValue;
        }

        /// <summary> The name of the send key. </summary>
        public string SendKeyName { get; }
        /// <summary> The value of the send key. </summary>
        public string SendKeyValue { get; }
    }
}
