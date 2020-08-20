using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using Shop.Data.Models.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>
    public class HomeController: Controller
    {
        private readonly IRepository _repository;
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// Конструктор контроллера для страницы корзины покупок
        /// </summary>
        /// <param name="repository">репозиторий с коллекцией товаров</param>
        /// <param name="shopCart">корзина покупок</param>
        public HomeController(IRepository repository, AppDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Метод перенаправляющий на главную страницы
        /// </summary>
        /// <returns>главная страница</returns>
        public ViewResult Index()
        {
            ViewBag.Title = "Главная";
            var obj = new HomeViewModel(_repository.Goods);
            return View(obj);
        }

        /// <summary>
        /// Метод считывания xml файла
        /// </summary>
        /// <param name="uploadedFile">выбранный файл</param>
        /// <returns>перенаправление на главную</returns>
        [HttpPost]
        public async Task<IActionResult> ReadXml(IFormFile uploadedFile)
        {
            if (uploadedFile == null) return RedirectToAction("Index");

            // чтение и парсинг xml файла
            string xml;
            using (var reader = new StreamReader(uploadedFile.OpenReadStream()))
                xml = await reader.ReadToEndAsync();

            var col = XDocument.Parse(xml).Descendants("Goods").Descendants("Good").ToList();

            foreach (var item in col)
            {
                string name =
                    $"{item.Attribute("Name")?.Value}" +
                    $" {item.Element("Producer")?.Attribute("Name")?.Value}" +
                    $" {item.Element("GoodType")?.Attribute("Name")?.Value}";

                //добавление товаров в бд
                var good = new Good
                {
                    Name = name,
                    Articul = item.Attribute("Articul")?.Value,
                    Value = Convert.ToDecimal(item.Attribute("Value")?.Value, CultureInfo.InvariantCulture)
                };

                await _dbContext.Goods.AddAsync(good);
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
