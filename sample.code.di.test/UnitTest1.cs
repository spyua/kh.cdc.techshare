using Moq;
using sample.code.service.InterfaceSample;

namespace sample.code.service.test
{
    public class Tests
    {

        private NotificationManager _manager;
        private Mock<INotificationService> _mockService;



        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<INotificationService>();
            _manager = new NotificationManager(_mockService.Object);
        }

        [Test]
        public void TestNotify_RetriesOnFailure()
        {
            // Arrange: 設定前兩次呼叫 Send() 時丟出異常，第三次成功
            _mockService
                .SetupSequence(service => service.Send(It.IsAny<string>()))
                .Throws(new Exception("Mock failure"))
                .Throws(new Exception("Mock failure"))
                .Pass(); // 第三次成功

            // Act
            bool result = _manager.Notify("Retry message");

            // Assert
            Assert.IsTrue(result, "應該在重試後成功發送");

            // 確認 Send() 被呼叫了三次
            _mockService.Verify(service => service.Send(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void TestNotify_FailsAfterMaxRetries()
        {
            // Arrange: 設定每次呼叫 Send() 都丟出異常
            _mockService
                .Setup(service => service.Send(It.IsAny<string>()))
                .Throws(new Exception("Mock failure"));

            // Act
            bool result = _manager.Notify("Failure message");

            // Assert
            Assert.IsFalse(result, "應在所有重試後失敗");

            // 確認 Send() 被呼叫了三次（最大重試次數）
            _mockService.Verify(service => service.Send(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}