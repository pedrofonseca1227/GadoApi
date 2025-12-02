using GadoApi.Controllers;
using GadoApi.Models;
using GadoApi.Services;
using GadoApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class GadoControllerTests
{
    private readonly GadoController _controller;

    public GadoControllerTests()
    {
        var service = new GadoService(new GadoRepository());
        _controller = new GadoController(service);
    }

    [Fact]
    public void Create_Should_Return_Created()
    {
        var gado = new Gado { Identificacao = "Gado 10" };
        var result = _controller.Create(gado);

        Assert.IsType<CreatedAtActionResult>(result);
    }
}
