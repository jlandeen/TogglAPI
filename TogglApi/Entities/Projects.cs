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
    public class Projects : IEntity<Project>
    {
        #region Constructor
        
        TogglAuthRequest _auth;

        public Projects(TogglAuthRequest togglAuth)
        {
            if (togglAuth == null || !togglAuth.IsValid())
                throw new ArgumentNullException("togglAuth", "Cannot be null");
            _auth = togglAuth;
        }

        #endregion

        public IEnumerable<Project> Get()
        {
            var client = new RestClient(Constants.Urls.ME_PROJECT);
            var request = new RestRequest(Method.GET);
            request.AddTogglAuth(_auth);

            var resp = client.Execute<List<Project>>(request);

            var content = resp.Content;

            return resp.Data;
        }

        public Project Get(string id)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_PROJECT + "/{project_id}", Method.GET);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("project_id", id);

            var resp = client.Execute<ProjectResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public Project Update(Project entity)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_PROJECT + "/{project_id}", Method.PUT);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("project_id", entity.id.ToString());
            request.RequestFormat = DataFormat.Json;
            UpdateProjectRequest updateRequest = new UpdateProjectRequest() { project = entity };
            request.AddBody(updateRequest);

            string test = entity.ToString();

            var resp = client.Execute<ProjectResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public Project Create(Project entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Project entity)
        {
            throw new NotImplementedException();
        }

        public Project Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
