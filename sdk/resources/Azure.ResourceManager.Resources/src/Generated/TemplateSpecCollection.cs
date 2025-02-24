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
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of TemplateSpec and their operations over its parent. </summary>
    public partial class TemplateSpecCollection : ArmCollection, IEnumerable<TemplateSpec>, IAsyncEnumerable<TemplateSpec>
    {
        private readonly ClientDiagnostics _templateSpecClientDiagnostics;
        private readonly TemplateSpecsRestOperations _templateSpecRestClient;

        /// <summary> Initializes a new instance of the <see cref="TemplateSpecCollection"/> class for mocking. </summary>
        protected TemplateSpecCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TemplateSpecCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal TemplateSpecCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _templateSpecClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", TemplateSpec.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(TemplateSpec.ResourceType, out string templateSpecApiVersion);
            _templateSpecRestClient = new TemplateSpecsRestOperations(_templateSpecClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, templateSpecApiVersion);
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
        /// Creates or updates a Template Spec.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="templateSpec"> Template Spec supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> or <paramref name="templateSpec"/> is null. </exception>
        public async virtual Task<ArmOperation<TemplateSpec>> CreateOrUpdateAsync(bool waitForCompletion, string templateSpecName, TemplateSpecData templateSpec, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));
            if (templateSpec == null)
            {
                throw new ArgumentNullException(nameof(templateSpec));
            }

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _templateSpecRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, templateSpec, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<TemplateSpec>(Response.FromValue(new TemplateSpec(Client, response), response.GetRawResponse()));
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
        /// Creates or updates a Template Spec.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="templateSpec"> Template Spec supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> or <paramref name="templateSpec"/> is null. </exception>
        public virtual ArmOperation<TemplateSpec> CreateOrUpdate(bool waitForCompletion, string templateSpecName, TemplateSpecData templateSpec, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));
            if (templateSpec == null)
            {
                throw new ArgumentNullException(nameof(templateSpec));
            }

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _templateSpecRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, templateSpec, cancellationToken);
                var operation = new ResourcesArmOperation<TemplateSpec>(Response.FromValue(new TemplateSpec(Client, response), response.GetRawResponse()));
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
        /// Gets a Template Spec with a given name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public async virtual Task<Response<TemplateSpec>> GetAsync(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.Get");
            scope.Start();
            try
            {
                var response = await _templateSpecRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _templateSpecClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new TemplateSpec(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a Template Spec with a given name.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual Response<TemplateSpec> Get(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.Get");
            scope.Start();
            try
            {
                var response = _templateSpecRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, expand, cancellationToken);
                if (response.Value == null)
                    throw _templateSpecClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new TemplateSpec(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the Template Specs within the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs
        /// Operation Id: TemplateSpecs_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TemplateSpec" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TemplateSpec> GetAllAsync(TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TemplateSpec>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _templateSpecRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpec(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TemplateSpec>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _templateSpecRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpec(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the Template Specs within the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs
        /// Operation Id: TemplateSpecs_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TemplateSpec" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TemplateSpec> GetAll(TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Page<TemplateSpec> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _templateSpecRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpec(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TemplateSpec> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _templateSpecRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpec(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(templateSpecName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual Response<bool> Exists(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(templateSpecName, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public async virtual Task<Response<TemplateSpec>> GetIfExistsAsync(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _templateSpecRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<TemplateSpec>(null, response.GetRawResponse());
                return Response.FromValue(new TemplateSpec(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}
        /// Operation Id: TemplateSpecs_Get
        /// </summary>
        /// <param name="templateSpecName"> Name of the Template Spec. </param>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="templateSpecName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="templateSpecName"/> is null. </exception>
        public virtual Response<TemplateSpec> GetIfExists(string templateSpecName, TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(templateSpecName, nameof(templateSpecName));

            using var scope = _templateSpecClientDiagnostics.CreateScope("TemplateSpecCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _templateSpecRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, templateSpecName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<TemplateSpec>(null, response.GetRawResponse());
                return Response.FromValue(new TemplateSpec(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<TemplateSpec> IEnumerable<TemplateSpec>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TemplateSpec> IAsyncEnumerable<TemplateSpec>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
