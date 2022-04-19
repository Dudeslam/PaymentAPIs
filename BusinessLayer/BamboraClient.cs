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

        public IRestResponse CreateSession(order or)
        {
            var request = new RestRequest("payments", Method.POST);
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
                    cancel = cancelURL

                }
            };
            request.AddParameter("application/*+json", JsonSerializer.Serialize(), ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

    }
}