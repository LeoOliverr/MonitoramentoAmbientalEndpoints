using MonitoramentoAmbientalEndpoints.Services;
using MonitoramentoAmbientalEndpoints.Controllers;
using MonitoramentoAmbientalEndpoints.Models;
using MonitoramentoAmbientalEndpoints.ViewModel;
using Moq;
using AutoMapper;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace MonitoramentoAmbientalEndpoints.Tests
{
    public class SensorControllerTests
    {
        private readonly Mock<ISensorService> _sensorServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly SensorController _controller;

        public SensorControllerTests() { 
            _sensorServiceMock = new Mock<ISensorService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new SensorController(_sensorServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void Get_ReturnsHttpStatusCode200() {
            // Arrange
            var sensors = new List<SensorModel> { new SensorModel { Id = 1, Nome = "SensorTeste1", Localizacao = "Quintal", Temperatura = "24", Umidade = "56"}};
            var sensorViewModels = new List<SensorViewModel> { new SensorViewModel { Id = 1, Nome = "SensorTeste1", Localizacao = "Quintal", Temperatura = "24", Umidade = "56" } };

            _sensorServiceMock.Setup(service => service.ListarSensores(It.IsAny<int>(), It.IsAny<int>())).Returns(sensors);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<SensorViewModel>>(sensors)).Returns(sensorViewModels);

            // Act
            var result = _controller.Get(1, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SensorPaginacaoViewModel>(okResult.Value);

            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(sensorViewModels, returnValue.Sensors);
            Assert.Equal(1, returnValue.CurrentPage);
            Assert.Equal(10, returnValue.PageSize);
            Assert.False(returnValue.HasPreviousPage);
            Assert.True(returnValue.HasNextPage);
            Assert.Equal("", returnValue.PreviousPageUrl);
            Assert.Equal("/Sensor?pagina=2&tamanho=10", returnValue.NextPageUrl);
        }
    }
}
