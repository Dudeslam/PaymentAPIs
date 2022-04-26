using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;
using PoCNetsEasy.Models;

namespace PoCNetsEasy.BusinessLayer
{
    public class BamboraClient
    {
        RestClient client = new RestClient("https://api.v1.checkout.bambora.com");
        public string acceptURL = "https://localhost:44337/API/Accept";
        public string cancelURL = "https://localhost:44337/API/Cancel";
        string accessToken = "BqFenjra8ft3s7WBXGEn";
        string merchantNumber = "T500173001";
        string secretToken = "PsdwtVqUEw6wzaiFiqovqCVQXT3aybzwteatntJr";

        
        public BamboraClient()
        {
            client.AddDefaultHeader("Content-Type", "application/json");
        }

        public dynamic CreateSession(order or)
        {
            string unencodedApiKey = string.Concat(accessToken, "@", merchantNumber, ":", secretToken);
            byte[] unencodedApiKeyAsBytes = System.Text.Encoding.UTF8.GetBytes(unencodedApiKey);
            string apiKey = "Basic " + System.Convert.ToBase64String(unencodedApiKeyAsBytes);
            string endpoint = "https://api.v1.checkout.bambora.com/sessions";
            dynamic checkoutRequest = new
            {
                order = new
                {
                    id = or.id,
                    amount = or.amount,
                    currency = or.currency,
                },
                url = new
                {
                    accept = acceptURL,
                    cancel = cancelURL,
                    callbacks = new List<dynamic> { new { url = "https://example.org/callback" } }

                }
            };
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add(System.Net.HttpRequestHeader.ContentType, "application/json");
            client.Headers.Add(System.Net.HttpRequestHeader.Authorization, apiKey);
            client.Headers.Add(System.Net.HttpRequestHeader.Accept, "application/json");

            var checkoutRequestJson = System.Web.Helpers.Json.Encode(checkoutRequest);
            var checkoutResponseJson = client.UploadString(endpoint, "POST", checkoutRequestJson);
            dynamic checkoutResponse = System.Web.Helpers.Json.Decode(checkoutResponseJson);
            return checkoutResponse;
        }

    }
}