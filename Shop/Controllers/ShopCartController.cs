using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Models.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    /// <summary>
    /// Контроллер для страницы корзины покупок
    /// </summary>
    public class ShopCartController: Controller
    {
        private readonly IRepository _repository;
        private readonly ShopCart _shopCart;

        /// <summary>
        /// Конструктор контроллера для страницы корзины покупок
        /// </summary>
        /// <param name="repository">репозиторий с коллекцией товаров</param>
        /// <param name="shopCart">корзина покупок</param>
        public ShopCartController(IRepository repository, ShopCart shopCart)
        {
            _repository = repository;
            _shopCart = shopCart;
        }

        /// <summary>
        /// Метод возвращающий представление корзины покупок
        /// </summary>
        /// <returns>представление корзины покупок</returns>
        public ViewResult Index()
        {
            ViewBag.Title = "Корзина";
            var obj = new ShopCartViewModel(_shopCart);

            return View(obj);
        }

        /// <summary>
        /// Метод перенаправляющий на страницу корзины покупок
        /// </summary>
        /// <param name="Id">id товара</param>
        /// <returns>перенаправление на страницу с корзиной покупок</returns>
        public RedirectToActionResult AddItemToCart(int Id)
        {
            var item = _repository.Goods.FirstOrDefault(i => i.Id == Id);

            if (item != null)
                _shopCart.AddItemToCart(item);

            return RedirectToAction("Index");
        }
    }
}
