// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace InventoryApp_DL.Entities
{
    // AspNetUserPreferences
	[Serializable]
	
    public partial class AspNetUserPreferences : InventoryApp_DL.Infrastructure.Entity
    {
        public int id { get; set; } // id (Primary key)
        public string UserId { get; set; } // UserId
        public int CategoryId { get; set; } // CategoryId
        public int ProductId { get; set; } // ProductId

        // Foreign keys
        public virtual AspNetUsers AspNetUsers { get; set; } //  FK_AspNetUserCategories_AspNetUsers
        public virtual Categories Categories { get; set; } //  FK_AspNetUserCategories_Categories
        public virtual Products Products { get; set; } //  FK_AspNetUserPreferences_Products
    }

}
