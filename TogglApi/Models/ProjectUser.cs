using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglApi.Models
{
    public class ProjectUser : ITogglModel
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int uid { get; set; }
        public int wid { get; set; }
        public bool manager { get; set; }
        public float rate { get; set; }
        public string at { get; set; }
        public string fields { get; set; }  //valid value is "fullname"
        public string fullname { get; set; }
     }
}
