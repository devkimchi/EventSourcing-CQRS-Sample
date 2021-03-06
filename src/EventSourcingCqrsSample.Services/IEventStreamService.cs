﻿using System;
using System.Threading.Tasks;

using EventSourcingCqrsSample.Models.Requests;
using EventSourcingCqrsSample.Models.Responses;

namespace EventSourcingCqrsSample.Services
{
    /// <summary>
    /// This provides interfaces to the <see cref="EventStreamService" /> class.
    /// </summary>
    public interface IEventStreamService : IDisposable
    {
        /// <summary>
        /// Creates a new event stream asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="EventStreamCreateRequest" /> instance.</param>
        /// <returns>Returns the <see cref="EventStreamCreateResponse" /> instance.</returns>
        Task<EventStreamCreateResponse> CreateEventStreamAsync(EventStreamCreateRequest request);

        /// <summary>
        /// Changes salutation asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SalutationChangeRequest" /> instance.</param>
        /// <returns>Returns the <see cref="SalutationChangeResponse" /> instance.</returns>
        Task<SalutationChangeResponse> ChangeSalutationAsync(SalutationChangeRequest request);

        /// <summary>
        /// Changes username asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="UsernameChangeRequest" /> instance.</param>
        /// <returns>Returns the <see cref="UsernameChangeResponse" /> instance.</returns>
        Task<UsernameChangeResponse> ChangeUsernameAsync(UsernameChangeRequest request);

        /// <summary>
        /// Changes email asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="EmailChangeRequest" /> instance.</param>
        /// <returns>Returns the <see cref="EmailChangeResponse" /> instance.</returns>
        Task<EmailChangeResponse> ChangeEmailAsync(EmailChangeRequest request);

        /// <summary>
        /// Creates user asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> instance.</param>
        /// <returns>Returns the <see cref="UserCreateResponse" /> instance.</returns>
        Task<UserCreateResponse> CreateUserAsync(UserCreateRequest request);
    }
}