// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Azure resource. This resource is tracked in Azure Resource Manager. </summary>
    public partial class AppServiceResource : TrackedResource
    {
        /// <summary> Initializes a new instance of AppServiceResource. </summary>
        /// <param name="location"> The location. </param>
        public AppServiceResource(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of AppServiceResource. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="kind"> Kind of resource. </param>
        internal AppServiceResource(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, Location location, string kind) : base(id, name, type, tags, location)
        {
            Kind = kind;
        }

        /// <summary> Kind of resource. </summary>
        public string Kind { get; set; }
    }
}
