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
    
    public partial class Session
    {
        public long id { get; set; }
        public long boardid { get; set; }
        public string name { get; set; }
        public System.TimeSpan stime { get; set; }
        public System.TimeSpan duration { get; set; }
        public short algorithm { get; set; }
        public short match { get; set; }
        public string allowedtypes { get; set; }
        public string description { get; set; }
        public short state { get; set; }
        public System.DateTime modified { get; set; }
        public string isactive { get; set; }
        public System.DateTime starttime { get; set; }
        public System.DateTime endtime { get; set; }
        public string tduration { get; set; }
        public long matched { get; set; }
        public string editorder { get; set; }
        public string delorder { get; set; }
        public string markettype { get; set; }
    }
}
