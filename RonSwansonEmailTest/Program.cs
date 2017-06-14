// <summary>
// This file defines the Program class.
// </summary>
// <copyright file="Program.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using CommandLine;
    using RonSwansonEmailTest.FileStringParser;
    using RonSwansonEmailTest.Notification;
    using RonSwansonEmailTest.RestApiClient;
    using RonSwansonEmailTest.StringParser;

    /// <summary>
    /// The entry point into the application
    /// </summary>
    class Program
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
        /// Starts the application, which sends a Ron Swanson quote via email.
        /// </summary>
        /// <param name="arguments">The command-line arguments.</param>
        static void Main(string[] arguments)
        {
            try
            {
                // Parse the command-line arguments
                var commandLineArguments = ParseCommandLineArguments(arguments);

                var receiversFilePath = commandLineArguments.ReceiversFilePath;
                var ccReceiversFilePath = commandLineArguments.CCReceiversFilePath;
                var additionalMessage = commandLineArguments.Message;

                // Get the quote
                RonSwansonRestApiClient ronSwansonRestApiClient = new RonSwansonRestApiClient();
                var ronSwansonQuote = ronSwansonRestApiClient.GetResponse();

                // Format the quote
                ronSwansonQuote = ronSwansonQuote.Substring(1);
                ronSwansonQuote = ronSwansonQuote.Remove(ronSwansonQuote.Length - 1) + " - Ron Swanson";

                if (additionalMessage != null)
                {
                    ronSwansonQuote = ronSwansonQuote + "\n\n" + additionalMessage;
                }

                // Setup email notification
                CredentialGenerator.CredentialGenerator credentialGenerator = new CredentialGenerator.CredentialGenerator();

                Tuple<string, string> credentials = credentialGenerator.GenerateCredentials();

                string serverName = "smtp.office365.com";
                int port = 587;

                string body = ronSwansonQuote;
                string subject = "Wise Words From Ron Swanson";
                string senderAddress = credentials.Item1;

                StringEmailAddressParser stringEmailAddressParser = new StringEmailAddressParser();
                FileEmailAddressParser fileEmailAddressParser = new FileEmailAddressParser(stringEmailAddressParser);

                EmailNotification emailNotification = new EmailNotification(smtpServerName: serverName,
                                                                            smtpPort: port,
                                                                            username: credentials.Item1,
                                                                            password: credentials.Item2,
                                                                            message: body,
                                                                            subject: subject,
                                                                            senderAddress: senderAddress,
                                                                            receiverAddresses: fileEmailAddressParser.ParseFile(receiversFilePath).ToArray(),
                                                                            carbonCopyReceiverAddresses: fileEmailAddressParser.ParseFile(ccReceiversFilePath).ToArray());

                // Send the email notification
                Console.WriteLine($"Sending email with the following message:\n{ronSwansonQuote}");
                NotificationSender.NotificationSender.SendNotification(emailNotification);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: An exception was thrown: {exception.Message}");

                Environment.Exit(1);
            }
        }

        #endregion

        #region <Protected Methods>
        // No protected methods are defined
        #endregion

        #region Private Methods

        /// <summary>
        /// Parses the command line argument strings into a <see cref="CommandLineArguments"/> data structure.
        /// Special thanks to Mark Henney for the basis of this method.
        /// </summary>
        /// <param name="arguments">The arguments to parse.</param>
        /// <returns>The parsed command line arguments.</returns>
        private static CommandLineArguments ParseCommandLineArguments(string[] arguments)
        {
            var commandLineArguments = new CommandLineArguments();
            try
            {
                if (!Parser.Default.ParseArguments(arguments, commandLineArguments))
                {
                    Console.WriteLine($"[{DateTime.Now}] ERROR: Failed to parse command line arguments");

                    var options = typeof(CommandLineArguments)
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Select(property => new
                        {
                            Property = property,
                            Attribute = property.GetCustomAttribute<BaseOptionAttribute>()
                        })
                        .Where(pair => pair.Attribute != null);
                }
            }
            catch (Exception exception)
            {
                throw new ArgumentException($"An exception occurred when parsing the command-line arguments: {exception.Message}");
            }

            return commandLineArguments;
        }

        #endregion
    }
}
