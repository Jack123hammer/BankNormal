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
    
    public partial class Individual
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public decimal Phone { get; set; }
        public string Address { get; set; }
        public decimal TIN { get; set; }
        public decimal INIPA { get; set; }
        public decimal Serial { get; set; }
        public decimal Number { get; set; }
        public string IssuedBy { get; set; }
        public string DepartmentCode { get; set; }
        public string Email { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
