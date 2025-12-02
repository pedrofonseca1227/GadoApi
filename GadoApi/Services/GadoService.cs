using GadoApi.Models;
using GadoApi.Repositories;

namespace GadoApi.Services;

public class GadoService : IGadoService
{
    private readonly IGadoRepository _repo;

    public GadoService(IGadoRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Gado> GetAll() => _repo.GetAll();

    public Gado? GetById(Guid id) => _repo.GetById(id);

    public Gado Create(Gado gado)
    {
        _repo.Add(gado);
        return gado;
    }

    public bool Update(Guid id, Gado gado)
    {
        var existing = _repo.GetById(id);
        if (existing is null) return false;

        gado.Id = id;
        _repo.Update(gado);
        return true;
    }

    public bool Delete(Guid id)
    {
        var existing = _repo.GetById(id);
        if (existing is null) return false;

        _repo.Delete(id);
        return true;
    }
}
