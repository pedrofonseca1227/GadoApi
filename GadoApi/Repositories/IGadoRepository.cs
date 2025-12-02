using GadoApi.Models;

namespace GadoApi.Repositories;

public interface IGadoRepository
{
    IEnumerable<Gado> GetAll();
    Gado? GetById(Guid id);
    void Add(Gado gado);
    void Update(Gado gado);
    void Delete(Guid id);
}
