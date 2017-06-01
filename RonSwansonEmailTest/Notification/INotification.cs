// <summary>
// This file defines the INotification interface.
// </summary>
// <copyright file="INotification.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.Notification
{
    using System;

    /// <summary>
    /// Provides an interface for a notification that can be sent out
    /// </summary>
    public interface INotification
    {
        #region <Events>
        // No events are defined
        #endregion

        #region Properties

        /// <summary>
        /// The notification message to be sent
        /// </summary>
        string Message { set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sends the notification
        /// </summary>
        void Send();

        #endregion
    }
}
