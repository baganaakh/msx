//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pages.dbBind
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public long id { get; set; }
        public short dealType { get; set; }
        public short side { get; set; }
        public long memberid { get; set; }
        public long accountid { get; set; }
        public long assetid { get; set; }
        public int qty { get; set; }
        public decimal price { get; set; }
        public short state { get; set; }
        public System.DateTime modified { get; set; }
    }
}
