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
    public class RecetasControllerTests
    {
        private Mock<CrearRecetasCommandHandler> _mockCrearHandler;
        private Mock<ObtenerRecetasQueryHandler> _mockObtenerHandler;
        private RecetasController _controller;        
        public RecetasControllerTests()
        {
            var mockRecetasRepository = new Mock<IRecetasRepositorio>();
            _mockCrearHandler = new Mock<CrearRecetasCommandHandler>(mockRecetasRepository.Object);

            var mockMapper = new Mock<IMapper>();
            _mockObtenerHandler = new Mock<ObtenerRecetasQueryHandler>(mockRecetasRepository.Object, mockMapper.Object);            
        }

        [TestMethod]
        public async Task CrearReceta_ReturnsOkResult()
        {
            // Arrange
            var command = new CrearRecetaCommand(
                            Nombre: "Receta Ejemplo",
                            Descripcion: "Una descripción de ejemplo",
                            CostoMonto: 100.50m,
                            CostoMoneda: "USD",
                            Ingredientes: new List<CrearIngredienteCommand>
                            {
                                new CrearIngredienteCommand("Ingrediente 1",2,"kg"),
                                new CrearIngredienteCommand("Ingrediente 2", 1, "l")
                            });

            var _controller = new RecetasController(_mockCrearHandler.Object, _mockObtenerHandler.Object);

            // Act
            var result = await _controller.CrearReceta(command) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Receta creada exitosamente.", okResult.Value);
        }

        [TestMethod]
        public async Task ObtenerRecetas_ReturnsOkResult()
        {

            // Arrange
            var _controller = new RecetasController(_mockCrearHandler.Object, _mockObtenerHandler.Object);

            // Act
            var result = await _controller.ObtenerRecetas() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
