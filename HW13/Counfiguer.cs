using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13
{
    public class Counfiguer
    {
        public static string Connectionstring { get; set; }
        static Counfiguer()
        {
            Connectionstring = @"Data Source=LEILI\LEILA;Initial Catalog=HW13;Integrated Security=true; TrustServerCertificate=True";
        }
    }
}
