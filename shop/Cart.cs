using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class UserCart
    {
        public UserCart()
        {
            user_cart = new Dictionary<string, int>();
        }

        public void Add(string name, int amount)
        {
            if (user_cart.ContainsKey(name))
            {
                user_cart[name] += amount;
            }
            else
            {
                user_cart.Add(name, amount);
            }
        }

        public int Get_amount(string name)
        {
            return user_cart[name];
        }

        public bool Is_empty()
        {
            return user_cart.Count() == 0;
        }

        public void Erase()
        {
            user_cart.Clear();
        }

        public void Set_amount(string name, int amount)
        {
            user_cart[name] = amount;
        }

        public Dictionary<string, int> Get_dictionary()
        {
            return user_cart;
        }

        private Dictionary<string, int> user_cart; //корзина пользователя
    }
}
