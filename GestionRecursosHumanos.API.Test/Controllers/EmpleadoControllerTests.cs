namespace GestionRecursosHumanos.API.Test.Controllers
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using GestionRecursosHumanos.API.Controllers;
    using GestionRecursosHumanos.API.DTOs;
    using GestionRecursosHumanos.API.Models;
    using GestionRecursosHumanos.API.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Threading.Tasks;
    using Xunit;

    /// <summary>
    /// Pruebas Unitarias para <see cref="EmpleadosController"/>.
    /// </summary>
    public class EmpleadosControllerTests
    {
        private readonly Mock<IEmpleadoService> _mockEmpleadoService;
        private readonly EmpleadosController _controller;
        private readonly IFixture _fixture;

        public EmpleadosControllerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Customize(new ObjectIdPersonalizacion());
            _mockEmpleadoService = _fixture.Freeze<Mock<IEmpleadoService>>();
            _controller = new EmpleadosController(_mockEmpleadoService.Object);
        }

        [Fact]
        public async Task Get_Empleados_Returns_OkResult_With_Employees()
        {
            // Arrange
            var fakeEmpleados = _fixture.CreateMany<EmpleadoDTO>().ToList();
            _mockEmpleadoService.Setup(service => service.GetAllEmpleadosAsync())
                                .ReturnsAsync((fakeEmpleados));

            // Act
            var result = await _controller.GetAllEmpleados();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(fakeEmpleados);
        }

        [Fact]
        public async Task Post_Empleado_Returns_CreatedResult()
        {
            // Arrange
            var fakeEmpleadoDto = _fixture.Create<EmpleadoDTO>();
            var fakeEmpleado = _fixture.Create<Empleado>();
            _mockEmpleadoService.Setup(service => service.CreateEmpleadoAsync(fakeEmpleadoDto))
                                .Returns(Task.CompletedTask)
                                .Verifiable();

            // Act
            var result = await _controller.CreateEmpleado(fakeEmpleadoDto);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();
            var createdAtActionResult = result as CreatedAtActionResult;
            createdAtActionResult.Value.Should().BeEquivalentTo(fakeEmpleadoDto);
            _mockEmpleadoService.Verify();
        }

        [Fact]
        public async Task Put_Empleado_Returns_NoContentResult()
        {
            // Arrange
            var fakeEmpleadoDto = _fixture.Create<EmpleadoDTO>();
            _mockEmpleadoService.Setup(service => service.UpdateEmpleadoAsync(fakeEmpleadoDto.Id, fakeEmpleadoDto))
                                .Returns(Task.CompletedTask)
                                .Verifiable();

            // Act
            var result = await _controller.UpdateEmpleado(fakeEmpleadoDto.Id, fakeEmpleadoDto);

            // Assert
            result.Should().BeOfType<NoContentResult>();
            _mockEmpleadoService.Verify();
        }

        [Fact]
        public async Task Delete_Empleado_Returns_NoContentResult()
        {
            // Arrange
            var fakeEmpleadoId = _fixture.Create<string>();
            _mockEmpleadoService.Setup(service => service.DeleteEmpleadoAsync(fakeEmpleadoId))
                                .Returns(Task.CompletedTask)
                                .Verifiable();

            // Act
            var result = await _controller.DeleteEmpleado(fakeEmpleadoId);

            // Assert
            result.Should().BeOfType<NoContentResult>();
            _mockEmpleadoService.Verify();
        }
    }
}