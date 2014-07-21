using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogglApi.Models;
using TogglApi.NetworkModels;
using System.Net;


namespace TogglApi.Entities
{
    public class Tags : IEntity<Tag>
    {
        #region Constructor
        
        TogglAuthRequest _auth;

        public Tags(TogglAuthRequest togglAuth)
        {
            if (togglAuth == null || !togglAuth.IsValid())
                throw new ArgumentNullException("togglAuth", "Cannot be null");
            _auth = togglAuth;
        }

        #endregion

        public IEnumerable<Tag> Get()
        {
            var client = new RestClient(Constants.Urls.ME_TAGS);
            var request = new RestRequest(Method.GET);
            request.AddTogglAuth(_auth);

            var resp = client.Execute<List<Tag>>(request);

            var content = resp.Content;

            return resp.Data;
        }

        public Tag Get(string id)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_TAGS + "/{tag_id}", Method.GET);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("tag_id", id);
           
            var resp = client.Execute<TagResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public Tag Update(Tag entity)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_TAGS + "/{tag_id}", Method.PUT);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("tag_id", entity.id.ToString());
            request.RequestFormat = DataFormat.Json;
            UpdateTagRequest updateRequest = new UpdateTagRequest() { tag = entity };
            request.AddBody(updateRequest);
            
            var resp = client.Execute<TagResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public Tag Create(Tag entity)
        {
            //Create Requests are handled via a Post Method
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_TAGS, Method.POST);
            request.AddTogglAuth(_auth);
            request.RequestFormat = DataFormat.Json;
            UpdateTagRequest updateRequest = new UpdateTagRequest() { tag = entity };
            request.AddBody(updateRequest);

            var resp = client.Execute<TagResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public bool Delete(Tag entity)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_TAGS + "/{tag_id}", Method.DELETE);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("tag_id", entity.id.ToString());
            request.RequestFormat = DataFormat.Json;
            UpdateTagRequest updateRequest = new UpdateTagRequest() { tag = entity };
            request.AddBody(updateRequest);

            var resp = client.Execute<TagResponse>(request);

            var content = resp.Content;

            bool result = false;
            if (resp.StatusCode == HttpStatusCode.OK) { result = true; };
            return result;
        }
        
    }
}
