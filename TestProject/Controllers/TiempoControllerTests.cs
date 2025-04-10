using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NutriCenter.API.Controllers;
using NutriCenter.Aplication.Commands;
using NutriCenter.Aplication.Queries;
using NutriCenter.Infraestructure.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject.Controllers
{
    [TestClass]
    public class TiempoControllerTests
    {
        private Mock<CrearTiempoCommandHandler> _mockCrearHandler;
        private Mock<ObtenerTiempoQueryHandler> _mockObtenerHandler;
        //private TiempoController _controller;

        public TiempoControllerTests()
        {
            var mockTiempoRepository = new Mock<ITiempoComidaRepositorio>();
            var mockMapper = new Mock<IMapper>();

            _mockCrearHandler = new Mock<CrearTiempoCommandHandler>(mockTiempoRepository.Object);
            _mockObtenerHandler = new Mock<ObtenerTiempoQueryHandler>(mockTiempoRepository.Object, mockMapper.Object);
        }

        [TestMethod]
        public async Task CrearTiempo_ReturnsOkResult()
        {
            // Arrange
            var command = new CrearTiempoCommand(
                Nombre: "Desayuno",
                Hora: new TimeSpan(8, 30, 0)
                );
            var _controller = new TiempoController(_mockCrearHandler.Object, _mockObtenerHandler.Object);

            // Act            
            var result = await _controller.CrearTiempo(command) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Tiempo creado exitosamente.", okResult.Value);
        }

        [TestMethod]
        public async Task ObtenerTiempos_ReturnsOkResult()
        {
            // Arrange
            var _controller = new TiempoController(_mockCrearHandler.Object, _mockObtenerHandler.Object);

            // Act
            var result = await _controller.ObtenerTiempos() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
