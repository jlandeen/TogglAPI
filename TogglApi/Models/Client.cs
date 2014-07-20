using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglApi.Models
{
    public class Client : ITogglModel
    {        
        public int id { get; set; }
        public int wid { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string at { get; set; }
        public string server_deleted_at { get; set; }
        
        public override string ToString()
        {
            string result = string.Empty;
            result = BuildNode("id", id) + ",";
            result = result + BuildNode("wid", wid) + ",";
            result = result + BuildNode("name", name) + ",";
            result = result + BuildNode("notes", notes) + ",";
            result = result + BuildNode("at", at) + ",";
            result = result + BuildNode("server_deleted_at", server_deleted_at);
            result = "{" + result + "}";
            return result;
        }

        private string BuildNode(string name, string paramData)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(paramData))
                {
                    result = "\"" + name + "\":\"\"";
                }
            else
                { 
                result = "\"" + name + "\":\"" + paramData.ToString() + "\"";
                }
            return result;
        }
        
        private string BuildNode(string name, int paramData)
        {
            string result = string.Empty;
            result = "\"" + name + "\":" + paramData.ToString() + "";
            return result;
        }
    }
}
