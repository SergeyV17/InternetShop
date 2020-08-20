using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Models.Interfaces;

namespace Shop.Controllers
{
    /// <summary>
    /// Контроллер страницы заказа
    /// </summary>
    public class OrderController: Controller
    {
        private readonly ICreateOrder _createOrder;
        private readonly Cart _cart;

        /// <summary>
        /// Конструктор заказа
        /// </summary>
        /// <param name="cart"></param>
        public OrderController(ICreateOrder createOrder, Cart cart)
        {
            _createOrder = createOrder;
            _cart = cart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if (!_cart.Items.Any())
                ModelState.AddModelError("","В корзине пусто");

            if (ModelState.IsValid)
            {
                _createOrder.CreateNewOrder(order);
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
