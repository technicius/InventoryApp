﻿using InventoryApp.Areas.Admin.Models;
using InventoryApp.Controllers;
using InventoryApp.Models;
using InventoryApp_DL.Entities;
using InventoryApp_DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static InventoryApp.Helpers.Enums;

namespace InventoryApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            (List<AspNetUsers>, int) objUsers = Repository<AspNetUsers>.GetEntityListForQuery(null);
            (List<Products>, int) objProducts = Repository<Products>.GetEntityListForQuery(null);
            (List<Categories>, int) objCategories = Repository<Categories>.GetEntityListForQuery(null);
            string cancelOrder = Helpers.Enums.GetEnumDescription((Helpers.Enums.OrderStatus.Cancelled));
            (List<Orders>, int) objOrders = Repository<Orders>.GetEntityListForQuery(null);
            var objCancelledOrders = objOrders.Item1.Where(x => x.OrderStatus == cancelOrder);

            return View(new DashboardModel
            {
                CategoryCount = objCategories.Item2,
                OrderCount = objOrders.Item2,
                ProductCount = objProducts.Item2,
                SellerCount = objUsers.Item2,
                TodayOrderCount = objOrders.Item1.Where(x=>x.CreatedOn.Date == DateTime.Now.Date).Count(),
                YesterdayOrderCount = objOrders.Item1.Where(x => x.CreatedOn.Date == DateTime.Now.AddDays(-1).Date).Count(),
                CurrentMonthOrderCount = objOrders.Item1.Where(x => x.CreatedOn.Month == DateTime.Now.Month).Count(),
                LastMonthOrderCount = objOrders.Item1.Where(x => x.CreatedOn.Month == DateTime.Now.AddMonths(-1).Month).Count(),

                CancelledTodayOrderCount = objCancelledOrders.Where(x => x.CreatedOn.Date == DateTime.Now.Date && x.OrderStatus== GetEnumDescription(OrderStatus.Cancelled)).Count(),
                CancelledOrderCount = objCancelledOrders.Where(x => x.CreatedOn.Date == DateTime.Now.AddDays(-1).Date && x.OrderStatus == GetEnumDescription(OrderStatus.Cancelled)).Count(),
                CancelledCurrentMonthOrderCount = objCancelledOrders.Where(x => x.CreatedOn.Month == DateTime.Now.Month && x.OrderStatus == GetEnumDescription(OrderStatus.Cancelled)).Count(),
                CancelledLastMonthOrderCount = objCancelledOrders.Where(x => x.CreatedOn.Month == DateTime.Now.AddMonths(-1).Month && x.OrderStatus == GetEnumDescription(OrderStatus.Cancelled)).Count(),

                TodayOrderPayment = objOrders.Item1.Where(x => x.CreatedOn.Date == DateTime.Now.Date).Sum(x=>x.Total),
                YesterdayOrderPayment = objOrders.Item1.Where(x => x.CreatedOn.Date == DateTime.Now.AddDays(-1).Date).Sum(x => x.Total),
                CurrentMonthOrderPayment = objOrders.Item1.Where(x => x.CreatedOn.Month == DateTime.Now.Month).Sum(x => x.Total),
                LastMonthOrderPayment = objOrders.Item1.Where(x => x.CreatedOn.Month == DateTime.Now.AddMonths(-1).Month).Sum(x => x.Total),
                TotalPayment = objOrders.Item1.Sum(x => x.Total),
            });
        }
    }
}