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

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of HostNameBinding and their operations over its parent. </summary>
    public partial class SiteHostNameBindingCollection : ArmCollection, IEnumerable<SiteHostNameBinding>, IAsyncEnumerable<SiteHostNameBinding>
    {
        private readonly ClientDiagnostics _siteHostNameBindingWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteHostNameBindingWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteHostNameBindingCollection"/> class for mocking. </summary>
        protected SiteHostNameBindingCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteHostNameBindingCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteHostNameBindingCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteHostNameBindingWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteHostNameBinding.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(SiteHostNameBinding.ResourceType, out string siteHostNameBindingWebAppsApiVersion);
            _siteHostNameBindingWebAppsRestClient = new WebAppsRestOperations(_siteHostNameBindingWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteHostNameBindingWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != WebSite.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, WebSite.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Creates a hostname binding for an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}
        /// Operation Id: WebApps_CreateOrUpdateHostNameBinding
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="hostName"> Hostname in the hostname binding. </param>
        /// <param name="hostNameBinding"> Binding details. This is the JSON representation of a HostNameBinding object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> or <paramref name="hostNameBinding"/> is null. </exception>
        public async virtual Task<ArmOperation<SiteHostNameBinding>> CreateOrUpdateAsync(bool waitForCompletion, string hostName, HostNameBindingData hostNameBinding, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));
            if (hostNameBinding == null)
            {
                throw new ArgumentNullException(nameof(hostNameBinding));
            }

            using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _siteHostNameBindingWebAppsRestClient.CreateOrUpdateHostNameBindingAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, hostNameBinding, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<SiteHostNameBinding>(Response.FromValue(new SiteHostNameBinding(Client, response), response.GetRawResponse()));
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
        /// Description for Creates a hostname binding for an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}
        /// Operation Id: WebApps_CreateOrUpdateHostNameBinding
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="hostName"> Hostname in the hostname binding. </param>
        /// <param name="hostNameBinding"> Binding details. This is the JSON representation of a HostNameBinding object. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> or <paramref name="hostNameBinding"/> is null. </exception>
        public virtual ArmOperation<SiteHostNameBinding> CreateOrUpdate(bool waitForCompletion, string hostName, HostNameBindingData hostNameBinding, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));
            if (hostNameBinding == null)
            {
                throw new ArgumentNullException(nameof(hostNameBinding));
            }

            using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _siteHostNameBindingWebAppsRestClient.CreateOrUpdateHostNameBinding(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, hostNameBinding, cancellationToken);
                var operation = new AppServiceArmOperation<SiteHostNameBinding>(Response.FromValue(new SiteHostNameBinding(Client, response), response.GetRawResponse()));
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
        /// Description for Get the named hostname binding for an app (or deployment slot, if specified).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}
        /// Operation Id: WebApps_GetHostNameBinding
        /// </summary>
        /// <param name="hostName"> Hostname in the hostname binding. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public async virtual Task<Response<SiteHostNameBinding>> GetAsync(string hostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteHostNameBindingWebAppsRestClient.GetHostNameBindingAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteHostNameBindingWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteHostNameBinding(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get the named hostname binding for an app (or deployment slot, if specified).
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}
        /// Operation Id: WebApps_GetHostNameBinding
        /// </summary>
        /// <param name="hostName"> Hostname in the hostname binding. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual Response<SiteHostNameBinding> Get(string hostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.Get");
            scope.Start();
            try
            {
                var response = _siteHostNameBindingWebAppsRestClient.GetHostNameBinding(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, cancellationToken);
                if (response.Value == null)
                    throw _siteHostNameBindingWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteHostNameBinding(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get hostname bindings for an app or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings
        /// Operation Id: WebApps_ListHostNameBindings
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteHostNameBinding" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteHostNameBinding> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteHostNameBinding>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteHostNameBindingWebAppsRestClient.ListHostNameBindingsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteHostNameBinding(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteHostNameBinding>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteHostNameBindingWebAppsRestClient.ListHostNameBindingsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteHostNameBinding(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Get hostname bindings for an app or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings
        /// Operation Id: WebApps_ListHostNameBindings
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteHostNameBinding" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteHostNameBinding> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteHostNameBinding> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteHostNameBindingWebAppsRestClient.ListHostNameBindings(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteHostNameBinding(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteHostNameBinding> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteHostNameBindingWebAppsRestClient.ListHostNameBindingsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteHostNameBinding(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}
        /// Operation Id: WebApps_GetHostNameBinding
        /// </summary>
        /// <param name="hostName"> Hostname in the hostname binding. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string hostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(hostName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}
        /// Operation Id: WebApps_GetHostNameBinding
        /// </summary>
        /// <param name="hostName"> Hostname in the hostname binding. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual Response<bool> Exists(string hostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(hostName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}
        /// Operation Id: WebApps_GetHostNameBinding
        /// </summary>
        /// <param name="hostName"> Hostname in the hostname binding. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public async virtual Task<Response<SiteHostNameBinding>> GetIfExistsAsync(string hostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteHostNameBindingWebAppsRestClient.GetHostNameBindingAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteHostNameBinding>(null, response.GetRawResponse());
                return Response.FromValue(new SiteHostNameBinding(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostNameBindings/{hostName}
        /// Operation Id: WebApps_GetHostNameBinding
        /// </summary>
        /// <param name="hostName"> Hostname in the hostname binding. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="hostName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="hostName"/> is null. </exception>
        public virtual Response<SiteHostNameBinding> GetIfExists(string hostName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hostName, nameof(hostName));

            using var scope = _siteHostNameBindingWebAppsClientDiagnostics.CreateScope("SiteHostNameBindingCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteHostNameBindingWebAppsRestClient.GetHostNameBinding(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, hostName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteHostNameBinding>(null, response.GetRawResponse());
                return Response.FromValue(new SiteHostNameBinding(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteHostNameBinding> IEnumerable<SiteHostNameBinding>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteHostNameBinding> IAsyncEnumerable<SiteHostNameBinding>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
