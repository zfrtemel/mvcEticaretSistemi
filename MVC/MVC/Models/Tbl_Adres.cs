//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Adres
    {
        public int ID { get; set; }
        public Nullable<int> Musteri_ID { get; set; }
        public string Adres { get; set; }
    
        public virtual Tbl_Kullanici Tbl_Kullanici { get; set; }
    }
}
