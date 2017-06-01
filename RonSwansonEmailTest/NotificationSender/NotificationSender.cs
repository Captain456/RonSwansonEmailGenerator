// <summary>
// This file defines the NotificationSender class.
// </summary>
// <copyright file="NotificationSender.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.NotificationSender
{
    using System;
    using RonSwansonEmailTest.Notification;

    /// <summary>
    /// Wrapper class for the SendNotification method
    /// </summary>
    public static class NotificationSender
    {
        #region <Fields>
        // No fields are defined
        #endregion

        #region <Constructors>
        // No constructors are defined
        #endregion

        #region <Enumerations>
        // No enumerations are defined
        #endregion

        #region <Events>
        // No events are defined
        #endregion

        #region <Properties>
        // No properties are defined
        #endregion

        #region Public Methods

        /// <summary>
        /// Sends the notification
        /// </summary>
        /// <param name="notification">The notification to send</param>
        public static void SendNotification(INotification notification)
        {
            notification.Send();
        }

        #endregion

        #region <Protected Methods>
        // No protected methods are defined
        #endregion

        #region <Private Methods>
        // No private methods are defined
        #endregion
    }
}
