// <summary>
// This file defines the CredentialGenerator class.
// </summary>
// <copyright file="CredentialGenerator.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.CredentialGenerator
{
    using System;

    /// <summary>
    /// Used to get user credentials for an SMTP server.
    /// </summary>
    public class CredentialGenerator
    {
        #region <Fields>
        // No fields are defined
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialGenerator" /> class.
        /// </summary>
        public CredentialGenerator()
        {
        }

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
        /// Asks the user to enter a username and password and returns them.
        /// </summary>
        /// <returns>The tuple containing the username and password</returns>
        public Tuple<string, string> GenerateCredentials()
        {
            var username = GetUsername();
            var password = GetPassword();

            Tuple<string, string> credentials = new Tuple<string, string>(username, password);
            return credentials;
        }

        #endregion

        #region <Protected Methods>
        // No protected methods are defined
        #endregion

        #region Private Methods

        /// <summary>
        /// Asks for the user ID and returns the input
        /// </summary>
        /// <returns>The line of input from the user</returns>
        private string GetUsername()
        {
            Console.WriteLine("Please enter the email username:");
            string userId = Console.ReadLine();

            return userId;
        }

        /// <summary>
        /// Asks for the password and returns the input
        /// </summary>
        /// <returns>The line of input from the user</returns>
        private string GetPassword()
        {
            string password = "";
            ConsoleKeyInfo key;
            Console.WriteLine("Please enter the email password:");

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine("");

            return password;
        }

        #endregion
    }
}
