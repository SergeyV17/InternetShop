using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Models.Interfaces;

namespace Shop.Controllers
{
    public class OrderController: Controller
    {
        private readonly IOrders _orders;
        private readonly ShopCart _shopCart;

        public OrderController(IOrders orders, ShopCart shopCart)
        {
            _orders = orders;
            _shopCart = shopCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if (!_shopCart.Items.Any())
                ModelState.AddModelError("","В корзине пусто");

            if (ModelState.IsValid)
            {
                _orders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Закакз успешно обработан";
            return View();
        }
    }
}
