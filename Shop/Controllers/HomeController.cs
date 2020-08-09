using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController: Controller
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Конструктор контроллера для страницы корзины покупок
        /// </summary>
        /// <param name="repository">репозиторий с коллекцией товаров</param>
        /// <param name="shopCart">корзина покупок</param>
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Главная";
            var obj = new HomeViewModel(_repository.Goods);
            return View(obj);
        }
    }
}
