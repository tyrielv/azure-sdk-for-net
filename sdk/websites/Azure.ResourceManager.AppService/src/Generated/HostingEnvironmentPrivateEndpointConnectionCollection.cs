// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of RemotePrivateEndpointConnectionARMResource and their operations over its parent. </summary>
    public partial class HostingEnvironmentPrivateEndpointConnectionCollection : ArmCollection, IEnumerable<HostingEnvironmentPrivateEndpointConnection>, IAsyncEnumerable<HostingEnvironmentPrivateEndpointConnection>
    {
        private readonly ClientDiagnostics _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics;
        private readonly AppServiceEnvironmentsRestOperations _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient;

        /// <summary> Initializes a new instance of the <see cref="HostingEnvironmentPrivateEndpointConnectionCollection"/> class for mocking. </summary>
        protected HostingEnvironmentPrivateEndpointConnectionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="HostingEnvironmentPrivateEndpointConnectionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal HostingEnvironmentPrivateEndpointConnectionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", HostingEnvironmentPrivateEndpointConnection.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(HostingEnvironmentPrivateEndpointConnection.ResourceType, out string hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsApiVersion);
            _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient = new AppServiceEnvironmentsRestOperations(_hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AppServiceEnvironment.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AppServiceEnvironment.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Approves or rejects a private endpoint connection
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}
        /// Operation Id: AppServiceEnvironments_ApproveOrRejectPrivateEndpointConnection
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="privateEndpointConnectionName"> The String to use. </param>
        /// <param name="privateEndpointWrapper"> The PrivateLinkConnectionApprovalRequestResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> or <paramref name="privateEndpointWrapper"/> is null. </exception>
        public async virtual Task<ArmOperation<HostingEnvironmentPrivateEndpointConnection>> CreateOrUpdateAsync(bool waitForCompletion, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            if (privateEndpointWrapper == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointWrapper));
            }

            using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.ApproveOrRejectPrivateEndpointConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, privateEndpointWrapper, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<HostingEnvironmentPrivateEndpointConnection>(new HostingEnvironmentPrivateEndpointConnectionOperationSource(Client), _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics, Pipeline, _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.CreateApproveOrRejectPrivateEndpointConnectionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, privateEndpointWrapper).Request, response, OperationFinalStateVia.Location);
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
        /// Description for Approves or rejects a private endpoint connection
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}
        /// Operation Id: AppServiceEnvironments_ApproveOrRejectPrivateEndpointConnection
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="privateEndpointConnectionName"> The String to use. </param>
        /// <param name="privateEndpointWrapper"> The PrivateLinkConnectionApprovalRequestResource to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> or <paramref name="privateEndpointWrapper"/> is null. </exception>
        public virtual ArmOperation<HostingEnvironmentPrivateEndpointConnection> CreateOrUpdate(bool waitForCompletion, string privateEndpointConnectionName, PrivateLinkConnectionApprovalRequestResource privateEndpointWrapper, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));
            if (privateEndpointWrapper == null)
            {
                throw new ArgumentNullException(nameof(privateEndpointWrapper));
            }

            using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.ApproveOrRejectPrivateEndpointConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, privateEndpointWrapper, cancellationToken);
                var operation = new AppServiceArmOperation<HostingEnvironmentPrivateEndpointConnection>(new HostingEnvironmentPrivateEndpointConnectionOperationSource(Client), _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics, Pipeline, _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.CreateApproveOrRejectPrivateEndpointConnectionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, privateEndpointWrapper).Request, response, OperationFinalStateVia.Location);
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

        /// <summary>
        /// Description for Gets a private endpoint connection
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}
        /// Operation Id: AppServiceEnvironments_GetPrivateEndpointConnection
        /// </summary>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public async virtual Task<Response<HostingEnvironmentPrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.Get");
            scope.Start();
            try
            {
                var response = await _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.GetPrivateEndpointConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new HostingEnvironmentPrivateEndpointConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets a private endpoint connection
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}
        /// Operation Id: AppServiceEnvironments_GetPrivateEndpointConnection
        /// </summary>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public virtual Response<HostingEnvironmentPrivateEndpointConnection> Get(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.Get");
            scope.Start();
            try
            {
                var response = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.GetPrivateEndpointConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, cancellationToken);
                if (response.Value == null)
                    throw _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new HostingEnvironmentPrivateEndpointConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets the list of private endpoints associated with a hosting environment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections
        /// Operation Id: AppServiceEnvironments_GetPrivateEndpointConnectionList
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="HostingEnvironmentPrivateEndpointConnection" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<HostingEnvironmentPrivateEndpointConnection> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<HostingEnvironmentPrivateEndpointConnection>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.GetPrivateEndpointConnectionListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new HostingEnvironmentPrivateEndpointConnection(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<HostingEnvironmentPrivateEndpointConnection>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.GetPrivateEndpointConnectionListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new HostingEnvironmentPrivateEndpointConnection(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Description for Gets the list of private endpoints associated with a hosting environment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections
        /// Operation Id: AppServiceEnvironments_GetPrivateEndpointConnectionList
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="HostingEnvironmentPrivateEndpointConnection" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<HostingEnvironmentPrivateEndpointConnection> GetAll(CancellationToken cancellationToken = default)
        {
            Page<HostingEnvironmentPrivateEndpointConnection> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.GetPrivateEndpointConnectionList(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new HostingEnvironmentPrivateEndpointConnection(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<HostingEnvironmentPrivateEndpointConnection> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.GetPrivateEndpointConnectionListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new HostingEnvironmentPrivateEndpointConnection(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}
        /// Operation Id: AppServiceEnvironments_GetPrivateEndpointConnection
        /// </summary>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(privateEndpointConnectionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}
        /// Operation Id: AppServiceEnvironments_GetPrivateEndpointConnection
        /// </summary>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public virtual Response<bool> Exists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(privateEndpointConnectionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}
        /// Operation Id: AppServiceEnvironments_GetPrivateEndpointConnection
        /// </summary>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public async virtual Task<Response<HostingEnvironmentPrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.GetPrivateEndpointConnectionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<HostingEnvironmentPrivateEndpointConnection>(null, response.GetRawResponse());
                return Response.FromValue(new HostingEnvironmentPrivateEndpointConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/privateEndpointConnections/{privateEndpointConnectionName}
        /// Operation Id: AppServiceEnvironments_GetPrivateEndpointConnection
        /// </summary>
        /// <param name="privateEndpointConnectionName"> Name of the private endpoint connection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="privateEndpointConnectionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="privateEndpointConnectionName"/> is null. </exception>
        public virtual Response<HostingEnvironmentPrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(privateEndpointConnectionName, nameof(privateEndpointConnectionName));

            using var scope = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsClientDiagnostics.CreateScope("HostingEnvironmentPrivateEndpointConnectionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _hostingEnvironmentPrivateEndpointConnectionAppServiceEnvironmentsRestClient.GetPrivateEndpointConnection(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, privateEndpointConnectionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<HostingEnvironmentPrivateEndpointConnection>(null, response.GetRawResponse());
                return Response.FromValue(new HostingEnvironmentPrivateEndpointConnection(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<HostingEnvironmentPrivateEndpointConnection> IEnumerable<HostingEnvironmentPrivateEndpointConnection>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<HostingEnvironmentPrivateEndpointConnection> IAsyncEnumerable<HostingEnvironmentPrivateEndpointConnection>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
