using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Data.Models;
using Shop.Data.Models.Interfaces;
using Shop.Data.Models.ShippingMethods;
using Shop.ViewModels;

namespace Shop.Controllers
{
    /// <summary>
    /// Контроллер для страницы корзины покупок
    /// </summary>
    public class CartController : Controller
    {
        private readonly IRepository _repository;
        private readonly Cart _cart;

        private IShippingMethod _shippingMethod;

        /// <summary>
        /// Конструктор контроллера для страницы корзины покупок
        /// </summary>
        /// <param name="repository">репозиторий с коллекцией товаров</param>
        /// <param name="cart">корзина покупок</param>
        public CartController(IRepository repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }

        /// <summary>
        /// Метод возвращающий представление корзины покупок
        /// </summary>
        /// <returns>представление корзины покупок</returns>
        public IActionResult Index(string value)
        {
            if (!_cart.Items.Any())
                return RedirectToAction("EmptyCart");

            if (value == null)   
                ViewData["shippingMethods"] = new SelectList(_repository.ShippingMethods, "Value", "Name");
            else
                ViewData["shippingMethods"] = new SelectList(_repository.ShippingMethods, "Value", "Name", value);

            ViewBag.Title = "Корзина";

            _shippingMethod = value switch
            {
                "0" => new Pickup(),
                "250" => new MailDelivery(),
                "600" => new ExpressDelivery(),
                _ => new MailDelivery()
            };

            var obj = new ShopCartViewModel(_cart, _shippingMethod);

            return View(obj);
        }

        /// <summary>
        /// Метод перенаправляющий на страницу с уведомлением о статусе корзины
        /// </summary>
        /// <returns>страница</returns>
        public IActionResult EmptyCart()
        {
            ViewBag.Message = "В вашей корзине пусто :(";
            return View();
        }

        /// <summary>
        /// Метод перенаправляющий на страницу корзины покупок
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>перенаправление на страницу с корзиной покупок</returns>
        public IActionResult AddItemToCart(int id)
        {
            var item = _repository.Goods.FirstOrDefault(i => i.Id == id);

            if (item != null)
                _cart.AddItemToCart(item);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Метод перенаправляющий на страницу корзины покупок
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>перенаправление на страницу с корзиной покупок</returns>
        public IActionResult AddQuantity(int id)
        {
            var item = _repository.Goods.FirstOrDefault(i => i.Id == id);

            if (item != null)
                _cart.AddItemQuantity(item);

            return RedirectToAction("Index",new {});
        }

        /// <summary>
        /// Метод перенаправляющий на страницу корзины покупок
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>перенаправление на страницу с корзиной покупок</returns>
        public IActionResult RemoveQuantity(int id)
        {
            var item = _repository.Goods.FirstOrDefault(i => i.Id == id);

            if (item != null)
                _cart.RemoveItemQuantity(item);

            return Redirect(_cart.Items.Count == 0 ? "~/" : "~/Cart/Index");
        }
    }
}
