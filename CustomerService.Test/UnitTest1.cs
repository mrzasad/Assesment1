using DBCore.Repository;
using Grocery.Models.Dto.CustomerDto;
using Grocery.Service.CustomerServices;
using NUnit.Framework;
using System.IO;

namespace CustomerServices.Test
{
    public class Tests
    {
        CustomerService service = new CustomerService(new CustomerRepository());
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CreateTest()
        {
            var result1 = service.create(new CreateCustomerDto()
            {
                CustomerName = "asad1",
                CustomerEmail = "asad1@gmail.com"
            }
            );
            var result2 = service.create(new CreateCustomerDto()
            {
                CustomerName = "asad2",
                CustomerEmail = "asad2@gmail.com"
            }
            );
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreEqual("Saved", result1.Message);
            Assert.AreEqual("Saved", result2.Message);
            Assert.IsTrue(File.Exists("db.json"));
        }
        [Test]
        public void UpdateTest()
        {
            var result = service.update(new UpdateCustomerDto()
            {
                CustomerId = 1,
                CustomerName = "asad1-updated",
                CustomerEmail = "asad1@gmail.com"
            }
            );
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated", result.Message);
        }
        [Test]
        public void GetAllTest()
        {
            var result = service.Get();
            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Count,1);
        }
        [Test]
        public void GetByIdTest()
        {
            var result = service.Get(1);
            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.CustomerId, 1);
        }
    }
}