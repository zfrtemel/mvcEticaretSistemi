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
    
    public partial class Tbl_SiparisDurum
    {
        public int Durum_ID { get; set; }
        public Nullable<int> sDurum_ID { get; set; }
        public string Siparis_Durumu { get; set; }
    
        public virtual Tbl_Siparis Tbl_Siparis { get; set; }
    }
}
