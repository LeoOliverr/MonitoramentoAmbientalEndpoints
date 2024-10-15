﻿using MonitoramentoAmbientalEndpoints.Services;
using MonitoramentoAmbientalEndpoints.Controllers;
using MonitoramentoAmbientalEndpoints.Models;
using MonitoramentoAmbientalEndpoints.ViewModel;
using Moq;
using AutoMapper;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            var page = 1;
            var pageSize = 10;
            var sensores = new List<SensorModel>
            {
                new SensorModel { Id = 1, Nome = "Sensor1", Localizacao = "Local1", Temperatura = "20", Umidade = "50" },
                new SensorModel { Id = 2, Nome = "Sensor2", Localizacao = "Local2", Temperatura = "25", Umidade = "60" }
            };

            var sensorViewModels = new List<SensorViewModel>
            {
                new SensorViewModel { Id = 1, Nome = "Sensor1", Localizacao = "Local1", Temperatura = "20", Umidade = "50" },
                new SensorViewModel { Id = 2, Nome = "Sensor2", Localizacao = "Local2", Temperatura = "25", Umidade = "60" }
            };

            _sensorServiceMock.Setup(service => service.ListarSensores(page, pageSize)).Returns(sensores);
            _mapperMock.Setup(m => m.Map<IEnumerable<SensorViewModel>>(sensores)).Returns(sensorViewModels);

            var result = _controller.Get(page, pageSize);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var viewModel = Assert.IsType<SensorPaginacaoViewModel>(okResult.Value);
            Assert.Equal(page, viewModel.CurrentPage);
            Assert.Equal(pageSize, viewModel.PageSize);
            Assert.Equal(sensorViewModels.Count, viewModel.Sensors.Count());
        }
    }
}