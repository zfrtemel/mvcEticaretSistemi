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
    
    public partial class Tbl_Renkler
    {
        public Tbl_Renkler()
        {
            this.Tbl_Urunler = new HashSet<Tbl_Urunler>();
        }
    
        public int Renk_ID { get; set; }
        public string Renk_Adi { get; set; }
    
        public virtual ICollection<Tbl_Urunler> Tbl_Urunler { get; set; }
    }
}
