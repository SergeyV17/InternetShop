using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;

namespace Shop.Controllers
{
    /// <summary>
    /// Контроллер страницы заказа
    /// </summary>
    public class OrderController: Controller
    {
        private readonly Cart _cart;

        /// <summary>
        /// Конструктор заказа
        /// </summary>
        /// <param name="cart"></param>
        public OrderController(Cart cart)
        {
            _cart = cart;
        }

        /// <summary>
        /// Метод перенаправляющий на страницу с оформлением заказа
        /// </summary>
        /// <returns></returns>
        public IActionResult CheckOut()
        {
            return View();
        }

        /// <summary>
        /// Метод пост перенаправляющий на страницу с оформлением заказа
        /// </summary>
        /// <param name="order">заказ</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if (!_cart.Items.Any())
                ModelState.AddModelError("","В корзине пусто");

            if (ModelState.IsValid)
            {
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        /// <summary>
        /// Метод перенаправляющий на страницу с уведомлением о завершении обработки заказа
        /// </summary>
        /// <returns></returns>
        public IActionResult Complete()
        {
            ViewBag.Message = "Закакз успешно обработан";
            return View();
        }
    }
}
