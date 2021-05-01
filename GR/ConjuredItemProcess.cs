using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR
{
    public class ConjuredItemProcess : ProcessInventory
    {
        public override void UpdateItemInventory(Item item)
        {
            if (--item.SellIn < 0)
                item.Quality = item.Quality - 4;
            else
                item.Quality = item.Quality - 2;

            if (item.Quality < 0)
                item.Quality = 0;
        }
    }
}