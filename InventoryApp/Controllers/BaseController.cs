﻿using InventoryApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    [ETag]
    [CompressFilter]
    [WhitespaceFilter]
    public class BaseController : Controller
    {
        
    }
}