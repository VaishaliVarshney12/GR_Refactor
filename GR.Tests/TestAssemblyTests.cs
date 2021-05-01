using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GR.Tests
{
    public class TestAssemblyTests
    {

        private readonly Program _app;

        public TestAssemblyTests()
        {
            _app = new Program
            {
                Items = new List<Item>
        {
          new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}, //0
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0}, //1
                    new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20}, //2
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 1}, //3
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 50}, //4
                    new Item {Name = "Aged Brie", SellIn = 0, Quality = 0}, //5
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}, //6
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}, //7
                    new Item
          {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 15,
            Quality = 20
          }, //8
                    new Item
          {
            Name = "Backstage passes to a D498FJ9FJ2N concert",
            SellIn = 10,
            Quality = 30
          },//9
                    new Item
          {
            Name = "Backstage passes to a FH38F39DJ39 concert",
            SellIn = 5,
            Quality = 33
          },//10
                    new Item
          {
            Name = "Backstage passes to a I293JD92J44 concert",
            SellIn = 6,
            Quality = 50
          },//11
                    new Item
          {
            Name = "Backstage passes to a O2848394820 concert",
            SellIn = 1,
            Quality = 13
          },//12
                    new Item
          {
            Name = "Backstage passes to a DEEEADMEEET concert",
            SellIn = 0,
            Quality = 25
          },//13
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},//14
                    new Item {Name = "Conjured Mana Cake", SellIn = 10, Quality = 0},//15
                    new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 20}//16
                }
            };

            _app.UpdateInventory();
        }

        [Fact]
        public void DexterityVest_SellIn_ShouldDecreaseByOne()
        {

            Assert.Equal(9, _app.Items[0].SellIn);
        }

        [Fact]
        public void DexterityVest_Quality_ShouldDecreaseByOne()
        {
            Assert.Equal(19, _app.Items[0].Quality);
        }

        [Fact]
        public void DexterityVest_Quality_ShouldNotBeNegative()
        {
            Assert.Equal(0, _app.Items[1].Quality);
        }

        [Fact]
        public void DexterityVest_Quality_ShouldDecreaseByTwo()
        {
            Assert.Equal(18, _app.Items[2].Quality);
        }

        [Fact]
        public void AgedBrie_Quality_ShouldDecreaseByTwo()
        {
            Assert.Equal(2, _app.Items[3].Quality);
        }

        [Fact]
        public void AgedBrie_Quality_ShouldNotBeMoreThanFifty()
        {
            Assert.Equal(50, _app.Items[4].Quality);
        }

        [Fact]
        public void AgedBrie_Quality_ShouldIncreaseByTwo()
        {
            Assert.Equal(2, _app.Items[5].Quality);
        }

        [Fact]
        public void Elixir_Quality_ShouldIncreaseByOne()
        {
            Assert.Equal(6, _app.Items[6].Quality);
        }

        [Fact]
        public void Sulfuras_Quality_ShouldNotChange()
        {
            Assert.Equal(80, _app.Items[7].Quality);
        }

        [Fact]
        public void Backstage_Quality_ShouldIncreaseByOne()
        {
            Assert.Equal(21, _app.Items[8].Quality);
        }

        [Fact]
        public void Backstage_Quality_ShouldIncreaseByTwo()
        {
            Assert.Equal(32, _app.Items[9].Quality);
        }

        [Fact]
        public void Backstage_Quality_ShouldIncreaseByThree()
        {
            Assert.Equal(36, _app.Items[10].Quality);
            Assert.Equal(16, _app.Items[12].Quality);
        }

        [Fact]
        public void Backstage_Quality_ShouldNotBeMoreThanFifty()
        {
            Assert.Equal(50, _app.Items[11].Quality);
        }

        [Fact]
        public void Backstage_Quality_ShouldBeZero()
        {
            Assert.Equal(0, _app.Items[13].Quality);
        }

        [Fact]
        public void Conjured_Quality_ShouldDecreaseByTwo()
        {
            Assert.Equal(4, _app.Items[14].Quality);
        }

        [Fact]
        public void Conjured_Quality_ShouldNotBeNegative()
        {
            Assert.Equal(0, _app.Items[15].Quality);
        }

        [Fact]
        public void Conjured_Quality_ShouldDecreaseByFour()
        {
            Assert.Equal(16, _app.Items[16].Quality);
        }
    }
}