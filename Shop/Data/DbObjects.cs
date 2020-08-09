using Shop.Data.Models;
using System.Linq;

namespace Shop.Data
{
    /// <summary>
    /// Класс работы с объектами в БД
    /// </summary>
    public class DbObjects
    {
        /// <summary>
        /// Метод заполнения таблиц в БД при инициализации
        /// </summary>
        /// <param name="context">контекст БД</param>
        public static void Initial(AppDbContext context)
        {
            if (!context.Goods.Any())
                context.Goods.AddRange(
                    new Good( "78FGH8", "WellDone Ariston Скороварка", 547.45m),
                    new Good( "89ghtX", "Fenix Electrolux Светильник", 1547.45m),
                    new Good("XFGH67", "D20SSD Airoswiss Мойка воздуха", 130m));

            context.SaveChanges();
        }
    }
}
