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

namespace Azure.ResourceManager.AppService
{
    /// <summary> A Class representing a SiteHybridConnection along with the instance operations that can be performed on it. </summary>
    public partial class SiteHybridConnection : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteHybridConnection"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string entityName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteHybridConnectionWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteHybridConnectionWebAppsRestClient;
        private readonly RelayServiceConnectionEntityData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteHybridConnection"/> class for mocking. </summary>
        protected SiteHybridConnection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteHybridConnection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteHybridConnection(ArmClient client, RelayServiceConnectionEntityData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteHybridConnection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteHybridConnection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteHybridConnectionWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string siteHybridConnectionWebAppsApiVersion);
            _siteHybridConnectionWebAppsRestClient = new WebAppsRestOperations(_siteHybridConnectionWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteHybridConnectionWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/hybridconnection";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual RelayServiceConnectionEntityData Data
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
        /// Description for Gets a hybrid connection configuration by its name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}
        /// Operation Id: WebApps_GetRelayServiceConnection
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SiteHybridConnection>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteHybridConnectionWebAppsClientDiagnostics.CreateScope("SiteHybridConnection.Get");
            scope.Start();
            try
            {
                var response = await _siteHybridConnectionWebAppsRestClient.GetRelayServiceConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteHybridConnectionWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteHybridConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets a hybrid connection configuration by its name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}
        /// Operation Id: WebApps_GetRelayServiceConnection
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteHybridConnection> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteHybridConnectionWebAppsClientDiagnostics.CreateScope("SiteHybridConnection.Get");
            scope.Start();
            try
            {
                var response = _siteHybridConnectionWebAppsRestClient.GetRelayServiceConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _siteHybridConnectionWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteHybridConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Deletes a relay service connection by its name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}
        /// Operation Id: WebApps_DeleteRelayServiceConnection
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _siteHybridConnectionWebAppsClientDiagnostics.CreateScope("SiteHybridConnection.Delete");
            scope.Start();
            try
            {
                var response = await _siteHybridConnectionWebAppsRestClient.DeleteRelayServiceConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation(response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Deletes a relay service connection by its name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}
        /// Operation Id: WebApps_DeleteRelayServiceConnection
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _siteHybridConnectionWebAppsClientDiagnostics.CreateScope("SiteHybridConnection.Delete");
            scope.Start();
            try
            {
                var response = _siteHybridConnectionWebAppsRestClient.DeleteRelayServiceConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new AppServiceArmOperation(response);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}
        /// Operation Id: WebApps_UpdateRelayServiceConnection
        /// </summary>
        /// <param name="connectionEnvelope"> Details of the hybrid connection configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionEnvelope"/> is null. </exception>
        public async virtual Task<Response<SiteHybridConnection>> UpdateAsync(RelayServiceConnectionEntityData connectionEnvelope, CancellationToken cancellationToken = default)
        {
            if (connectionEnvelope == null)
            {
                throw new ArgumentNullException(nameof(connectionEnvelope));
            }

            using var scope = _siteHybridConnectionWebAppsClientDiagnostics.CreateScope("SiteHybridConnection.Update");
            scope.Start();
            try
            {
                var response = await _siteHybridConnectionWebAppsRestClient.UpdateRelayServiceConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, connectionEnvelope, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SiteHybridConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hybridconnection/{entityName}
        /// Operation Id: WebApps_UpdateRelayServiceConnection
        /// </summary>
        /// <param name="connectionEnvelope"> Details of the hybrid connection configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionEnvelope"/> is null. </exception>
        public virtual Response<SiteHybridConnection> Update(RelayServiceConnectionEntityData connectionEnvelope, CancellationToken cancellationToken = default)
        {
            if (connectionEnvelope == null)
            {
                throw new ArgumentNullException(nameof(connectionEnvelope));
            }

            using var scope = _siteHybridConnectionWebAppsClientDiagnostics.CreateScope("SiteHybridConnection.Update");
            scope.Start();
            try
            {
                var response = _siteHybridConnectionWebAppsRestClient.UpdateRelayServiceConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, connectionEnvelope, cancellationToken);
                return Response.FromValue(new SiteHybridConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
