using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogglApi.Models;
using TogglApi.NetworkModels;


namespace TogglApi.Entities
{
    public class Clients : IEntity<Client>
    {
        #region Constructor
        
        TogglAuthRequest _auth;

        public Clients(TogglAuthRequest togglAuth)
        {
            if (togglAuth == null || !togglAuth.IsValid())
                throw new ArgumentNullException("togglAuth", "Cannot be null");
            _auth = togglAuth;
        }

        #endregion

        public IEnumerable<Client> Get()
        {
            var client = new RestClient(Constants.Urls.ME_CLIENTS);
            var request = new RestRequest(Method.GET);
            request.AddTogglAuth(_auth);

            var resp = client.Execute<List<Client>>(request);

            var content = resp.Content;

            return resp.Data;
        }

        public Client Get(string id)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_CLIENTS + "/{clientId}",Method.GET);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("clientId", id);
           
            var resp = client.Execute<ClientResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public Client Update(Client entity)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_CLIENTS + "/{clientId}", Method.PUT);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("clientId", entity.id.ToString());
            request.RequestFormat = DataFormat.Json;
            UpdateClientRequest updateClientRequest = new UpdateClientRequest() { client = entity };
            request.AddBody(updateClientRequest);
            
            string test = entity.ToString();

            var resp = client.Execute<ClientResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public Client Create(Client entity)
        {
            //Create Requests are handled via a Post Method
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_CLIENTS, Method.POST);
            request.AddTogglAuth(_auth);
            request.RequestFormat = DataFormat.Json;
            UpdateClientRequest updateClientRequest = new UpdateClientRequest() { client = entity };
            request.AddBody(updateClientRequest);

            string test = entity.ToString();

            var resp = client.Execute<ClientResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public bool Delete(Client entity)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_CLIENTS + "/{clientId}", Method.DELETE);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("clientId", entity.id.ToString());
            request.RequestFormat = DataFormat.Json;
            UpdateClientRequest updateClientRequest = new UpdateClientRequest() { client = entity };
            request.AddBody(updateClientRequest);

            string test = entity.ToString();

            var resp = client.Execute<ClientResponse>(request);

            var content = resp.Content;

            bool result = false;
            if (content.ToString() == "200 OK") { result = true; };
            return result;
        }

        
    }
}
