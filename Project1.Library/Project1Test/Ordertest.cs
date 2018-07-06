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
            Assert.Equal("c", col.pizzalist[0]);

        }

        [Fact]
        public void addpepperonipizzaisadded()
        {
            //Arrange
            var col = new Order();

            //Act
            col.addpepperonipizza();

            //Assert
            Assert.Equal("p", col.pizzalist[0]);

        }

        [Fact]
        public void addsausagepizzaisadded()
        {
            //Arrange
            var col = new Order();

            //Act
            col.addsausagepizza();

            //Assert
            Assert.Equal("s", col.pizzalist[0]);

        }

    }
}
