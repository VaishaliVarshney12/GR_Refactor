using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR
{
    public class BackstagePassesProcess : ProcessInventory
    {
        public override void UpdateItemInventory(Item item)
        {
            if (--item.SellIn < 0)
                item.Quality = item.Quality - item.Quality;
            else if (item.SellIn < 6)
                item.Quality += 3;
            else if (item.SellIn < 11)
                item.Quality += 2;
            else
                item.Quality++;

            if (item.Quality > 50)
                item.Quality = 50;
        }
    }
}