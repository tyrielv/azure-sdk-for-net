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
    /// <summary> A Class representing a DeletedServer along with the instance operations that can be performed on it. </summary>
    public partial class DeletedServer : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DeletedServer"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string deletedServerName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/deletedServers/{deletedServerName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _deletedServerClientDiagnostics;
        private readonly DeletedServersRestOperations _deletedServerRestClient;
        private readonly DeletedServerData _data;

        /// <summary> Initializes a new instance of the <see cref="DeletedServer"/> class for mocking. </summary>
        protected DeletedServer()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DeletedServer"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DeletedServer(ArmClient client, DeletedServerData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedServer"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DeletedServer(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deletedServerClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string deletedServerApiVersion);
            _deletedServerRestClient = new DeletedServersRestOperations(_deletedServerClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deletedServerApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/locations/deletedServers";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DeletedServerData Data
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
        /// Gets a deleted server.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/deletedServers/{deletedServerName}
        /// Operation Id: DeletedServers_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<DeletedServer>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deletedServerClientDiagnostics.CreateScope("DeletedServer.Get");
            scope.Start();
            try
            {
                var response = await _deletedServerRestClient.GetAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _deletedServerClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DeletedServer(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a deleted server.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/deletedServers/{deletedServerName}
        /// Operation Id: DeletedServers_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeletedServer> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _deletedServerClientDiagnostics.CreateScope("DeletedServer.Get");
            scope.Start();
            try
            {
                var response = _deletedServerRestClient.Get(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _deletedServerClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedServer(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recovers a deleted server.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/deletedServers/{deletedServerName}/recover
        /// Operation Id: DeletedServers_Recover
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation<DeletedServer>> RecoverAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _deletedServerClientDiagnostics.CreateScope("DeletedServer.Recover");
            scope.Start();
            try
            {
                var response = await _deletedServerRestClient.RecoverAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<DeletedServer>(new DeletedServerOperationSource(Client), _deletedServerClientDiagnostics, Pipeline, _deletedServerRestClient.CreateRecoverRequest(Id.SubscriptionId, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// Recovers a deleted server.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/deletedServers/{deletedServerName}/recover
        /// Operation Id: DeletedServers_Recover
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<DeletedServer> Recover(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _deletedServerClientDiagnostics.CreateScope("DeletedServer.Recover");
            scope.Start();
            try
            {
                var response = _deletedServerRestClient.Recover(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SqlArmOperation<DeletedServer>(new DeletedServerOperationSource(Client), _deletedServerClientDiagnostics, Pipeline, _deletedServerRestClient.CreateRecoverRequest(Id.SubscriptionId, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
    }
}
