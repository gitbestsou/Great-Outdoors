using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Entities
{

    public class Retailer
    {
        private int _retailerID;
        private string _uName;
        private string _password;
        private string _retailerame;
        private string _email;
        private string _retailerContactNumber;

        public int RetailerID { get => _retailerID; set => _retailerID = value; }
        public string UName { get => _uName; set => _uName = value; }
        public string Password { get => _password; set => _password = value; }
        public string RetailerName { get => _retailerame; set => _retailerame = value; }
        public string Email { get => _email; set => _email = value; }
        public string RetailerContactNumber { get => _retailerContactNumber; set => _retailerContactNumber = value; }

        public Retailer()
        {
            RetailerID = 0;
            UName = string.Empty;
            Password = string.Empty;
            RetailerName = string.Empty;
            Email = string.Empty;
            RetailerContactNumber = string.Empty;

        }
    }

}


   