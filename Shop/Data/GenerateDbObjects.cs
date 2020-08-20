using Shop.Data.Models;
using System.Linq;

namespace Shop.Data
{
    /// <summary>
    /// Класс работы с объектами в БД
    /// </summary>
    public class GenerateDbObjects
    {
        /// <summary>
        /// Метод заполнения таблиц в БД при инициализации
        /// </summary>
        /// <param name="context">контекст БД</param>
        public static void Initial(AppDbContext context)
        {
            if (!context.Goods.Any())
                context.Goods.AddRange(
                    new Good {Name = "78FGH8", Articul = "WellDone Ariston Скороварка", Value = 547.45m},
                    new Good {Name = "89ghtX", Articul = "Fenix Electrolux Светильник", Value = 1547.45m },
                    new Good {Name = "XFGH67", Articul = "D20SSD Airoswiss Мойка воздуха", Value = 130m});

            context.SaveChanges();
        }
    }
}
