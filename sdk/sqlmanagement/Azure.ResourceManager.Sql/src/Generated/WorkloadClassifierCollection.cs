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
    /// <summary> A class representing collection of WorkloadClassifier and their operations over its parent. </summary>
    public partial class WorkloadClassifierCollection : ArmCollection, IEnumerable<WorkloadClassifier>, IAsyncEnumerable<WorkloadClassifier>
    {
        private readonly ClientDiagnostics _workloadClassifierClientDiagnostics;
        private readonly WorkloadClassifiersRestOperations _workloadClassifierRestClient;

        /// <summary> Initializes a new instance of the <see cref="WorkloadClassifierCollection"/> class for mocking. </summary>
        protected WorkloadClassifierCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="WorkloadClassifierCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal WorkloadClassifierCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _workloadClassifierClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", WorkloadClassifier.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(WorkloadClassifier.ResourceType, out string workloadClassifierApiVersion);
            _workloadClassifierRestClient = new WorkloadClassifiersRestOperations(_workloadClassifierClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, workloadClassifierApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != WorkloadGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, WorkloadGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a workload classifier.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers/{workloadClassifierName}
        /// Operation Id: WorkloadClassifiers_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="workloadClassifierName"> The name of the workload classifier to create/update. </param>
        /// <param name="parameters"> The properties of the workload classifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workloadClassifierName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workloadClassifierName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<WorkloadClassifier>> CreateOrUpdateAsync(bool waitForCompletion, string workloadClassifierName, WorkloadClassifierData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workloadClassifierName, nameof(workloadClassifierName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _workloadClassifierRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, workloadClassifierName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<WorkloadClassifier>(new WorkloadClassifierOperationSource(Client), _workloadClassifierClientDiagnostics, Pipeline, _workloadClassifierRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, workloadClassifierName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a workload classifier.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers/{workloadClassifierName}
        /// Operation Id: WorkloadClassifiers_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="workloadClassifierName"> The name of the workload classifier to create/update. </param>
        /// <param name="parameters"> The properties of the workload classifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workloadClassifierName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workloadClassifierName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<WorkloadClassifier> CreateOrUpdate(bool waitForCompletion, string workloadClassifierName, WorkloadClassifierData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workloadClassifierName, nameof(workloadClassifierName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _workloadClassifierRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, workloadClassifierName, parameters, cancellationToken);
                var operation = new SqlArmOperation<WorkloadClassifier>(new WorkloadClassifierOperationSource(Client), _workloadClassifierClientDiagnostics, Pipeline, _workloadClassifierRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, workloadClassifierName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a workload classifier
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers/{workloadClassifierName}
        /// Operation Id: WorkloadClassifiers_Get
        /// </summary>
        /// <param name="workloadClassifierName"> The name of the workload classifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workloadClassifierName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workloadClassifierName"/> is null. </exception>
        public async virtual Task<Response<WorkloadClassifier>> GetAsync(string workloadClassifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workloadClassifierName, nameof(workloadClassifierName));

            using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.Get");
            scope.Start();
            try
            {
                var response = await _workloadClassifierRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, workloadClassifierName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _workloadClassifierClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new WorkloadClassifier(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a workload classifier
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers/{workloadClassifierName}
        /// Operation Id: WorkloadClassifiers_Get
        /// </summary>
        /// <param name="workloadClassifierName"> The name of the workload classifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workloadClassifierName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workloadClassifierName"/> is null. </exception>
        public virtual Response<WorkloadClassifier> Get(string workloadClassifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workloadClassifierName, nameof(workloadClassifierName));

            using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.Get");
            scope.Start();
            try
            {
                var response = _workloadClassifierRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, workloadClassifierName, cancellationToken);
                if (response.Value == null)
                    throw _workloadClassifierClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new WorkloadClassifier(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the list of workload classifiers for a workload group
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers
        /// Operation Id: WorkloadClassifiers_ListByWorkloadGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="WorkloadClassifier" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<WorkloadClassifier> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<WorkloadClassifier>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _workloadClassifierRestClient.ListByWorkloadGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new WorkloadClassifier(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<WorkloadClassifier>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _workloadClassifierRestClient.ListByWorkloadGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new WorkloadClassifier(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets the list of workload classifiers for a workload group
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers
        /// Operation Id: WorkloadClassifiers_ListByWorkloadGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="WorkloadClassifier" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<WorkloadClassifier> GetAll(CancellationToken cancellationToken = default)
        {
            Page<WorkloadClassifier> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _workloadClassifierRestClient.ListByWorkloadGroup(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new WorkloadClassifier(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<WorkloadClassifier> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _workloadClassifierRestClient.ListByWorkloadGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new WorkloadClassifier(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers/{workloadClassifierName}
        /// Operation Id: WorkloadClassifiers_Get
        /// </summary>
        /// <param name="workloadClassifierName"> The name of the workload classifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workloadClassifierName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workloadClassifierName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string workloadClassifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workloadClassifierName, nameof(workloadClassifierName));

            using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(workloadClassifierName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers/{workloadClassifierName}
        /// Operation Id: WorkloadClassifiers_Get
        /// </summary>
        /// <param name="workloadClassifierName"> The name of the workload classifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workloadClassifierName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workloadClassifierName"/> is null. </exception>
        public virtual Response<bool> Exists(string workloadClassifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workloadClassifierName, nameof(workloadClassifierName));

            using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(workloadClassifierName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers/{workloadClassifierName}
        /// Operation Id: WorkloadClassifiers_Get
        /// </summary>
        /// <param name="workloadClassifierName"> The name of the workload classifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workloadClassifierName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workloadClassifierName"/> is null. </exception>
        public async virtual Task<Response<WorkloadClassifier>> GetIfExistsAsync(string workloadClassifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workloadClassifierName, nameof(workloadClassifierName));

            using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _workloadClassifierRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, workloadClassifierName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<WorkloadClassifier>(null, response.GetRawResponse());
                return Response.FromValue(new WorkloadClassifier(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/workloadGroups/{workloadGroupName}/workloadClassifiers/{workloadClassifierName}
        /// Operation Id: WorkloadClassifiers_Get
        /// </summary>
        /// <param name="workloadClassifierName"> The name of the workload classifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="workloadClassifierName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workloadClassifierName"/> is null. </exception>
        public virtual Response<WorkloadClassifier> GetIfExists(string workloadClassifierName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(workloadClassifierName, nameof(workloadClassifierName));

            using var scope = _workloadClassifierClientDiagnostics.CreateScope("WorkloadClassifierCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _workloadClassifierRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, workloadClassifierName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<WorkloadClassifier>(null, response.GetRawResponse());
                return Response.FromValue(new WorkloadClassifier(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<WorkloadClassifier> IEnumerable<WorkloadClassifier>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<WorkloadClassifier> IAsyncEnumerable<WorkloadClassifier>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
