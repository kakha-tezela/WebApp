using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using WebApplication.Controllers;
using WebApplication.Core;
using WebApplication.Core.Repositories;
using WebApplication.DTO;
using WebApplication.Models;
using WebApplication.App_Start;
using System.Collections.Generic;
using WebApplication.ViewModels;

namespace ApiUnitTests
{
    [TestFixture]
    class StatementControllerTests
    {
        Mock<IStatementRepository> FakeRepository;
        Mock<IUnitOfWork> UnitOfWork;


        public StatementControllerTests()
        {
            AutoMapperConfig.Initialize();
            FakeRepository = new Mock<IStatementRepository>();
            UnitOfWork = new Mock<IUnitOfWork>();
        }



        [Test]
        public void GetAll_WhenCalled_ReturnsOk()
        {
            UnitOfWork.Setup(u => u.StatementRepository).Returns(FakeRepository.Object);

            FakeRepository.Setup(r => r.GetAll(1,20, new StatementFilter()))
                .Returns(new List<Statement>());


            var controller = new StatementsController();
            controller._unitOfWork = UnitOfWork.Object;
            var result = controller.GetAll(1, 20, new StatementFilter());


            Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<StatementsViewModel>>());
        }








        [Test]
        public void Get_StatementRetrieved_ReturnsOk()
        {
            UnitOfWork.Setup(u => u.StatementRepository).Returns(FakeRepository.Object);
            FakeRepository.Setup(r => r.GetById(1)).Returns(new Statement());


            var controller = new StatementsController();
            controller._unitOfWork = UnitOfWork.Object;
            var result = controller.Get(1);


            Assert.That(result, Is.TypeOf<OkNegotiatedContentResult<StatementDTO>>());
        }




        [Test]
        public void Get_StatementNotFound_ReturnsNotFound()
        {
            UnitOfWork.Setup(u => u.StatementRepository).Returns(FakeRepository.Object);
            FakeRepository.Setup(r => r.GetById(1)).Returns((Statement)null);


            var controller = new StatementsController();
            controller._unitOfWork = UnitOfWork.Object;
            var result = controller.Get(1);


            Assert.That(result,Is.TypeOf<NotFoundResult>());
        }
    }
}
