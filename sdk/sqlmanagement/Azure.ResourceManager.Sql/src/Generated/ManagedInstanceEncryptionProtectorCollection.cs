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
    /// <summary> A class representing collection of ManagedInstanceEncryptionProtector and their operations over its parent. </summary>
    public partial class ManagedInstanceEncryptionProtectorCollection : ArmCollection, IEnumerable<ManagedInstanceEncryptionProtector>, IAsyncEnumerable<ManagedInstanceEncryptionProtector>
    {
        private readonly ClientDiagnostics _managedInstanceEncryptionProtectorClientDiagnostics;
        private readonly ManagedInstanceEncryptionProtectorsRestOperations _managedInstanceEncryptionProtectorRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceEncryptionProtectorCollection"/> class for mocking. </summary>
        protected ManagedInstanceEncryptionProtectorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceEncryptionProtectorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagedInstanceEncryptionProtectorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedInstanceEncryptionProtectorClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ManagedInstanceEncryptionProtector.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ManagedInstanceEncryptionProtector.ResourceType, out string managedInstanceEncryptionProtectorApiVersion);
            _managedInstanceEncryptionProtectorRestClient = new ManagedInstanceEncryptionProtectorsRestOperations(_managedInstanceEncryptionProtectorClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedInstanceEncryptionProtectorApiVersion);
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
        /// Updates an existing encryption protector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="encryptionProtectorName"> The name of the encryption protector to be updated. </param>
        /// <param name="parameters"> The requested encryption protector resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ManagedInstanceEncryptionProtector>> CreateOrUpdateAsync(bool waitForCompletion, EncryptionProtectorName encryptionProtectorName, ManagedInstanceEncryptionProtectorData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _managedInstanceEncryptionProtectorRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionProtectorName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<ManagedInstanceEncryptionProtector>(new ManagedInstanceEncryptionProtectorOperationSource(Client), _managedInstanceEncryptionProtectorClientDiagnostics, Pipeline, _managedInstanceEncryptionProtectorRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionProtectorName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Updates an existing encryption protector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="encryptionProtectorName"> The name of the encryption protector to be updated. </param>
        /// <param name="parameters"> The requested encryption protector resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ManagedInstanceEncryptionProtector> CreateOrUpdate(bool waitForCompletion, EncryptionProtectorName encryptionProtectorName, ManagedInstanceEncryptionProtectorData parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _managedInstanceEncryptionProtectorRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionProtectorName, parameters, cancellationToken);
                var operation = new SqlArmOperation<ManagedInstanceEncryptionProtector>(new ManagedInstanceEncryptionProtectorOperationSource(Client), _managedInstanceEncryptionProtectorClientDiagnostics, Pipeline, _managedInstanceEncryptionProtectorRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionProtectorName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a managed instance encryption protector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_Get
        /// </summary>
        /// <param name="encryptionProtectorName"> The name of the encryption protector to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagedInstanceEncryptionProtector>> GetAsync(EncryptionProtectorName encryptionProtectorName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.Get");
            scope.Start();
            try
            {
                var response = await _managedInstanceEncryptionProtectorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionProtectorName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _managedInstanceEncryptionProtectorClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ManagedInstanceEncryptionProtector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a managed instance encryption protector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_Get
        /// </summary>
        /// <param name="encryptionProtectorName"> The name of the encryption protector to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagedInstanceEncryptionProtector> Get(EncryptionProtectorName encryptionProtectorName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.Get");
            scope.Start();
            try
            {
                var response = _managedInstanceEncryptionProtectorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionProtectorName, cancellationToken);
                if (response.Value == null)
                    throw _managedInstanceEncryptionProtectorClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceEncryptionProtector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of managed instance encryption protectors
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector
        /// Operation Id: ManagedInstanceEncryptionProtectors_ListByInstance
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedInstanceEncryptionProtector" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedInstanceEncryptionProtector> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedInstanceEncryptionProtector>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedInstanceEncryptionProtectorRestClient.ListByInstanceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceEncryptionProtector(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedInstanceEncryptionProtector>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedInstanceEncryptionProtectorRestClient.ListByInstanceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceEncryptionProtector(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of managed instance encryption protectors
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector
        /// Operation Id: ManagedInstanceEncryptionProtectors_ListByInstance
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedInstanceEncryptionProtector" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedInstanceEncryptionProtector> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ManagedInstanceEncryptionProtector> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedInstanceEncryptionProtectorRestClient.ListByInstance(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceEncryptionProtector(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedInstanceEncryptionProtector> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedInstanceEncryptionProtectorRestClient.ListByInstanceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceEncryptionProtector(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_Get
        /// </summary>
        /// <param name="encryptionProtectorName"> The name of the encryption protector to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<bool>> ExistsAsync(EncryptionProtectorName encryptionProtectorName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(encryptionProtectorName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_Get
        /// </summary>
        /// <param name="encryptionProtectorName"> The name of the encryption protector to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(EncryptionProtectorName encryptionProtectorName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(encryptionProtectorName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_Get
        /// </summary>
        /// <param name="encryptionProtectorName"> The name of the encryption protector to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagedInstanceEncryptionProtector>> GetIfExistsAsync(EncryptionProtectorName encryptionProtectorName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managedInstanceEncryptionProtectorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionProtectorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ManagedInstanceEncryptionProtector>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceEncryptionProtector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_Get
        /// </summary>
        /// <param name="encryptionProtectorName"> The name of the encryption protector to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagedInstanceEncryptionProtector> GetIfExists(EncryptionProtectorName encryptionProtectorName, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtectorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managedInstanceEncryptionProtectorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, encryptionProtectorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ManagedInstanceEncryptionProtector>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceEncryptionProtector(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagedInstanceEncryptionProtector> IEnumerable<ManagedInstanceEncryptionProtector>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagedInstanceEncryptionProtector> IAsyncEnumerable<ManagedInstanceEncryptionProtector>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
