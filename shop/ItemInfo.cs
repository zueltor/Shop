using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ItemInfo
    {
        public ItemInfo(double _price, int _amount)
        {
            price = _price;
            amount = _amount;
        }

        public int Get_amount()
        {
            return amount;
        }

        public double Get_price()
        {
            return price;
        }

        private double price;  
        private int amount;
    }
}
