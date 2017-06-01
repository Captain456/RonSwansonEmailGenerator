// <summary>
// This file defines the RonSwansonRestApiClient class.
// </summary>
// <copyright file="RonSwansonRestApiClient.cs">
// Copyright (c) Christopher Gibbs. All rights reserved.
// </copyright>
// <author>ChristopherGibbs</author>
// <date>06/01/2017</date>

namespace RonSwansonEmailTest.RestApiClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    /// <summary>
    /// A REST API client for the Ron Swanson Quote REST API
    /// </summary>
    public class RonSwansonRestApiClient
    {
        #region Fields

        private string url;

        private string urlParameters;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RonSwansonRestApiClient" /> class.
        /// </summary>
        public RonSwansonRestApiClient()
        {
            this.url = "http://ron-swanson-quotes.herokuapp.com/v2/quotes";
            this.urlParameters = "";
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

        #region <Public Methods>

        /// <summary>
        /// Requests a response from the Ron Swanson Quote API
        /// </summary>
        /// <returns>The Ron Swanson quote result from the response</returns>
        public string GetResponse()
        {
            string dataObjectsAsString = "";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(this.urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                dataObjectsAsString = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return dataObjectsAsString;
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
