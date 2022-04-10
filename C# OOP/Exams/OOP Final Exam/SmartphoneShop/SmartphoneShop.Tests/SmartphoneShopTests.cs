using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
       [Test]

       public void TestConstr()
        {
            var phone = new Smartphone("Nokia", 20);
            Shop shop = new Shop(1);
            Assert.IsNotNull(shop);
            Assert.Throws<ArgumentException>(() => shop = new Shop(-1));
            shop.Add(phone);
            Assert.AreEqual(1,shop.Count);

        }
        [Test]

        public void TestAdd()
        {
            var phone = new Smartphone("Nokia", 20);
            var phone2 = new Smartphone("MOt", 20);
            var phone3 = new Smartphone("Nokia", 30);
            var phone4 = new Smartphone("Nik", 30);
            Shop shop = new Shop(2);
           
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(()=>shop.Add(phone3));
            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(()=>shop.Add(phone4));
            

        }
        [Test]

        public void TestRemove()
        {
            var phone = new Smartphone("Nokia", 20);
            var phone2 = new Smartphone("MOt", 20);
            Shop shop = new Shop(1);

            shop.Add(phone);
            shop.Remove("Nokia");
            Assert.AreEqual(0,shop.Count);
            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Sams"));

        }

        [Test]

        public void TestPhone()
        {
            var phone = new Smartphone("Nokia", 20);
            var phone2 = new Smartphone("MOt", 20);
            Shop shop = new Shop(4);

            shop.Add(phone);
            shop.Add(phone2);
           
          
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Sam",37));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia",37));
            shop.TestPhone("Nokia", 10);
            Assert.AreEqual(10, phone.CurrentBateryCharge);

        }

        [Test]

        public void TestCharge()
        {
            var phone = new Smartphone("Nokia", 20);
            var phone2 = new Smartphone("MOt", 20);
            Shop shop = new Shop(4);

            shop.Add(phone);
            shop.Add(phone2);


            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Sam"));
            shop.TestPhone("Nokia", 10);
            shop.ChargePhone("Nokia");
            Assert.AreEqual(20, phone.CurrentBateryCharge);

        }
    }
}