// <summary>
// This file defines the FileEmailAddressParser class.
// </summary>
// <copyright file="FileEmailAddressParser.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.FileStringParser
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using RonSwansonEmailTest.StringParser;

    /// <summary>
    /// An implementation of <see cref="IFileStringParser"/> that parses a file for email addresses.
    /// </summary>
    public class FileEmailAddressParser : IFileStringParser
    {
        #region Fields

        /// <summary>
        /// The <see cref="IStringParser"/> used by this class to parse email addresses from individual strings.
        /// </summary>
        private IStringParser stringParser;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEmailAddressParser" /> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if stringParser is null.</exception>
        public FileEmailAddressParser(IStringParser stringParser)
        {
            if (stringParser == null)
            {
                throw new ArgumentNullException(nameof(stringParser));
            }

            this.stringParser = stringParser;
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
        /// Parses a file for email addresses and returns them in a list of strings.
        /// </summary>
        /// <param name="filePath">The path to a text file.</param>
        /// <returns>The parsed email addresses.</returns>
        /// <exception cref="ArgumentNullException">Thrown if filePath is null.</exception>
        /// <exception cref="ArgumentException">Thrown if filePath is not a valid path to a file.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an exception is handled when reading a line from the file.</exception>
        public List<string> ParseFile(string filePath)
        {
            StreamReader streamReader;
            string line;
            List<string> emailAddresses = new List<string>();

            // Ensure that the file path is valid
            try
            {
                streamReader = File.OpenText(filePath);
            }
            catch(ArgumentNullException argumentNullException)
            {
                throw argumentNullException;
            }
            catch
            {
                throw new ArgumentException($"The provided file path is not valid: {filePath}");
            }

            // Parse the file
            try
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    emailAddresses.AddRange(this.stringParser.ParseString(line));
                }
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException($"An exception occurred when reading a line from the file: {exception.Message}");
            }

            return emailAddresses;
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
