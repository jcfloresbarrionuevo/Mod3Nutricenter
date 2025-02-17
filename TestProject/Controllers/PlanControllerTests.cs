using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutriCenter.API.Controllers;
using NutriCenter.Aplication.Commands;
using NutriCenter.Aplication.Queries;
using NutriCenter.Infraestructure.Interfaces;

namespace TestProject.Controllers
{
    [TestClass]
    public class PlanControllerTests
    {
        private Mock<CrearPlanCommandHandler> _mockCrearHandler;
        private Mock<ObtenerPlanQueryHandler> _mockObtenerHandler;
        //private PlanController _controller;

        public PlanControllerTests()
        {
            var mockPlanRepository = new Mock<IPlanAlimentarioRepositorio>();
            var mockRecetas = new Mock<IPlanRecetaTiempoRepositorio>();
            _mockCrearHandler = new Mock<CrearPlanCommandHandler>(mockPlanRepository.Object, mockRecetas.Object);
            
            var mockMapper = new Mock<IMapper>();
            _mockObtenerHandler = new Mock<ObtenerPlanQueryHandler>(mockPlanRepository.Object, mockMapper.Object);
        }

        [TestMethod]
        public async Task CrearPlan_ReturnOkResult()
        {
            //Arrange
            var command = new CrearPlanCommand(
                Nombre: "Plan alimentario ROBERT",
                DuracionDias: 60,
                CedulaCliente: "23456",
                NombreCliente: "ROBERTO GUTIERREZ",
                Detalle: new List<CrearRecetasTiempos>
                            {
                                new CrearRecetasTiempos(9,"Desayuno bajo en calorias",12,"Desayuno"),
                                new CrearRecetasTiempos(11,"control energetico", 14, "Almuerzo")
                            }
                );

            var _controller = new PlanController(_mockCrearHandler.Object, _mockObtenerHandler.Object);

            //Act
            var result=await _controller.CrearPlan(command) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result,typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Plan creado exitosamente.",okResult.Value);
        }

        [TestMethod]
        public async Task ObtenerPlan_ReturnOkResult()
        {
            //Arrange
            var _controller = new PlanController(_mockCrearHandler.Object,_mockObtenerHandler.Object);
            
            //Act
            var result=await _controller.ObtenerPlan() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200,result.StatusCode);
        }
    }
}
