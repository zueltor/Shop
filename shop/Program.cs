using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string name;
            var shop = new Shop();
            int space_pos;
            int amount;
            int info;

            Console.WriteLine("Использование: товар количество - добавить товар в корзину\n" +
                              "Корзина - вывести содержимое корзины\n" +
                              "Очистить корзину - очистить корзину\n" +
                              "Выйти - закрыть программу");
            while (true)
            {
                line = Console.ReadLine();
                if (line.Equals("корзина", StringComparison.InvariantCultureIgnoreCase))
                {
                    shop.Print();
                    continue;
                }
                if (line.Equals("очистить корзину", StringComparison.InvariantCultureIgnoreCase))
                {
                    shop.Erase();
                    Console.WriteLine("Корзина очищена");
                    continue;
                }
                if (line.Equals("выйти", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                space_pos = line.IndexOf(" ");
                if (space_pos == -1)
                {
                    Console.WriteLine("Не найдено количество товара в запросе");
                    continue;
                }
                name = line.Substring(0, space_pos);
                if(int.TryParse(line.Substring(space_pos, line.Length - space_pos), out amount) == false){
                    Console.WriteLine("Не удалось определить количество товара");
                    continue;
                }
                info = shop.Info(name, amount);
                if (info == 0)
                {
                    Console.WriteLine("Товара нет в наличии");
                }
                else if (info == 1)
                {
                    Console.WriteLine("Товара не хватает в достаточном количестве, в корзину добавлено всё, что имеется");
                }
                else if (info == 2)
                {
                    Console.WriteLine("Товар отсутствует в справочнике");
                }
            }
        }
    }
}
