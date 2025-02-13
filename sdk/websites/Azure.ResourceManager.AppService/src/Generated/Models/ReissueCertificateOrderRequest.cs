// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Class representing certificate reissue request. </summary>
    public partial class ReissueCertificateOrderRequest : ProxyOnlyResource
    {
        /// <summary> Initializes a new instance of ReissueCertificateOrderRequest. </summary>
        public ReissueCertificateOrderRequest()
        {
        }

        /// <summary> Initializes a new instance of ReissueCertificateOrderRequest. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <param name="keySize"> Certificate Key Size. </param>
        /// <param name="delayExistingRevokeInHours"> Delay in hours to revoke existing certificate after the new certificate is issued. </param>
        /// <param name="csr"> Csr to be used for re-key operation. </param>
        /// <param name="isPrivateKeyExternal"> Should we change the ASC type (from managed private key to external private key and vice versa). </param>
        internal ReissueCertificateOrderRequest(ResourceIdentifier id, string name, ResourceType type, string kind, int? keySize, int? delayExistingRevokeInHours, string csr, bool? isPrivateKeyExternal) : base(id, name, type, kind)
        {
            KeySize = keySize;
            DelayExistingRevokeInHours = delayExistingRevokeInHours;
            Csr = csr;
            IsPrivateKeyExternal = isPrivateKeyExternal;
        }

        /// <summary> Certificate Key Size. </summary>
        public int? KeySize { get; set; }
        /// <summary> Delay in hours to revoke existing certificate after the new certificate is issued. </summary>
        public int? DelayExistingRevokeInHours { get; set; }
        /// <summary> Csr to be used for re-key operation. </summary>
        public string Csr { get; set; }
        /// <summary> Should we change the ASC type (from managed private key to external private key and vice versa). </summary>
        public bool? IsPrivateKeyExternal { get; set; }
    }
}
