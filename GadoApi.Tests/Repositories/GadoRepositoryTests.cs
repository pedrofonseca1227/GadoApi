using GadoApi.Models;
using GadoApi.Repositories;

namespace GadoApi.Tests.Repositories;

public class GadoRepositoryTests
{
    private readonly GadoRepository _repo;

    public GadoRepositoryTests()
    {
        _repo = new GadoRepository();
    }

    [Fact]
    public void Add_ShouldStoreItem()
    {
        var g = new Gado();

        _repo.Add(g);

        Assert.Contains(g, _repo.GetAll());
    }

    [Fact]
    public void GetById_ShouldReturnCorrectItem()
    {
        var g = new Gado();
        _repo.Add(g);

        var result = _repo.GetById(g.Id);

        Assert.Equal(g, result);
    }

    [Fact]
    public void Update_ShouldModifyItem()
    {
        var g = new Gado { Identificacao = "A" };
        _repo.Add(g);

        g.Identificacao = "B";
        _repo.Update(g);

        var updated = _repo.GetById(g.Id);
        Assert.Equal("B", updated!.Identificacao);
    }

    [Fact]
    public void Delete_ShouldRemoveItem()
    {
        var g = new Gado();
        _repo.Add(g);

        _repo.Delete(g.Id);

        Assert.DoesNotContain(g, _repo.GetAll());
    }
}
