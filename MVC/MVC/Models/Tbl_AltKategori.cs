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
    
    public partial class Tbl_AltKategori
    {
        public Tbl_AltKategori()
        {
            this.Tbl_Urunler = new HashSet<Tbl_Urunler>();
        }
    
        public int aKategori_ID { get; set; }
        public string AltKategori_Adi { get; set; }
        public Nullable<int> UstKategori_ID { get; set; }
    
        public virtual Tbl_Kategori Tbl_Kategori { get; set; }
        public virtual ICollection<Tbl_Urunler> Tbl_Urunler { get; set; }
    }
}
