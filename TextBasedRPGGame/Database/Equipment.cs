//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextBasedRPGGame.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Points { get; set; }
        public int Owner_id { get; set; }
        public Nullable<bool> Is_equiped { get; set; }
        public string Type { get; set; }
        public Nullable<int> Price { get; set; }
    }
}
