using GadoApi.Models;
using GadoApi.Repositories;
using GadoApi.Services;
using Moq;

namespace GadoApi.Tests.Services;

public class GadoServiceTests
{
    private readonly Mock<IGadoRepository> _repoMock;
    private readonly GadoService _service;

    public GadoServiceTests()
    {
        _repoMock = new Mock<IGadoRepository>();
        _service = new GadoService(_repoMock.Object);
    }

    [Fact]
    public void GetAll_ReturnsList()
    {
        _repoMock.Setup(r => r.GetAll()).Returns(new List<Gado> { new Gado() });

        var result = _service.GetAll();

        Assert.Single(result);
        _repoMock.Verify(r => r.GetAll(), Times.Once);
    }

    [Fact]
    public void GetById_ReturnsItem()
    {
        var id = Guid.NewGuid();
        var gado = new Gado { Id = id };

        _repoMock.Setup(r => r.GetById(id)).Returns(gado);

        var result = _service.GetById(id);

        Assert.NotNull(result);
        Assert.Equal(id, result!.Id);
    }

    [Fact]
    public void Create_AddsItem()
    {
        var g = new Gado();

        var result = _service.Create(g);

        Assert.Equal(g, result);
        _repoMock.Verify(r => r.Add(g), Times.Once);
    }

    [Fact]
    public void Update_WhenNotFound_ReturnsFalse()
    {
        _repoMock.Setup(r => r.GetById(It.IsAny<Guid>())).Returns((Gado?)null);

        var result = _service.Update(Guid.NewGuid(), new Gado());

        Assert.False(result);
    }

    [Fact]
    public void Update_WhenFound_ReturnsTrue()
    {
        var id = Guid.NewGuid();
        var g = new Gado();

        _repoMock.Setup(r => r.GetById(id)).Returns(g);

        var result = _service.Update(id, g);

        Assert.True(result);
        _repoMock.Verify(r => r.Update(It.Is<Gado>(gd => gd.Id == id)), Times.Once);
    }

    [Fact]
    public void Delete_WhenNotFound_ReturnsFalse()
    {
        _repoMock.Setup(r => r.GetById(It.IsAny<Guid>())).Returns((Gado?)null);

        var result = _service.Delete(Guid.NewGuid());

        Assert.False(result);
    }

    [Fact]
    public void Delete_WhenFound_ReturnsTrue()
    {
        var id = Guid.NewGuid();
        var g = new Gado { Id = id };

        _repoMock.Setup(r => r.GetById(id)).Returns(g);

        var result = _service.Delete(id);

        Assert.True(result);
        _repoMock.Verify(r => r.Delete(id), Times.Once);
    }
}
