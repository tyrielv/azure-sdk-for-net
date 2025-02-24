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

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of SyncMember and their operations over its parent. </summary>
    public partial class SyncMemberCollection : ArmCollection, IEnumerable<SyncMember>, IAsyncEnumerable<SyncMember>
    {
        private readonly ClientDiagnostics _syncMemberClientDiagnostics;
        private readonly SyncMembersRestOperations _syncMemberRestClient;

        /// <summary> Initializes a new instance of the <see cref="SyncMemberCollection"/> class for mocking. </summary>
        protected SyncMemberCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SyncMemberCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SyncMemberCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _syncMemberClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", SyncMember.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(SyncMember.ResourceType, out string syncMemberApiVersion);
            _syncMemberRestClient = new SyncMembersRestOperations(_syncMemberClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, syncMemberApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SyncGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SyncGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a sync member.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers/{syncMemberName}
        /// Operation Id: SyncMembers_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="syncMemberName"> The name of the sync member. </param>
        /// <param name="parameters"> The requested sync member resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="syncMemberName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="syncMemberName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<SyncMember>> CreateOrUpdateAsync(bool waitForCompletion, string syncMemberName, SyncMemberData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(syncMemberName, nameof(syncMemberName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _syncMemberRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, syncMemberName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<SyncMember>(new SyncMemberOperationSource(Client), _syncMemberClientDiagnostics, Pipeline, _syncMemberRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, syncMemberName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a sync member.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers/{syncMemberName}
        /// Operation Id: SyncMembers_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="syncMemberName"> The name of the sync member. </param>
        /// <param name="parameters"> The requested sync member resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="syncMemberName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="syncMemberName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<SyncMember> CreateOrUpdate(bool waitForCompletion, string syncMemberName, SyncMemberData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(syncMemberName, nameof(syncMemberName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _syncMemberRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, syncMemberName, parameters, cancellationToken);
                var operation = new SqlArmOperation<SyncMember>(new SyncMemberOperationSource(Client), _syncMemberClientDiagnostics, Pipeline, _syncMemberRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, syncMemberName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a sync member.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers/{syncMemberName}
        /// Operation Id: SyncMembers_Get
        /// </summary>
        /// <param name="syncMemberName"> The name of the sync member. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="syncMemberName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="syncMemberName"/> is null. </exception>
        public async virtual Task<Response<SyncMember>> GetAsync(string syncMemberName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(syncMemberName, nameof(syncMemberName));

            using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.Get");
            scope.Start();
            try
            {
                var response = await _syncMemberRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, syncMemberName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _syncMemberClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SyncMember(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a sync member.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers/{syncMemberName}
        /// Operation Id: SyncMembers_Get
        /// </summary>
        /// <param name="syncMemberName"> The name of the sync member. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="syncMemberName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="syncMemberName"/> is null. </exception>
        public virtual Response<SyncMember> Get(string syncMemberName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(syncMemberName, nameof(syncMemberName));

            using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.Get");
            scope.Start();
            try
            {
                var response = _syncMemberRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, syncMemberName, cancellationToken);
                if (response.Value == null)
                    throw _syncMemberClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SyncMember(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists sync members in the given sync group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers
        /// Operation Id: SyncMembers_ListBySyncGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SyncMember" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SyncMember> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SyncMember>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _syncMemberRestClient.ListBySyncGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SyncMember(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SyncMember>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _syncMemberRestClient.ListBySyncGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SyncMember(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists sync members in the given sync group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers
        /// Operation Id: SyncMembers_ListBySyncGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SyncMember" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SyncMember> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SyncMember> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _syncMemberRestClient.ListBySyncGroup(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SyncMember(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SyncMember> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _syncMemberRestClient.ListBySyncGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SyncMember(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers/{syncMemberName}
        /// Operation Id: SyncMembers_Get
        /// </summary>
        /// <param name="syncMemberName"> The name of the sync member. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="syncMemberName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="syncMemberName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string syncMemberName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(syncMemberName, nameof(syncMemberName));

            using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(syncMemberName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers/{syncMemberName}
        /// Operation Id: SyncMembers_Get
        /// </summary>
        /// <param name="syncMemberName"> The name of the sync member. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="syncMemberName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="syncMemberName"/> is null. </exception>
        public virtual Response<bool> Exists(string syncMemberName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(syncMemberName, nameof(syncMemberName));

            using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(syncMemberName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers/{syncMemberName}
        /// Operation Id: SyncMembers_Get
        /// </summary>
        /// <param name="syncMemberName"> The name of the sync member. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="syncMemberName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="syncMemberName"/> is null. </exception>
        public async virtual Task<Response<SyncMember>> GetIfExistsAsync(string syncMemberName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(syncMemberName, nameof(syncMemberName));

            using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _syncMemberRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, syncMemberName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SyncMember>(null, response.GetRawResponse());
                return Response.FromValue(new SyncMember(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/syncMembers/{syncMemberName}
        /// Operation Id: SyncMembers_Get
        /// </summary>
        /// <param name="syncMemberName"> The name of the sync member. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="syncMemberName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="syncMemberName"/> is null. </exception>
        public virtual Response<SyncMember> GetIfExists(string syncMemberName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(syncMemberName, nameof(syncMemberName));

            using var scope = _syncMemberClientDiagnostics.CreateScope("SyncMemberCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _syncMemberRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, syncMemberName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SyncMember>(null, response.GetRawResponse());
                return Response.FromValue(new SyncMember(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SyncMember> IEnumerable<SyncMember>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SyncMember> IAsyncEnumerable<SyncMember>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
