using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Models
{
    public class Context
    {
        private static DbContext baglanti;
        public static DbContext Baglanti 
        {
            get 
            {
                if (baglanti == null) {
                    DbContext baglanti = new DbContext("urun");
                }
                return baglanti;
               
            }
            set { baglanti = value; }
        }


      

    }
}