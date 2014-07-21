using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglApi.Models
{
    public abstract class TogglResponse<T> where T : ITogglModel
    {
        public int since { get; set; }
        public abstract T data { get; set; }
    }

    public class UserResponse : TogglResponse<User>
    {
        public override User data { get; set; }
    }

    public class ClientResponse : TogglResponse<Client>
    {
        public override Client data { get; set; }
    }

    public class TagResponse : TogglResponse<Tag>
    {
        public override Tag data { get; set; }
    }
    
    public class ProjectResponse : TogglResponse<Project>
    {
        public override Project data { get; set; }
    }

    public class ProjectUserResponse : TogglResponse<ProjectUser>
    {
        public override ProjectUser data { get; set; }
    }

}
