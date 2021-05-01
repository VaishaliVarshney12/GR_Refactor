using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR
{
    public class AgedBrieProcess : ProcessInventory
    {
        public override void UpdateItemInventory(Item item)
        {
            if (--item.SellIn < 0)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality++;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}