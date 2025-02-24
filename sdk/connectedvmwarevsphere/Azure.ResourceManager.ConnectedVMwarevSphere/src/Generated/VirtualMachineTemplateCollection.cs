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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ConnectedVMwarevSphere
{
    /// <summary> A class representing collection of VirtualMachineTemplate and their operations over its parent. </summary>
    public partial class VirtualMachineTemplateCollection : ArmCollection, IEnumerable<VirtualMachineTemplate>, IAsyncEnumerable<VirtualMachineTemplate>
    {
        private readonly ClientDiagnostics _virtualMachineTemplateClientDiagnostics;
        private readonly VirtualMachineTemplatesRestOperations _virtualMachineTemplateRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineTemplateCollection"/> class for mocking. </summary>
        protected VirtualMachineTemplateCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineTemplateCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualMachineTemplateCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualMachineTemplateClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ConnectedVMwarevSphere", VirtualMachineTemplate.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(VirtualMachineTemplate.ResourceType, out string virtualMachineTemplateApiVersion);
            _virtualMachineTemplateRestClient = new VirtualMachineTemplatesRestOperations(_virtualMachineTemplateClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualMachineTemplateApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create Or Update virtual machine template.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Create
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="body"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public async virtual Task<ArmOperation<VirtualMachineTemplate>> CreateOrUpdateAsync(bool waitForCompletion, string virtualMachineTemplateName, VirtualMachineTemplateData body = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualMachineTemplateRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, body, cancellationToken).ConfigureAwait(false);
                var operation = new ConnectedVMwarevSphereArmOperation<VirtualMachineTemplate>(new VirtualMachineTemplateOperationSource(Client), _virtualMachineTemplateClientDiagnostics, Pipeline, _virtualMachineTemplateRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, body).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Create Or Update virtual machine template.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Create
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="body"> Request payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual ArmOperation<VirtualMachineTemplate> CreateOrUpdate(bool waitForCompletion, string virtualMachineTemplateName, VirtualMachineTemplateData body = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualMachineTemplateRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, body, cancellationToken);
                var operation = new ConnectedVMwarevSphereArmOperation<VirtualMachineTemplate>(new VirtualMachineTemplateOperationSource(Client), _virtualMachineTemplateClientDiagnostics, Pipeline, _virtualMachineTemplateRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, body).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Implements virtual machine template GET method.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineTemplate>> GetAsync(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualMachineTemplateRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualMachineTemplateClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualMachineTemplate(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Implements virtual machine template GET method.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual Response<VirtualMachineTemplate> Get(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualMachineTemplateRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, cancellationToken);
                if (response.Value == null)
                    throw _virtualMachineTemplateClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualMachineTemplate(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List of virtualMachineTemplates in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates
        /// Operation Id: VirtualMachineTemplates_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualMachineTemplate" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineTemplate> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualMachineTemplate>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineTemplateRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineTemplate(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualMachineTemplate>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualMachineTemplateRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineTemplate(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List of virtualMachineTemplates in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates
        /// Operation Id: VirtualMachineTemplates_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualMachineTemplate" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineTemplate> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualMachineTemplate> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineTemplateRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineTemplate(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualMachineTemplate> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualMachineTemplateRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineTemplate(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(virtualMachineTemplateName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual Response<bool> Exists(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(virtualMachineTemplateName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public async virtual Task<Response<VirtualMachineTemplate>> GetIfExistsAsync(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualMachineTemplateRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineTemplate>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineTemplate(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/{virtualMachineTemplateName}
        /// Operation Id: VirtualMachineTemplates_Get
        /// </summary>
        /// <param name="virtualMachineTemplateName"> Name of the virtual machine template resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineTemplateName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineTemplateName"/> is null. </exception>
        public virtual Response<VirtualMachineTemplate> GetIfExists(string virtualMachineTemplateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualMachineTemplateName, nameof(virtualMachineTemplateName));

            using var scope = _virtualMachineTemplateClientDiagnostics.CreateScope("VirtualMachineTemplateCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualMachineTemplateRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineTemplateName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualMachineTemplate>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualMachineTemplate(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualMachineTemplate> IEnumerable<VirtualMachineTemplate>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualMachineTemplate> IAsyncEnumerable<VirtualMachineTemplate>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
