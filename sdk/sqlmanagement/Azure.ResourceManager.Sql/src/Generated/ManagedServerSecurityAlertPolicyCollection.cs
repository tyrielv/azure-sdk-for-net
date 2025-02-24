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
    /// <summary> A class representing collection of ManagedServerSecurityAlertPolicy and their operations over its parent. </summary>
    public partial class ManagedServerSecurityAlertPolicyCollection : ArmCollection, IEnumerable<ManagedServerSecurityAlertPolicy>, IAsyncEnumerable<ManagedServerSecurityAlertPolicy>
    {
        private readonly ClientDiagnostics _managedServerSecurityAlertPolicyClientDiagnostics;
        private readonly ManagedServerSecurityAlertPoliciesRestOperations _managedServerSecurityAlertPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagedServerSecurityAlertPolicyCollection"/> class for mocking. </summary>
        protected ManagedServerSecurityAlertPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedServerSecurityAlertPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagedServerSecurityAlertPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedServerSecurityAlertPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ManagedServerSecurityAlertPolicy.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ManagedServerSecurityAlertPolicy.ResourceType, out string managedServerSecurityAlertPolicyApiVersion);
            _managedServerSecurityAlertPolicyRestClient = new ManagedServerSecurityAlertPoliciesRestOperations(_managedServerSecurityAlertPolicyClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedServerSecurityAlertPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagedInstance.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagedInstance.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a threat detection policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedServerSecurityAlertPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="parameters"> The managed server security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ManagedServerSecurityAlertPolicy>> CreateOrUpdateAsync(bool waitForCompletion, SecurityAlertPolicyName securityAlertPolicyName, ManagedServerSecurityAlertPolicyData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _managedServerSecurityAlertPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<ManagedServerSecurityAlertPolicy>(new ManagedServerSecurityAlertPolicyOperationSource(Client), _managedServerSecurityAlertPolicyClientDiagnostics, Pipeline, _managedServerSecurityAlertPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedServerSecurityAlertPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="parameters"> The managed server security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ManagedServerSecurityAlertPolicy> CreateOrUpdate(bool waitForCompletion, SecurityAlertPolicyName securityAlertPolicyName, ManagedServerSecurityAlertPolicyData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _managedServerSecurityAlertPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, parameters, cancellationToken);
                var operation = new SqlArmOperation<ManagedServerSecurityAlertPolicy>(new ManagedServerSecurityAlertPolicyOperationSource(Client), _managedServerSecurityAlertPolicyClientDiagnostics, Pipeline, _managedServerSecurityAlertPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Get a managed server&apos;s threat detection policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagedServerSecurityAlertPolicy>> GetAsync(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _managedServerSecurityAlertPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _managedServerSecurityAlertPolicyClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ManagedServerSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a managed server&apos;s threat detection policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagedServerSecurityAlertPolicy> Get(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _managedServerSecurityAlertPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, cancellationToken);
                if (response.Value == null)
                    throw _managedServerSecurityAlertPolicyClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedServerSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the managed server&apos;s threat detection policies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies
        /// Operation Id: ManagedServerSecurityAlertPolicies_ListByInstance
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedServerSecurityAlertPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedServerSecurityAlertPolicy> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedServerSecurityAlertPolicy>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedServerSecurityAlertPolicyRestClient.ListByInstanceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedServerSecurityAlertPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedServerSecurityAlertPolicy>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedServerSecurityAlertPolicyRestClient.ListByInstanceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedServerSecurityAlertPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Get the managed server&apos;s threat detection policies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies
        /// Operation Id: ManagedServerSecurityAlertPolicies_ListByInstance
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedServerSecurityAlertPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedServerSecurityAlertPolicy> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ManagedServerSecurityAlertPolicy> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedServerSecurityAlertPolicyRestClient.ListByInstance(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedServerSecurityAlertPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedServerSecurityAlertPolicy> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedServerSecurityAlertPolicyRestClient.ListByInstanceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedServerSecurityAlertPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<bool>> ExistsAsync(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.Exists");
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.Exists");
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagedServerSecurityAlertPolicy>> GetIfExistsAsync(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managedServerSecurityAlertPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ManagedServerSecurityAlertPolicy>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedServerSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedServerSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="securityAlertPolicyName"> The name of the security alert policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagedServerSecurityAlertPolicy> GetIfExists(SecurityAlertPolicyName securityAlertPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedServerSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedServerSecurityAlertPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managedServerSecurityAlertPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityAlertPolicyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ManagedServerSecurityAlertPolicy>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedServerSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagedServerSecurityAlertPolicy> IEnumerable<ManagedServerSecurityAlertPolicy>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagedServerSecurityAlertPolicy> IAsyncEnumerable<ManagedServerSecurityAlertPolicy>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
