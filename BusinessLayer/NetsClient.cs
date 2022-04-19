using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using NetsEasyPOC.Models;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

namespace NetsEasyPOC.BusinessLayer
{
    public class NetsClient
    {
        private RestClient _client;
        string instanceName = "test-environment-bytelab";
        string apiKey = "test-secret-key-578ecae112ad4012a00a39f6abf85de2";
        string Instance_API_SECRECT = "rywKbBsxGFE82ES51jnO03Qe6LTLAr";
        string checkoutKey = "test-checkout-key-1f02ba7204c6411995b9a6b8772ce3fa";
        RestClient payClient = new RestClient("https://test.api.dibspayment.eu/v1");
        


        public IRestResponse CreatePayment(Root bod)
        {
            var request = new RestRequest("payments", Method.POST);
            request.AddHeader("content-type", "application/*+json");
            request.AddHeader("Authorization", apiKey);
            request.AddParameter("application/*+json", JsonSerializer.Serialize(bod), ParameterType.RequestBody);
            var response = payClient.Execute(request);
            return response;

        }

        public IRestResponse SignatureCheck()
        {
            var request = new RestRequest("SignatureCheck", Method.GET);
            string message = "data1=value1&data2=value2";
            byte[] keyByte = new UTF8Encoding().GetBytes(apiKey);
            byte[] messageBytes = new UTF8Encoding().GetBytes(message);
            byte[] hashmessage = new HMACSHA256(keyByte).ComputeHash(messageBytes);
            var signature = Convert.ToBase64String(hashmessage);
            var response = payClient.Execute(request);
            return response;

        }

        



    }

}