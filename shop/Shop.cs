using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Shop
    {
        public Shop()
        {
            item = new Dictionary<string, ItemInfo>(StringComparer.OrdinalIgnoreCase);
            users = new Dictionary<string, int>();
            cart = new Dictionary<string, UserCart>();
            item.Add("Велосипед", new ItemInfo(999.90, 20));
            item.Add("Носки", new ItemInfo(20, 13));
            item.Add("Бумага", new ItemInfo(11.1, 4));
            item.Add("Ручка", new ItemInfo(39, 50));
            item.Add("Банан", new ItemInfo(10, 0));
            users.Add("Медведев Сергей Дмитриевич", 123);
            users.Add("Кренделев Александр Юрьевич", 421);
            foreach (var u in users)
            {
                cart[u.Key] = new UserCart();
            }
            current_user = "Кренделев Александр Юрьевич";
        }
        public int Info(string name, int amount)
        {
            if (item.TryGetValue(name, out ItemInfo iteminfo))
            {
                if (iteminfo.Get_amount() == 0)
                {
                    return 0;
                }
                cart[current_user].Add(name, amount);
                if (cart[current_user].Get_amount(name) > item[name].Get_amount())
                {
                    cart[current_user].Set_amount(name, item[name].Get_amount());
                    return 1;
                }
                else return 3;
            }
            else return 2;
        }

        public void Erase()
        {
            cart[current_user].Erase();
        }

        public void Print()
        {
            if (cart[current_user].Is_empty())
            {
                Console.WriteLine("Корзина Пуста");
                return;
            }
            Console.WriteLine("Заказ № " +users[current_user]+" "+current_user+" "+DateTime.Now);
            Console.WriteLine("Название\tЦена\tКоличество\tСумма");
            double cost = 0;
            Dictionary<string, int> user_cart = cart[current_user].Get_dictionary();
            foreach (var item in user_cart)
            {
                cost += this.item[item.Key].Get_price() * item.Value;
                Console.WriteLine(item.Key + "\t\t" + this.item[item.Key].Get_price() + "\t" + item.Value + "\t" +
                    this.item[item.Key].Get_price() * item.Value);
            }
            Console.WriteLine("Итого: " + cost);
        }

        private Dictionary<string, ItemInfo> item;  //словарь товаров, с ценой и количеством
        private Dictionary<string,int> users;       //словарь пользователей и номеров заказов (не меняется в ходе программы :( )
        private string current_user;                //текущий пользователь
        private Dictionary<string, UserCart> cart;  //словарь корзин ползователей

    }
}
