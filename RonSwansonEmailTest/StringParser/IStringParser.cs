// <summary>
// This file defines the IStringParser interface.
// </summary>
// <copyright file="IStringParser.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.StringParser
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface for a string parser.
    /// </summary>
    public interface IStringParser
    {
        #region <Events>
        // No events are defined
        #endregion

        #region <Properties>
        // No properties are defined
        #endregion

        #region Public Methods

        /// <summary>
        /// Parses a string and returns the parsed items in a list.
        /// </summary>
        /// <param name="stringToParse">The string to parse.</param>
        /// <returns>The parsed items.</returns>
        List<string> ParseString(string stringToParse);

        #endregion
    }
}
