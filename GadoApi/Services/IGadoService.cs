using GadoApi.Models;

namespace GadoApi.Services;

public interface IGadoService
{
    IEnumerable<Gado> GetAll();
    Gado? GetById(Guid id);
    Gado Create(Gado gado);
    bool Update(Guid id, Gado gado);
    bool Delete(Guid id);
}
