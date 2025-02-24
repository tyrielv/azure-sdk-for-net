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

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of Provider and their operations over its parent. </summary>
    public partial class ProviderCollection : ArmCollection, IEnumerable<Provider>, IAsyncEnumerable<Provider>
    {
        private readonly ClientDiagnostics _providerClientDiagnostics;
        private readonly ProvidersRestOperations _providerRestClient;

        /// <summary> Initializes a new instance of the <see cref="ProviderCollection"/> class for mocking. </summary>
        protected ProviderCollection()
        {
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the specified resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
        /// Operation Id: Providers_Get
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public async virtual Task<Response<Provider>> GetAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.Get");
            scope.Start();
            try
            {
                var response = await _providerRestClient.GetAsync(Id.SubscriptionId, resourceProviderNamespace, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _providerClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Provider(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified resource provider.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
        /// Operation Id: Providers_Get
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual Response<Provider> Get(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.Get");
            scope.Start();
            try
            {
                var response = _providerRestClient.Get(Id.SubscriptionId, resourceProviderNamespace, expand, cancellationToken);
                if (response.Value == null)
                    throw _providerClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Provider(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all resource providers for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers
        /// Operation Id: Providers_List
        /// </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Provider" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Provider> GetAllAsync(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<Provider>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _providerRestClient.ListAsync(Id.SubscriptionId, top, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Provider(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Provider>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _providerRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, top, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Provider(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all resource providers for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers
        /// Operation Id: Providers_List
        /// </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all deployments. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Provider" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Provider> GetAll(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<Provider> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _providerRestClient.List(Id.SubscriptionId, top, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Provider(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Provider> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _providerRestClient.ListNextPage(nextLink, Id.SubscriptionId, top, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Provider(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
        /// Operation Id: Providers_Get
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(resourceProviderNamespace, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
        /// Operation Id: Providers_Get
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual Response<bool> Exists(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(resourceProviderNamespace, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
        /// Operation Id: Providers_Get
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public async virtual Task<Response<Provider>> GetIfExistsAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _providerRestClient.GetAsync(Id.SubscriptionId, resourceProviderNamespace, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<Provider>(null, response.GetRawResponse());
                return Response.FromValue(new Provider(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/{resourceProviderNamespace}
        /// Operation Id: Providers_Get
        /// </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderNamespace"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public virtual Response<Provider> GetIfExists(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));

            using var scope = _providerClientDiagnostics.CreateScope("ProviderCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _providerRestClient.Get(Id.SubscriptionId, resourceProviderNamespace, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<Provider>(null, response.GetRawResponse());
                return Response.FromValue(new Provider(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<Provider> IEnumerable<Provider>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<Provider> IAsyncEnumerable<Provider>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
