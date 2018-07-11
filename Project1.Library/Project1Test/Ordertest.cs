using Project1.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project1Test
{
    public class Ordertest
    {
        [Fact]
        public void addcheesepizzaisadded()
        {
            //Arrange
            var col = new Order();

            //Act
            col.addcheesepizza();

            
            //Assert
            //Assert.Equal("c", col.pizzalist[0]);

        }

       /* [Theory]
        [InlineData]
        public void addcheesepizzaisaddedifmaximumpriceisreacheddont()
        {
            //Arrange
            var col = new Order();

            //Act
            col.addcheesepizza();


            //Assert
            Assert.Equal("c", col.pizzalist[0]);

         */

        [Fact]
        public void addpepperonipizzaisadded()
        {
            //Arrange
            var col = new Order();

            //Act
            col.addpepperonipizza();


            //Assert
            //Assert.Equal("p", col.pizzalist[0]);

        }

        [Fact]
        public void addsausagepizzaisadded()
        {
            //Arrange
            var col = new Order();

            //Act
            col.addsausagepizza();


            //Assert
            //Assert.Equal("s", col.pizzalist[0]);

        }

        [Theory]
        [InlineData(6, 2, 3)]
        public void inventorycheckifcheeseisntenoughforpizza(int a, int b, int c)
        {
            //Arrange
            var col = new Order();
            Location g = new Location();
            bool result;
            col.cheesepizza = a;
            col.pepperonipizza = b;
            col.sausagepizza = c; 

            //Act
            result = col.Inventorycheck(g);

            //Assert
            Assert.True(!result);

        }   
        
    }
}
