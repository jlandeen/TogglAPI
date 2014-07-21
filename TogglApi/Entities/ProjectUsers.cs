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
    public class ProjectUsers 
    {
        #region Constructor
        
        TogglAuthRequest _auth;
        const string _fieldsDefault = "fullname";

        public ProjectUsers(TogglAuthRequest togglAuth)
        {
            if (togglAuth == null || !togglAuth.IsValid())
                throw new ArgumentNullException("togglAuth", "Cannot be null");
            _auth = togglAuth;
        }

        #endregion

        public ProjectUser Create(ProjectUser entity)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_PROJECT_USERS, Method.POST);
            request.AddTogglAuth(_auth);
            request.RequestFormat = DataFormat.Json;
            entity.fields = _fieldsDefault;
            UpdateProjectUserRequest updateRequest = new UpdateProjectUserRequest() { project_user = entity };
            request.AddBody(updateRequest);

            var resp = client.Execute<ProjectUserResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public ProjectUser UpdateUser(ProjectUser entity)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_PROJECT_USERS + "/{project_user_id}", Method.PUT);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("project_user_id", entity.id.ToString());
            request.RequestFormat = DataFormat.Json;
            entity.fields = _fieldsDefault;
            UpdateProjectUserRequest updateRequest = new UpdateProjectUserRequest() { project_user = entity };
            request.AddBody(updateRequest);

            var resp = client.Execute<ProjectUserResponse>(request);

            var content = resp.Content;

            return resp.Data.data;
        }

        public bool Delete(ProjectUser entity)
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.Urls.ME_PROJECT_USERS + "/{project_user_id}", Method.DELETE);
            request.AddTogglAuth(_auth);
            request.AddUrlSegment("project_user_id", entity.id.ToString());
            request.RequestFormat = DataFormat.Json;

            var resp = client.Execute<ProjectUserResponse>(request);

            var content = resp.Content;

            bool result = false;
            if (resp.StatusCode == HttpStatusCode.OK) { result = true; };
            return result;
        }

    }
}
