using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Frontend.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderHistoryList _orderHistoryList = new()
        {
            OrderHistory = new List<OrderViewModel>()
            {
                new OrderViewModel()
                {
                    OrderId = "8237490",
                    OrderDate = DateTime.Now,
                    OrderStatus = "Delivered",
                    OrderPrice = 389,
                    Products = new()
                    {
                        "Smet",
                        "Smet",
                        "Ostbågar"
                    }
                },
                new OrderViewModel()
                {
                    OrderId = "4262454",
                    OrderDate = DateTime.Now.AddDays(-20),
                    OrderStatus = "Shipping",
                    OrderPrice = 799,
                    Products = new()
                    {
                        "Smet",
                        "Smet",
                        "Ostbågar"
                    }
                },
                new OrderViewModel()
                {
                    OrderId = "3950275",
                    OrderDate = DateTime.Now.AddDays(-345),
                    OrderStatus = "Shipping",
                    OrderPrice = 799,
                    Products = new()
                    {
                        "Smet",
                        "Smet",
                        "Ostbågar",
                        "Smet",
                        "Smet",
                        "Ostbågar",
                        "Smet",
                        "Smet",
                        "Ostbågar"
                    }
                },
                new OrderViewModel()
                {
                    OrderId = "2057694",
                    OrderDate = DateTime.Now.AddDays(-123),
                    OrderStatus = "Canceled",
                    OrderPrice = 799,
                    Products = new()
                    {
                        "Smet",
                        "Smet",
                        "Ostbågar"
                    }
                },
            }
        };


        [Route("/orderhistory")]
        public IActionResult Index()
        {
            return View(_orderHistoryList);
        }
    }
}
