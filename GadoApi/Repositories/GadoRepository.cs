using GadoApi.Models;

namespace GadoApi.Repositories;

public class GadoRepository : IGadoRepository
{
    private readonly List<Gado> _gadoList = new();

    public IEnumerable<Gado> GetAll() => _gadoList;

    public Gado? GetById(Guid id) =>
        _gadoList.FirstOrDefault(g => g.Id == id);

    public void Add(Gado gado)
    {
        _gadoList.Add(gado);
    }

    public void Update(Gado gado)
    {
        var existing = GetById(gado.Id);
        if (existing is null) return;

        existing.Identificacao = gado.Identificacao;
        existing.Raca = gado.Raca;
        existing.Sexo = gado.Sexo;
        existing.AnoNascimento = gado.AnoNascimento;
        existing.Localizacao = gado.Localizacao;
        existing.Origem = gado.Origem;
        existing.EstadoSaude = gado.EstadoSaude;
    }

    public void Delete(Guid id)
    {
        var existing = GetById(id);
        if (existing is not null)
            _gadoList.Remove(existing);
    }
}
