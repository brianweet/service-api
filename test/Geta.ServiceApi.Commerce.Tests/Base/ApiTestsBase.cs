using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace Geta.ServiceApi.Commerce.Tests.Base
{
    public abstract class ApiTestsBase
    {
        readonly string _username = "admin";
        readonly string _password = "store";

        protected readonly HttpClient Client;
        protected string IntegrationUrl = "https://serviceapi.localtest.me";

        protected ApiTestsBase()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            Client = new HttpClient
            {
                BaseAddress = new Uri(IntegrationUrl)
            };
            Authenticate(Client);
        }

        public void Dispose()
        {
            Client.Dispose();
        }

        protected void AcceptXml()
        {
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        }

        protected void RemoveAcceptXml()
        {
            Client.DefaultRequestHeaders.Accept.Remove(new MediaTypeWithQualityHeaderValue("text/xml"));
        }

        protected static bool IsXml(string xmlString)
        {
            try
            {
                // ReSharper disable once UnusedVariable
                var doc = XDocument.Parse(xmlString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected string SerializeXml<T>(T toSerialize)
        {
            var xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        protected T DeserizalizeXml<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        private void Authenticate(HttpClient client)
        {
            var fields = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", _username },
                    { "password", _password }
                };
            var response = client.PostAsync("/episerverapi/token", new FormUrlEncodedContent(fields)).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Authentication failed! Status: {response.StatusCode}");
            }

            var content = response.Content.ReadAsStringAsync().Result;
            var token = JObject.Parse(content).GetValue("access_token").ToString();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}