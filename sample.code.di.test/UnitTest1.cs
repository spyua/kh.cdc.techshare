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
            // Arrange: �]�w�e�⦸�I�s Send() �ɥ�X���`�A�ĤT�����\
            _mockService
                .SetupSequence(service => service.Send(It.IsAny<string>()))
                .Throws(new Exception("Mock failure"))
                .Throws(new Exception("Mock failure"))
                .Pass(); // �ĤT�����\

            // Act
            bool result = _manager.Notify("Retry message");

            // Assert
            Assert.IsTrue(result, "���Ӧb���իᦨ�\�o�e");

            // �T�{ Send() �Q�I�s�F�T��
            _mockService.Verify(service => service.Send(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void TestNotify_FailsAfterMaxRetries()
        {
            // Arrange: �]�w�C���I�s Send() ����X���`
            _mockService
                .Setup(service => service.Send(It.IsAny<string>()))
                .Throws(new Exception("Mock failure"));

            // Act
            bool result = _manager.Notify("Failure message");

            // Assert
            Assert.IsFalse(result, "���b�Ҧ����իᥢ��");

            // �T�{ Send() �Q�I�s�F�T���]�̤j���զ��ơ^
            _mockService.Verify(service => service.Send(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}