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
    
    public partial class Tbl_Kategori
    {
        public Tbl_Kategori()
        {
            this.Tbl_AltKategori = new HashSet<Tbl_AltKategori>();
            this.Tbl_Urunler = new HashSet<Tbl_Urunler>();
        }
    
        public int Kategori_ID { get; set; }
        public string Kategori_Adi { get; set; }
    
        public virtual ICollection<Tbl_AltKategori> Tbl_AltKategori { get; set; }
        public virtual ICollection<Tbl_Urunler> Tbl_Urunler { get; set; }
    }
}
