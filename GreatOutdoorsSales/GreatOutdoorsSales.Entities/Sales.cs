using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorsSales.Entities
{
    public class Sales
    {
        private int salesManID;

        public int SalesManID
        {
            get { return salesManID; }
            set { salesManID = value; }
        }
        private string salesManName;

        public string SalesManName
        {
            get { return salesManName; }
            set { salesManName = value; }
        }

        private string salesManUserName;

        public string SalesManUserName
        {
            get { return salesManUserName; }
            set { salesManUserName = value; }
        }

        private string salesManPassword;

        public string SalesManPassword
        {
            get { return salesManPassword; }
            set { salesManPassword = value; }
        }

        private string salesManEmail;

        public string SalesManEmail
        {
            get { return salesManEmail; }
            set { salesManEmail = value; }
        }

        private string salesManMobile;

        public string SalesManMobile
        {
            get { return salesManMobile; }
            set { salesManMobile = value; }
        }


        private double salesManSalary;
        public double SalesManSalary
        {
            get { return salesManSalary; }
            set { salesManSalary = value; }
        }

        private double salesManBonus;
        public double SalesManBonus
        {
            get { return salesManBonus; }
            set { salesManBonus = value; }
        }



        public Sales()
        {
            salesManID = 0;
            salesManName = string.Empty;
            salesManUserName = string.Empty;
            salesManPassword = string.Empty;
            salesManEmail = string.Empty;
            salesManMobile = string.Empty;
        }
    }
}