﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [NonParallelizable]
    public class ManagedIdentityCredentialLiveTestBase : IdentityRecordedTestBase
    {
        // need to use legacy transport until https://github.com/Azure/azure-sdk-tools/issues/2369 is addressed
        public ManagedIdentityCredentialLiveTestBase(bool isAsync) : base(isAsync, useLegacyTransport: true)
        {
        }

        public ManagedIdentityCredentialLiveTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode, useLegacyTransport: true)
        {
        }

        protected IDisposable ReadOrRestoreManagedIdentityEnvironment()
        {
            return new ManagedIdenityEnvironment(TestEnvironment);
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                // Check the old method name and the new method name until temporarily
                var type = typeof(SecretClient).Assembly.GetType("Azure.Security.KeyVault.ChallengeBasedAuthenticationPolicy+AuthenticationChallenge") ??
                    typeof(SecretClient).Assembly.GetType("Azure.Security.KeyVault.ChallengeBasedAuthenticationPolicy");

                type.GetMethod("ClearCache", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, null);
            }
        }

        private class ManagedIdenityEnvironment : IDisposable
        {
            private readonly TestEnvVar _envVar;

            public ManagedIdenityEnvironment(IdentityTestEnvironment env)
            {
                _envVar =
                    new TestEnvVar(
                        new Dictionary<string, string>
                        {
                            { "IDENTITY_ENDPOINT", env.IdentityEndpoint },
                            { "IMDS_ENDPOINT", env.ImdsEndpoint },
                            { "MSI_ENDPOINT", env.MsiEndpoint },
                            { "MSI_SECRET", env.MsiSecret },{ "IDENTITY_HEADER", env.IdentityHeader },
                            { "IDENTITY_SERVER_THUMBPRINT", env.IdentityServerThumbprint } });
            }

            public void Dispose()
            {
                _envVar.Dispose();
            }
        }
    }
}
