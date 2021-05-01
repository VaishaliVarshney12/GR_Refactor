using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR
{
    public class ProcessInventory
    {
        public virtual void UpdateItemInventory(Item item)
        {

            Console.WriteLine(" - Item: {0}", item.Name);
            if (item.Name != "Aged Brie" && !item.Name.Contains("Backstage passes"))
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name.Contains("Backstage passes"))
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name.Contains("Backstage passes"))
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        public static ProcessInventory GetInstance(Item item)
        {
            switch (GetCategory(item))
            {
                case CategoryEnum.Brie:
                    return new AgedBrieProcess();
                case CategoryEnum.BackstagePasses:
                    return new BackstagePassesProcess();
                case CategoryEnum.LegendaryItem:
                    return new LegendaryItemProcess();
                case CategoryEnum.ConjuredItem:
                    return new ConjuredItemProcess();
                case CategoryEnum.NormalItem:
                    return new NormalItemProcess();
                default:
                    return new ProcessInventory();
            }

        }

        public static CategoryEnum GetCategory(Item item)
        {
            if (item.Name.Contains(Constants.BRIE))
                return CategoryEnum.Brie;
            else if (item.Name.Contains(Constants.PASSES))
                return CategoryEnum.BackstagePasses;
            else if (item.Name.Contains(Constants.SULFURAS))
                return CategoryEnum.LegendaryItem;
            else if (item.Name.Contains(Constants.CONJURED))
                return CategoryEnum.ConjuredItem;
            else if (item.Name.Contains(Constants.ELIXIR))
                return CategoryEnum.Elixir;
            else
                return CategoryEnum.NormalItem;

        }
    }
}