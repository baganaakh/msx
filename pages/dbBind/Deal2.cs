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
    
    public partial class Deal2
    {
        public long id { get; set; }
        public Nullable<long> boardid { get; set; }
        public Nullable<long> dealno { get; set; }
        public Nullable<short> side { get; set; }
        public long accountid { get; set; }
        public long assetid { get; set; }
        public Nullable<short> dealType { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> totalPrice { get; set; }
        public Nullable<short> state { get; set; }
        public Nullable<decimal> fee { get; set; }
        public System.DateTime modified { get; set; }
        public Nullable<long> memberid { get; set; }
        public Nullable<bool> invoice { get; set; }
    }
}
