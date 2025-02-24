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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of ServerSecurityAlertPolicy and their operations over its parent. </summary>
    public partial class ServerSecurityAlertPolicyCollection : ArmCollection, IEnumerable<ServerSecurityAlertPolicy>, IAsyncEnumerable<ServerSecurityAlertPolicy>
    {
        private readonly ClientDiagnostics _serverSecurityAlertPolicyClientDiagnostics;
        private readonly ServerSecurityAlertPoliciesRestOperations _serverSecurityAlertPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServerSecurityAlertPolicyCollection"/> class for mocking. </summary>
        protected ServerSecurityAlertPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServerSecurityAlertPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ServerSecurityAlertPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverSecurityAlertPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ServerSecurityAlertPolicy.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ServerSecurityAlertPolicy.ResourceType, out string serverSecurityAlertPolicyApiVersion);
            _serverSecurityAlertPolicyRestClient = new ServerSecurityAlertPoliciesRestOperations(_serverSecurityAlertPolicyClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, serverSecurityAlertPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlServer.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlServer.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a threat detection policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ServerSecurityAlertPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="securityAlertPolicyName"> The name of the threat detection policy. </param>
        /// <param name="parameters"> The server security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ServerSecurityAlertPolicy>> CreateOrUpdateAsync(bool waitForCompletion, SecurityAlertPolicyName securityAlertPolicyName, ServerSecurityAlertPolicyData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _serverSecurityAlertPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<ServerSecurityAlertPolicy>(new ServerSecurityAlertPolicyOperationSource(Client), _serverSecurityAlertPolicyClientDiagnostics, Pipeline, _serverSecurityAlertPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a threat detection policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ServerSecurityAlertPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="securityAlertPolicyName"> The name of the threat detection policy. </param>
        /// <param name="parameters"> The server security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ServerSecurityAlertPolicy> CreateOrUpdate(bool waitForCompletion, SecurityAlertPolicyName securityAlertPolicyName, ServerSecurityAlertPolicyData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _serverSecurityAlertPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, parameters, cancellationToken);
                var operation = new SqlArmOperation<ServerSecurityAlertPolicy>(new ServerSecurityAlertPolicyOperationSource(Client), _serverSecurityAlertPolicyClientDiagnostics, Pipeline, _serverSecurityAlertPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Get a server&apos;s security alert policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ServerSecurityAlertPolicy>> GetAsync(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _serverSecurityAlertPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _serverSecurityAlertPolicyClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ServerSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a server&apos;s security alert policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ServerSecurityAlertPolicy> Get(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _serverSecurityAlertPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, cancellationToken);
                if (response.Value == null)
                    throw _serverSecurityAlertPolicyClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the server&apos;s threat detection policies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies
        /// Operation Id: ServerSecurityAlertPolicies_ListByServer
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServerSecurityAlertPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServerSecurityAlertPolicy> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ServerSecurityAlertPolicy>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverSecurityAlertPolicyRestClient.ListByServerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerSecurityAlertPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ServerSecurityAlertPolicy>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverSecurityAlertPolicyRestClient.ListByServerNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerSecurityAlertPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Get the server&apos;s threat detection policies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies
        /// Operation Id: ServerSecurityAlertPolicies_ListByServer
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServerSecurityAlertPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServerSecurityAlertPolicy> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ServerSecurityAlertPolicy> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverSecurityAlertPolicyRestClient.ListByServer(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerSecurityAlertPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ServerSecurityAlertPolicy> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverSecurityAlertPolicyRestClient.ListByServerNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerSecurityAlertPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<bool>> ExistsAsync(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(securityAlertPolicyName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(securityAlertPolicyName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ServerSecurityAlertPolicy>> GetIfExistsAsync(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serverSecurityAlertPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServerSecurityAlertPolicy>(null, response.GetRawResponse());
                return Response.FromValue(new ServerSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ServerSecurityAlertPolicy> GetIfExists(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverSecurityAlertPolicyClientDiagnostics.CreateScope("ServerSecurityAlertPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serverSecurityAlertPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServerSecurityAlertPolicy>(null, response.GetRawResponse());
                return Response.FromValue(new ServerSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ServerSecurityAlertPolicy> IEnumerable<ServerSecurityAlertPolicy>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServerSecurityAlertPolicy> IAsyncEnumerable<ServerSecurityAlertPolicy>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
