// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A Class representing a PrivateLinkResource along with the instance operations that can be performed on it. </summary>
    public partial class PrivateLinkResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="PrivateLinkResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/privateLinkResources/{groupName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _privateLinkResourceClientDiagnostics;
        private readonly PrivateLinkResourcesRestOperations _privateLinkResourceRestClient;
        private readonly PrivateLinkResourceData _data;

        /// <summary> Initializes a new instance of the <see cref="PrivateLinkResource"/> class for mocking. </summary>
        protected PrivateLinkResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PrivateLinkResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal PrivateLinkResource(ArmClient client, PrivateLinkResourceData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateLinkResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PrivateLinkResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _privateLinkResourceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string privateLinkResourceApiVersion);
            _privateLinkResourceRestClient = new PrivateLinkResourcesRestOperations(_privateLinkResourceClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, privateLinkResourceApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/servers/privateLinkResources";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PrivateLinkResourceData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a private link resource for SQL server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/privateLinkResources/{groupName}
        /// Operation Id: PrivateLinkResources_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<PrivateLinkResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _privateLinkResourceClientDiagnostics.CreateScope("PrivateLinkResource.Get");
            scope.Start();
            try
            {
                var response = await _privateLinkResourceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _privateLinkResourceClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PrivateLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a private link resource for SQL server.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/privateLinkResources/{groupName}
        /// Operation Id: PrivateLinkResources_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PrivateLinkResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _privateLinkResourceClientDiagnostics.CreateScope("PrivateLinkResource.Get");
            scope.Start();
            try
            {
                var response = _privateLinkResourceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _privateLinkResourceClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
