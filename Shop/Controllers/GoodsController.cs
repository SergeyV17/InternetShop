using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    /// <summary>
    /// Контроллер для страницы с товарами
    /// </summary>
    public class GoodsController : Controller
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Конструктор контроллера для страницы с товарами
        /// </summary>
        /// <param name="repository">репозиторий с коллекцией товаров</param>
        public GoodsController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Метод возвращающий представление с коллекцией товаров
        /// </summary>
        /// <returns>представление с коллекцией товаров</returns>
        public ViewResult ListOfGoods()
        {
            ViewBag.Title = "Страница с товарами";
            var obj = new GoodsViewModel(_repository.Goods);
            return View(obj);
        }
    }
}
