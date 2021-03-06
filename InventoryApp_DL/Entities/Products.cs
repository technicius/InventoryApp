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
    // Products
	[Serializable]
	
    public partial class Products : InventoryApp_DL.Infrastructure.Entity
    {
        public int id { get; set; } // id (Primary key)
        public string Name { get; set; } // Name
        public string Description { get; set; } // Description
        public string Type { get; set; } // Type
        public string Brand { get; set; } // Brand
        public decimal Price { get; set; } // Price
        public decimal? OfferPrice { get; set; } // OfferPrice
        public int Quantity { get; set; } // Quantity
        public int? MOQ { get; set; } // MOQ
        public int CategoryId { get; set; } // CategoryId
        public bool IsActive { get; set; } // IsActive
        public bool IsDeleted { get; set; } // IsDeleted
        public decimal? MinimumSellingPrice { get; set; } // MinimumSellingPrice
        public bool ApplyGst { get; set; } // ApplyGst

        // Reverse navigation
        public virtual ICollection<AspNetUserPreferences> AspNetUserPreferences { get; set; } // AspNetUserPreferences.FK_AspNetUserPreferences_Products
        public virtual ICollection<Cart> Carts { get; set; } // Cart.FK_Cart_Products
        public virtual ICollection<CartAttributes> CartAttributes { get; set; } // CartAttributes.FK_CartAttributes_Products
        public virtual ICollection<Offers> Offers { get; set; } // Offers.FK_Offers_Products
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } // OrderDetails.FK_OrderDetails_Products
        public virtual ICollection<OrderDetailsAttributes> OrderDetailsAttributes { get; set; } // OrderDetailsAttributes.FK_OrderDetailsAttributes_Products
        public virtual ICollection<ProductAttributes> ProductAttributes { get; set; } // ProductAttributes.FK_ProductAttributes_Products
        public virtual ICollection<ProductReview> ProductReviews { get; set; } // ProductReview.FK_ProductReview_Products
        public virtual ICollection<Suggestions> Suggestions { get; set; } // Suggestions.FK__Suggestio__Produ__282DF8C2
        public virtual ICollection<TierPricing> TierPricings { get; set; } // TierPricing.FK_TierPricing_Products
        public virtual ICollection<WishList> WishLists { get; set; } // WishList.FK__WishList__Produc__1AD3FDA4

        // Foreign keys
        public virtual Categories Categories { get; set; } //  FK_Products_Categories

        public Products()
        {
            IsActive = true;
            IsDeleted = false;
            ApplyGst = false;
            AspNetUserPreferences = new List<AspNetUserPreferences>();
            Carts = new List<Cart>();
            CartAttributes = new List<CartAttributes>();
            Offers = new List<Offers>();
            OrderDetails = new List<OrderDetails>();
            OrderDetailsAttributes = new List<OrderDetailsAttributes>();
            ProductAttributes = new List<ProductAttributes>();
            ProductReviews = new List<ProductReview>();
            Suggestions = new List<Suggestions>();
            TierPricings = new List<TierPricing>();
            WishLists = new List<WishList>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
