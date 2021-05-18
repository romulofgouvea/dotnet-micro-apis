using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api2.Application.Models;
using Api2.Application.Repositories;
using Newtonsoft.Json;

namespace Api2.Application.Services
{
    public class ApiInterestRatesComunicationServices : IServicesApiInterestsRates
    {
        public double FindValueInterestRates(string urlBaseApi)
        {
            //SSL Ignore
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, ssl) => true;

            string base_url = $"{urlBaseApi}/taxaJuros";
            HttpWebRequest request = WebRequest.CreateHttp(base_url);

            request.Method = "GET";
            request.Headers.Add("Content-Type", "application/json");

            using WebResponse resposta = request.GetResponse();

            Stream streamDados = resposta.GetResponseStream();
            StreamReader reader = new(streamDados);
            object objResponse = reader.ReadToEnd();

            dynamic result = JsonConvert.DeserializeObject<dynamic>(objResponse.ToString());

            streamDados.Close();
            resposta.Close();

            var interests = new MInterestsRates
            {
                Value = result
            };

            return interests.Value;
        }
    }
}
