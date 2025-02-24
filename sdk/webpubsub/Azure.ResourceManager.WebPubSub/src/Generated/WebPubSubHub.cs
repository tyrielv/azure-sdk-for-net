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

namespace Azure.ResourceManager.WebPubSub
{
    /// <summary> A Class representing a WebPubSubHub along with the instance operations that can be performed on it. </summary>
    public partial class WebPubSubHub : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="WebPubSubHub"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string hubName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _webPubSubHubClientDiagnostics;
        private readonly WebPubSubHubsRestOperations _webPubSubHubRestClient;
        private readonly WebPubSubHubData _data;

        /// <summary> Initializes a new instance of the <see cref="WebPubSubHub"/> class for mocking. </summary>
        protected WebPubSubHub()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "WebPubSubHub"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal WebPubSubHub(ArmClient client, WebPubSubHubData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="WebPubSubHub"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal WebPubSubHub(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _webPubSubHubClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.WebPubSub", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string webPubSubHubApiVersion);
            _webPubSubHubRestClient = new WebPubSubHubsRestOperations(_webPubSubHubClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, webPubSubHubApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.SignalRService/webPubSub/hubs";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual WebPubSubHubData Data
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
        /// Get a hub setting.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<WebPubSubHub>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHub.Get");
            scope.Start();
            try
            {
                var response = await _webPubSubHubRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _webPubSubHubClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new WebPubSubHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a hub setting.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<WebPubSubHub> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHub.Get");
            scope.Start();
            try
            {
                var response = _webPubSubHubRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _webPubSubHubClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new WebPubSubHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a hub setting.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHub.Delete");
            scope.Start();
            try
            {
                var response = await _webPubSubHubRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new WebPubSubArmOperation(_webPubSubHubClientDiagnostics, Pipeline, _webPubSubHubRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Delete a hub setting.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/webPubSub/{resourceName}/hubs/{hubName}
        /// Operation Id: WebPubSubHubs_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _webPubSubHubClientDiagnostics.CreateScope("WebPubSubHub.Delete");
            scope.Start();
            try
            {
                var response = _webPubSubHubRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new WebPubSubArmOperation(_webPubSubHubClientDiagnostics, Pipeline, _webPubSubHubRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
    }
}
