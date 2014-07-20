using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglApi.Models
{
    public class Tag : ITogglModel
    {        
        public int id { get; set; }
        public int wid { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            var str = String.Format("id: {0}. wid: {1}. name: {2}.", this.id, this.wid, this.name);
            return str;
        }
    }
}
