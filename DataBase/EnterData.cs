//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankNormal.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class EnterData
    {
        public int ID { get; set; }
        public System.DateTime Date { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
        public int UserID { get; set; }
    
        public virtual Enter_type Enter_type { get; set; }
        public virtual Account Account { get; set; }
    }
}
