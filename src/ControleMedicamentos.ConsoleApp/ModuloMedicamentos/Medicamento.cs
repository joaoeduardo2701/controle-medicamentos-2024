namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

internal class Medicamento
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public int Id { get; set; }

    public Medicamento(string nome, string descricao, int quantidade)
    {
        Nome = nome;
        Descricao = descricao;
        Quantidade = quantidade;
    }
}
