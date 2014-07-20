using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogglApi.Models;

namespace TogglApi.NetworkModels
{
    public class UpdateClientRequest :ITogglModel
    {
        public Client client { get; set; }
    }
}
