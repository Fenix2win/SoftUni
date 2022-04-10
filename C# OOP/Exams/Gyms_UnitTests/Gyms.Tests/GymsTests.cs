using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [SetUp]
        public void AthleticList()
        {
            for (int i = 0; i < 10; i++)
            {
                var athlet = new Athlete($"Athlet{i}");
            }

        }


        [Test]
        public void TestConstructor()
        {
            var gym = new Gym("Lion", 50);

            Assert.AreEqual("Lion", gym.Name);
            Assert.AreEqual(50, gym.Capacity);
        }

        [TestCase(null, 34)]
        [TestCase("", 34)]
        public void TestConstructor(string name, int capacity)
        {

            Assert.Throws<ArgumentNullException>(() => new Gym(name, capacity));

        }
        [TestCase(-45)]
        [TestCase(-1)]
        public void TestTrowErrorInvalidCapacity(int capacity)
        {

            Assert.Throws<ArgumentException>(() => new Gym("Gosho", capacity));

        }
        [Test]
        public void TestAddAthletValid()
        {
            var gym = new Gym("Lion", 1);
            var athlet = new Athlete("Gosho");
            gym.AddAthlete(athlet);

            Assert.AreEqual(1, gym.Capacity);
        }
        [Test]
        public void TestThrowErrorAddAthletNoCapacity()
        {
            var gym = new Gym("Lion", 5);
            for (int i = 0; i < 5; i++)
            {

                var athlet = new Athlete($"Gosho{i}");
                gym.AddAthlete(athlet);
            }
            var athlet9 = new Athlete($"Gosho9");

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlet9));
        }

        [Test]
        public void TestThrowErrorRemoveAthletNoAthlet()
        {
            var gym = new Gym("Lion", 5);
            for (int i = 0; i < 5; i++)
            {

                var athlet = new Athlete($"Gosho{i}");
                gym.AddAthlete(athlet);
            }
            

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Gosho9"));
        }
        [Test]
        public void TestRemoveAthletValid()
        {
            var gym = new Gym("Lion", 6);
            for (int i = 0; i < 5; i++)
            {

                var athlet = new Athlete($"Gosho{i}");
                gym.AddAthlete(athlet);
            }
            gym.RemoveAthlete("Gosho2");

            Assert.AreEqual(4,gym.Count);
        }
        [Test]
        public void TestThrowErrorRecuestedAthletNoAthlet()
        {
            var gym = new Gym("Lion", 5);
            for (int i = 0; i < 5; i++)
            {

                var athlet = new Athlete($"Gosho{i}");
                gym.AddAthlete(athlet);
            }


            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Gosho9"));
        }
        [Test]
        public void TestRecuestedAthletValid()
        {
            var gym = new Gym("Lion", 10);
            for (int i = 0; i < 5; i++)
            {

                var athlet = new Athlete($"Gosho{i}");
                gym.AddAthlete(athlet);
            }

            var athlet9 = new Athlete("Gosho9");
            gym.AddAthlete(athlet9);
            Assert.IsTrue(gym.InjureAthlete("Gosho9")==athlet9);
        }

        [Test]
        public void TestReportActiveAthlets()
        {
            var gym = new Gym("Lion", 10);
           
                var athlet1 = new Athlete($"Gosho1");
                gym.AddAthlete(athlet1);
            var athlet2 = new Athlete($"Gosho2");
            gym.AddAthlete(athlet2);
            var athlet3 = new Athlete($"Gosho3");
            gym.AddAthlete(athlet3);

            gym.InjureAthlete("Gosho3");

            Assert.AreEqual("Active athletes at Lion: Gosho1, Gosho2", gym.Report());
        }
    }
}
