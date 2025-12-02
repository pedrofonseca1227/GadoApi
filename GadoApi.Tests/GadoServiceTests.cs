using GadoApi.Models;
using GadoApi.Repositories;
using GadoApi.Services;
using Xunit;

public class GadoServiceTests
{
    private readonly GadoService _service;
    private readonly GadoRepository _repo;

    public GadoServiceTests()
    {
        _repo = new GadoRepository();
        _service = new GadoService(_repo);
    }

    [Fact]
    public void Create_Should_Add_Gado()
    {
        var gado = new Gado { Identificacao = "Bezerro 1" };
        var result = _service.Create(gado);

        Assert.Single(_repo.GetAll());
        Assert.Equal("Bezerro 1", result.Identificacao);
    }

    [Fact]
    public void Delete_Should_Remove_Gado()
    {
        var gado = new Gado { Identificacao = "Teste" };
        _service.Create(gado);

        var deleted = _service.Delete(gado.Id);

        Assert.True(deleted);
        Assert.Empty(_repo.GetAll());
    }
}
