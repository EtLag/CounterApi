using CounterApi.Controllers;
using CounterApi.Models;
using CounterApi.Repository;
using Moq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CounterApiTests
{
    public class CounterTests
    {
        private Mock<ICounterRepository> counterRepository;
        private List<Counter> counters;
        private Mock<CountersController> counterController;
        [SetUp]
        public void Setup()
        {
            counterRepository = new Mock<ICounterRepository>();
            counters = new List<Counter>();
            counters.Add(new Counter { Id = 1, Name = "GenericCounter", Number = 5 });
            counters.Add(new Counter { Id = 2, Name = "a", Number = 3 });
            counters.Add(new Counter { Id = 3, Name = "b", Number = 10 });
        }

        [Test]
        public void TestGetAllCounters()
        {
            //Arrange
            counterRepository.Setup(x => x.GetAllCounters()).Returns(counters);



            //Act
            var allCounters = counterRepository.Object.GetAllCounters();

            //Assert
            Assert.IsTrue(allCounters.Count == 3);
            Assert.That(allCounters, Is.EqualTo(counters));
        }

        [Test]
        public void TestGetOneCounter()
        {
            //Arrange
            counterRepository.Setup(x => x.GetAllCounters()).Returns(counters);
            counterRepository.Setup(x => x.GetCounter("GenericCounter")).Returns(counters[0]);
            counterRepository.Setup(x => x.GetCounter("a")).Returns(counters[1]);
            counterRepository.Setup(x => x.GetCounter("b")).Returns(counters[2]);

            //Act
            var oneCounter = counterRepository.Object.GetCounter("a");

            //Assert
            Assert.That(oneCounter, Is.EqualTo(counters[1]));
        }
    }
}