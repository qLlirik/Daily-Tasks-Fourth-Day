//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FourthDay.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Repair
    {
        public int ID { get; set; }
        public double CarriageRegNumber { get; set; }
        public int GroupID { get; set; }
        public int TypeID { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> Finish { get; set; }
        public string Reason { get; set; }
        public bool External { get; set; }
        public Nullable<int> ExternalID { get; set; }
        public bool Bonus { get; set; }
        public byte BonusPercent { get; set; }
    
        public virtual Carriages Carriages { get; set; }
        public virtual Externals Externals { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual RepairTypes RepairTypes { get; set; }
    }
}