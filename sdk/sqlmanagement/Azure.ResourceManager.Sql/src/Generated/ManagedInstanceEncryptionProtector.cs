// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
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
    /// <summary> A Class representing a ManagedInstanceEncryptionProtector along with the instance operations that can be performed on it. </summary>
    public partial class ManagedInstanceEncryptionProtector : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ManagedInstanceEncryptionProtector"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string encryptionProtectorName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _managedInstanceEncryptionProtectorClientDiagnostics;
        private readonly ManagedInstanceEncryptionProtectorsRestOperations _managedInstanceEncryptionProtectorRestClient;
        private readonly ManagedInstanceEncryptionProtectorData _data;

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceEncryptionProtector"/> class for mocking. </summary>
        protected ManagedInstanceEncryptionProtector()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ManagedInstanceEncryptionProtector"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ManagedInstanceEncryptionProtector(ArmClient client, ManagedInstanceEncryptionProtectorData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceEncryptionProtector"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagedInstanceEncryptionProtector(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedInstanceEncryptionProtectorClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(ResourceType, out string managedInstanceEncryptionProtectorApiVersion);
            _managedInstanceEncryptionProtectorRestClient = new ManagedInstanceEncryptionProtectorsRestOperations(_managedInstanceEncryptionProtectorClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedInstanceEncryptionProtectorApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/managedInstances/encryptionProtector";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ManagedInstanceEncryptionProtectorData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a managed instance encryption protector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}
        /// Operation Id: ManagedInstanceEncryptionProtectors_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ManagedInstanceEncryptionProtector>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtector.Get");
            scope.Start();
            try
            {
                var response = await _managedInstanceEncryptionProtectorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagedInstanceEncryptionProtector> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtector.Get");
            scope.Start();
            try
            {
                var response = _managedInstanceEncryptionProtectorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
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
        /// Revalidates an existing encryption protector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}/revalidate
        /// Operation Id: ManagedInstanceEncryptionProtectors_Revalidate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> RevalidateAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtector.Revalidate");
            scope.Start();
            try
            {
                var response = await _managedInstanceEncryptionProtectorRestClient.RevalidateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation(_managedInstanceEncryptionProtectorClientDiagnostics, Pipeline, _managedInstanceEncryptionProtectorRestClient.CreateRevalidateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Revalidates an existing encryption protector.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/encryptionProtector/{encryptionProtectorName}/revalidate
        /// Operation Id: ManagedInstanceEncryptionProtectors_Revalidate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Revalidate(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _managedInstanceEncryptionProtectorClientDiagnostics.CreateScope("ManagedInstanceEncryptionProtector.Revalidate");
            scope.Start();
            try
            {
                var response = _managedInstanceEncryptionProtectorRestClient.Revalidate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SqlArmOperation(_managedInstanceEncryptionProtectorClientDiagnostics, Pipeline, _managedInstanceEncryptionProtectorRestClient.CreateRevalidateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
