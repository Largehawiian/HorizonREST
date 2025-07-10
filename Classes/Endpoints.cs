using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonREST.Classes
{
    internal class Endpoints
    {
        public static readonly Dictionary<string, string> Api = new()
        {
            {"Login", "/rest/login" },
            {"Machines", "/rest/inventory/v1/machines"},
            {"Pools", "/rest/inventory/v1/desktop-pools" }
        };
    }
}
