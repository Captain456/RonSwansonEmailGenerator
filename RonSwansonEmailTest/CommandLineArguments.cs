// <summary>
// This file defines the CommandLineArguments class.
// </summary>
// <copyright file="CommandLineArguments.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest
{
    using CommandLine;
    using CommandLine.Text;

    /// <summary>
    /// Represents the command line arguments to parse for the application.
    /// </summary>
    public class CommandLineArguments
    {
        #region <Fields>
        // No fields are defined
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineArguments" /> class.
        /// </summary>
        public CommandLineArguments()
        {
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
        /// Gets or sets the path to the file containing the email addresses of the receivers.
        /// </summary>
        [Option(
            "receiversFilePath",
            Required = true,
            HelpText = "Gets or sets the path to the file containing the email addresses of the receivers.")]
        public string ReceiversFilePath { get; set; }

        /// <summary>
        /// Gets or sets the path to the file containing the email addresses of the carbon-copy receivers.
        /// </summary>
        [Option(
            "ccReceiversFilePath",
            Required = true,
            HelpText = "Gets or sets the path to the file containing the email addresses of the carbon-copy receivers.")]
        public string CCReceiversFilePath { get; set; }

        /// <summary>
        /// Gets or sets the message to attach to the end of the email. Defaults to null.
        /// </summary>
        [Option(
            "message",
            DefaultValue = null,
            HelpText = "An additional message to add to the email body.")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the path to an image file that will be added to the email body.
        /// </summary>
        [Option(
            "imageFilePath",
            DefaultValue = null,
            HelpText = "Gets or sets the path to an image file that will be added to the email body.")]
        public string imageFilePath { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the HelpText for all command line options.
        /// </summary>
        /// <returns>The HelpText for the command line options</returns>
        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(
                                this,
                                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
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
