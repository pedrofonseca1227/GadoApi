namespace GadoApi.Models;

public class Gado
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Identificacao { get; set; } = string.Empty;
    public string Raca { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public int AnoNascimento { get; set; }
    public string Localizacao { get; set; } = "Confinamento";
    public string Origem { get; set; } = "Desconhecida";
    public string EstadoSaude { get; set; } = "Sem info";
}
