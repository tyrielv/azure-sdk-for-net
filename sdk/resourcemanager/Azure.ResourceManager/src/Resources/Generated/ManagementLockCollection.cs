// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of ManagementLock and their operations over its parent. </summary>
    public partial class ManagementLockCollection : ArmCollection, IEnumerable<ManagementLock>, IAsyncEnumerable<ManagementLock>
    {
        private readonly ClientDiagnostics _managementLockClientDiagnostics;
        private readonly ManagementLocksRestOperations _managementLockRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagementLockCollection"/> class for mocking. </summary>
        protected ManagementLockCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagementLockCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagementLockCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managementLockClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", ManagementLock.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ManagementLock.ResourceType, out string managementLockApiVersion);
            _managementLockRestClient = new ManagementLocksRestOperations(_managementLockClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managementLockApiVersion);
        }

        /// <summary>
        /// Create or update a management lock by scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_CreateOrUpdateByScope
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="parameters"> Create or update management lock parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ManagementLock>> CreateOrUpdateAsync(bool waitForCompletion, string lockName, ManagementLockData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _managementLockRestClient.CreateOrUpdateByScopeAsync(Id, lockName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<ManagementLock>(Response.FromValue(new ManagementLock(Client, response), response.GetRawResponse()));
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
        /// Create or update a management lock by scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_CreateOrUpdateByScope
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="parameters"> Create or update management lock parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ManagementLock> CreateOrUpdate(bool waitForCompletion, string lockName, ManagementLockData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _managementLockRestClient.CreateOrUpdateByScope(Id, lockName, parameters, cancellationToken);
                var operation = new ResourcesArmOperation<ManagementLock>(Response.FromValue(new ManagementLock(Client, response), response.GetRawResponse()));
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
        /// Get a management lock by scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public async virtual Task<Response<ManagementLock>> GetAsync(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.Get");
            scope.Start();
            try
            {
                var response = await _managementLockRestClient.GetByScopeAsync(Id, lockName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _managementLockClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ManagementLock(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a management lock by scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public virtual Response<ManagementLock> Get(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.Get");
            scope.Start();
            try
            {
                var response = _managementLockRestClient.GetByScope(Id, lockName, cancellationToken);
                if (response.Value == null)
                    throw _managementLockClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagementLock(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all the management locks for a scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks
        /// Operation Id: ManagementLocks_ListByScope
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagementLock" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagementLock> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagementLock>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managementLockRestClient.ListByScopeAsync(Id, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLock(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagementLock>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managementLockRestClient.ListByScopeNextPageAsync(nextLink, Id, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLock(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the management locks for a scope.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks
        /// Operation Id: ManagementLocks_ListByScope
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagementLock" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagementLock> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagementLock> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managementLockRestClient.ListByScope(Id, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLock(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagementLock> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managementLockRestClient.ListByScopeNextPage(nextLink, Id, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagementLock(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(lockName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public virtual Response<bool> Exists(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(lockName, cancellationToken: cancellationToken);
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
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public async virtual Task<Response<ManagementLock>> GetIfExistsAsync(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managementLockRestClient.GetByScopeAsync(Id, lockName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ManagementLock>(null, response.GetRawResponse());
                return Response.FromValue(new ManagementLock(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /{scope}/providers/Microsoft.Authorization/locks/{lockName}
        /// Operation Id: ManagementLocks_GetByScope
        /// </summary>
        /// <param name="lockName"> The name of lock. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="lockName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="lockName"/> is null. </exception>
        public virtual Response<ManagementLock> GetIfExists(string lockName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(lockName, nameof(lockName));

            using var scope = _managementLockClientDiagnostics.CreateScope("ManagementLockCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managementLockRestClient.GetByScope(Id, lockName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ManagementLock>(null, response.GetRawResponse());
                return Response.FromValue(new ManagementLock(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagementLock> IEnumerable<ManagementLock>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagementLock> IAsyncEnumerable<ManagementLock>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
