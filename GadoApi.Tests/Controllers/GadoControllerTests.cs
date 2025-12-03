using GadoApi.Controllers;
using GadoApi.Models;
using GadoApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GadoApi.Tests.Controllers;

public class GadoControllerTests
{
    private readonly Mock<IGadoService> _serviceMock;
    private readonly GadoController _controller;

    public GadoControllerTests()
    {
        _serviceMock = new Mock<IGadoService>();
        _controller = new GadoController(_serviceMock.Object);
    }

    [Fact]
    public void GetAll_ReturnsOk()
    {
        _serviceMock.Setup(s => s.GetAll()).Returns(new List<Gado>());

        var result = _controller.GetAll();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetById_ReturnsNotFound_WhenNull()
    {
        _serviceMock.Setup(s => s.GetById(It.IsAny<Guid>())).Returns((Gado?)null);

        var result = _controller.GetById(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetById_ReturnsOk_WhenFound()
    {
        var g = new Gado();
        _serviceMock.Setup(s => s.GetById(g.Id)).Returns(g);

        var result = _controller.GetById(g.Id);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Create_ReturnsCreated()
    {
        var g = new Gado();
        _serviceMock.Setup(s => s.Create(g)).Returns(g);

        var result = _controller.Create(g);

        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public void Update_ReturnsNotFound_WhenFails()
    {
        _serviceMock.Setup(s => s.Update(It.IsAny<Guid>(), It.IsAny<Gado>())).Returns(false);

        var result = _controller.Update(Guid.NewGuid(), new Gado());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Update_ReturnsNoContent_WhenSuccess()
    {
        _serviceMock.Setup(s => s.Update(It.IsAny<Guid>(), It.IsAny<Gado>())).Returns(true);

        var result = _controller.Update(Guid.NewGuid(), new Gado());

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void Delete_ReturnsNotFound()
    {
        _serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).Returns(false);

        var result = _controller.Delete(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_ReturnsNoContent()
    {
        _serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).Returns(true);

        var result = _controller.Delete(Guid.NewGuid());

        Assert.IsType<NoContentResult>(result);
    }
}
