﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryApp.Models.ApiModels
{
    public class AddToCartModel
    {
        public int ProductId { get; set; }
        public int OfferId { get; set; }
    }
}