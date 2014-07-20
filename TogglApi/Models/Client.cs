﻿using System;
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
            var str = String.Format("id: {0}. wid: {1}. name: {2}. notes: {3}. at: {4}. server_deleted_at: {5}.", this.id, this.wid, this.name, this.notes, this.at, this.server_deleted_at);
            return str;
        }
    }
}
