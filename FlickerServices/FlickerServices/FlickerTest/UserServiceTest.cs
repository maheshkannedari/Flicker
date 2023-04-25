using UserService.Entities;
using UserService.Services;
using Moq;
using UserService.Respository;

namespace FlickerTest
{
    [TestFixture]
    public class UserServiceTest
    {
        UserSer us;
        User u;
        
        

        [SetUp]
        public void initilaise()
        {
            u = new User()
            {
                email = "Mahesh",

                password = "123"
            };
        }

        [Test]
        public void TestAddUserSuccess()
        {
            var mockRepo = new Mock<IUserRepo>();
            us = new UserSer(mockRepo.Object);
            mockRepo.Setup(s => s.Insert(u)).Returns(true);
            var result = us.AddUser(u);
            Assert.AreEqual(true, result);
            /*var result = us.AddUser(u);
            Assert.AreEqual(true, result );*/
        }
        [Test]
        public void TestAddUserFail()
        {
            var mockRepo = new Mock<IUserRepo>();
            us = new UserSer(mockRepo.Object);
            var result = us.AddUser(null);
            Assert.AreEqual(false, result);
            /*Assert.Pass();*/
        }
        [Test]
        public void TestValidateSuccess()
        {
            var mockRepo = new Mock<IUserRepo>();
            us = new UserSer(mockRepo.Object);
            mockRepo.Setup(p => p.Validate(u)).Returns(true);
            var result = us.ValidateUser(u);
            Assert.AreEqual(true, result);
           
        }
        [TearDown]
        public void Release()
        {
            u = null;
            us = null;
        }
    }
}