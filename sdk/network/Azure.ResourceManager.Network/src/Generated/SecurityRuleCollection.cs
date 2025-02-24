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

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of SecurityRule and their operations over its parent. </summary>
    public partial class SecurityRuleCollection : ArmCollection, IEnumerable<SecurityRule>, IAsyncEnumerable<SecurityRule>
    {
        private readonly ClientDiagnostics _securityRuleClientDiagnostics;
        private readonly SecurityRulesRestOperations _securityRuleRestClient;

        /// <summary> Initializes a new instance of the <see cref="SecurityRuleCollection"/> class for mocking. </summary>
        protected SecurityRuleCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityRuleCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SecurityRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityRuleClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", SecurityRule.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(SecurityRule.ResourceType, out string securityRuleApiVersion);
            _securityRuleRestClient = new SecurityRulesRestOperations(_securityRuleClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, securityRuleApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != NetworkSecurityGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, NetworkSecurityGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a security rule in the specified network security group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}
        /// Operation Id: SecurityRules_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="securityRuleName"> The name of the security rule. </param>
        /// <param name="securityRuleParameters"> Parameters supplied to the create or update network security rule operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="securityRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="securityRuleName"/> or <paramref name="securityRuleParameters"/> is null. </exception>
        public async virtual Task<ArmOperation<SecurityRule>> CreateOrUpdateAsync(bool waitForCompletion, string securityRuleName, SecurityRuleData securityRuleParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securityRuleName, nameof(securityRuleName));
            if (securityRuleParameters == null)
            {
                throw new ArgumentNullException(nameof(securityRuleParameters));
            }

            using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityRuleRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityRuleName, securityRuleParameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<SecurityRule>(new SecurityRuleOperationSource(Client), _securityRuleClientDiagnostics, Pipeline, _securityRuleRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityRuleName, securityRuleParameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates or updates a security rule in the specified network security group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}
        /// Operation Id: SecurityRules_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="securityRuleName"> The name of the security rule. </param>
        /// <param name="securityRuleParameters"> Parameters supplied to the create or update network security rule operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="securityRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="securityRuleName"/> or <paramref name="securityRuleParameters"/> is null. </exception>
        public virtual ArmOperation<SecurityRule> CreateOrUpdate(bool waitForCompletion, string securityRuleName, SecurityRuleData securityRuleParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securityRuleName, nameof(securityRuleName));
            if (securityRuleParameters == null)
            {
                throw new ArgumentNullException(nameof(securityRuleParameters));
            }

            using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityRuleRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityRuleName, securityRuleParameters, cancellationToken);
                var operation = new NetworkArmOperation<SecurityRule>(new SecurityRuleOperationSource(Client), _securityRuleClientDiagnostics, Pipeline, _securityRuleRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityRuleName, securityRuleParameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Get the specified network security rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}
        /// Operation Id: SecurityRules_Get
        /// </summary>
        /// <param name="securityRuleName"> The name of the security rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="securityRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="securityRuleName"/> is null. </exception>
        public async virtual Task<Response<SecurityRule>> GetAsync(string securityRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securityRuleName, nameof(securityRuleName));

            using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.Get");
            scope.Start();
            try
            {
                var response = await _securityRuleRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityRuleName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _securityRuleClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SecurityRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the specified network security rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}
        /// Operation Id: SecurityRules_Get
        /// </summary>
        /// <param name="securityRuleName"> The name of the security rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="securityRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="securityRuleName"/> is null. </exception>
        public virtual Response<SecurityRule> Get(string securityRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securityRuleName, nameof(securityRuleName));

            using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.Get");
            scope.Start();
            try
            {
                var response = _securityRuleRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityRuleName, cancellationToken);
                if (response.Value == null)
                    throw _securityRuleClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all security rules in a network security group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules
        /// Operation Id: SecurityRules_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityRule" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityRule> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityRule>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityRuleRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityRule(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityRule>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityRuleRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityRule(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all security rules in a network security group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules
        /// Operation Id: SecurityRules_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityRule" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityRule> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SecurityRule> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityRuleRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityRule(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityRule> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityRuleRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityRule(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}
        /// Operation Id: SecurityRules_Get
        /// </summary>
        /// <param name="securityRuleName"> The name of the security rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="securityRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="securityRuleName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string securityRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securityRuleName, nameof(securityRuleName));

            using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(securityRuleName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}
        /// Operation Id: SecurityRules_Get
        /// </summary>
        /// <param name="securityRuleName"> The name of the security rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="securityRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="securityRuleName"/> is null. </exception>
        public virtual Response<bool> Exists(string securityRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securityRuleName, nameof(securityRuleName));

            using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(securityRuleName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}
        /// Operation Id: SecurityRules_Get
        /// </summary>
        /// <param name="securityRuleName"> The name of the security rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="securityRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="securityRuleName"/> is null. </exception>
        public async virtual Task<Response<SecurityRule>> GetIfExistsAsync(string securityRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securityRuleName, nameof(securityRuleName));

            using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _securityRuleRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityRuleName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SecurityRule>(null, response.GetRawResponse());
                return Response.FromValue(new SecurityRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}
        /// Operation Id: SecurityRules_Get
        /// </summary>
        /// <param name="securityRuleName"> The name of the security rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="securityRuleName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="securityRuleName"/> is null. </exception>
        public virtual Response<SecurityRule> GetIfExists(string securityRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securityRuleName, nameof(securityRuleName));

            using var scope = _securityRuleClientDiagnostics.CreateScope("SecurityRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _securityRuleRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, securityRuleName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SecurityRule>(null, response.GetRawResponse());
                return Response.FromValue(new SecurityRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityRule> IEnumerable<SecurityRule>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityRule> IAsyncEnumerable<SecurityRule>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
