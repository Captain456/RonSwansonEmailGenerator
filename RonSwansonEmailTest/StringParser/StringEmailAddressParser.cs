// <summary>
// This file defines the StringEmailAddressParser class.
// </summary>
// <copyright file="StringEmailAddressParser.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.StringParser
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An implementation of <see cref="IStringParser"/> that parses comma-separated email addresses from a string
    /// </summary>
    public class StringEmailAddressParser : IStringParser
    {
        #region <Fields>
        // No fields are defined
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StringEmailAddressParser" /> class.
        /// </summary>
        public StringEmailAddressParser()
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
        /// Parses a string for email addresses and returns them in a list.
        /// </summary>
        /// <param name="stringToParse">The string to parse.</param>
        /// <returns>The email addresses in the string.</returns>
        public List<string> ParseString(string stringToParse)
        {
            // Get all email addresses in the string, trim leading/ending white-space, and add to the list
            return new List<string>(Array.ConvertAll(stringToParse.Split(','), address => address.Trim()));
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
