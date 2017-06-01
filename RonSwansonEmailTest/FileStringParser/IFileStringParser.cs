// <summary>
// This file defines the IFileStringParser interface.
// </summary>
// <copyright file="IFileStringParser.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.FileStringParser
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface for a file parser that parses strings.
    /// </summary>
    public interface IFileStringParser
    {
        #region <Events>
        // No events are defined
        #endregion

        #region <Properties>
        // No properties are defined
        #endregion

        #region Public Methods

        /// <summary>
        /// Parses a file for strings and returns them in a list.
        /// </summary>
        /// <param name="filePath">The path to the file to parse.</param>
        /// <returns>The parsed strings from the file.</returns>
        List<string> ParseFile(string filePath);

        #endregion
    }
}
