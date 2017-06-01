// <summary>
// This file defines the EmailNotification class.
// </summary>
// <copyright file="EmailNotification.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.Notification
{
    using System;
    using System.Net.Mail;

    /// <summary>
    /// Implementation of the <see cref="INotification" /> interface for an email message.
    /// </summary>
    public class EmailNotification : INotification
    {
        #region Fields

        /// <summary>
        /// The SMTP client that the messages will be sent from.
        /// </summary>
        private SmtpClient smtpClient;

        /// <summary>
        /// The notification message to be sent
        /// </summary>
        private string message;

        /// <summary>
        /// The email subject line
        /// </summary>
        private string subject;

        /// <summary>
        /// The address that email receivers will see as the sender
        /// </summary>
        private string senderAddress;

        /// <summary>
        /// The email addresses of the receivers of the email
        /// </summary>
        private string[] receiverAddresses;

        /// <summary>
        /// The email addresses of the receivers of the carbon copy of the email
        /// </summary>
        private string[] carbonCopyReceiverAddresses;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotification" /> class.
        /// </summary>
        /// <param name="smtpServerName">The server name for SMTP server</param>
        /// <param name="smtpPort">The port number for the SMTP server</param>
        /// <param name="username">The SMTP server username</param>
        /// <param name="password">The SMTP server password</param>
        /// <param name="message">The message body of the email</param>
        /// <param name="subject">The subject of the email</param>
        /// <param name="senderAddress">The email address of the sender of the email</param>
        /// <param name="receiverAddresses">The email addresses of the receivers of the email</param>
        /// <param name="carbonCopyReceiverAddresses">The email addresses of the carbon copy receivers of the email</param>
        public EmailNotification(string smtpServerName,
                                 int smtpPort,
                                 string username,
                                 string password,
                                 string message,
                                 string subject,
                                 string senderAddress,
                                 string[] receiverAddresses,
                                 string[] carbonCopyReceiverAddresses)
        {
            this.smtpClient = new SmtpClient(smtpServerName, smtpPort);
            smtpClient.UseDefaultCredentials = false;
            this.smtpClient.Credentials = new System.Net.NetworkCredential(username, password);
            this.smtpClient.EnableSsl = true;

            this.message = message;
            this.subject = subject;
            this.senderAddress = senderAddress;
            this.receiverAddresses = receiverAddresses;
            this.carbonCopyReceiverAddresses = carbonCopyReceiverAddresses;
        }

        #endregion

        #region <Enumerations>
        // No enumerations are defined
        #endregion

        #region <Events>
        // No events are defined
        #endregion

        #region Properties

        /// <summary>
        /// The notification message to be sent
        /// </summary>
        public string Message
        {
            set { this.message = value; }
        }

        /// <summary>
        /// The email subject line
        /// </summary>
        public string Subject
        {
            set { this.subject = value; }
        }

        /// <summary>
        /// The address that email receivers will see as the sender
        /// </summary>
        public string SenderAddress
        {
            set { this.senderAddress = value; }
        }

        /// <summary>
        /// The email addresses of the receivers of the email
        /// </summary>
        public string[] ReceiverAddresses
        {
            set { this.receiverAddresses = value; }
        }

        /// <summary>
        /// The email addresses of the receivers of the carbon copy of the email
        /// </summary>
        public string[] CarbonCopyReceiverAddresses
        {
            set { this.carbonCopyReceiverAddresses = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sends the notification
        /// </summary>
        public void Send()
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(this.senderAddress);

                foreach (var receiverAddress in this.receiverAddresses)
                {
                    mail.To.Add(receiverAddress);
                }

                foreach (var carbonCopyReceiverAddress in this.carbonCopyReceiverAddresses)
                {
                    mail.CC.Add(carbonCopyReceiverAddress);
                }

                mail.Subject = this.subject;
                mail.Body = this.message;

                this.smtpClient.Send(mail);
            }
            catch (Exception exception)
            {
                //ExceptionDisplayer.ExceptionDisplayer.DisplayException(exception.ToString());
                Console.WriteLine($"Exception occurred when sending the email: {exception.ToString()}");
                throw;
            }
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
