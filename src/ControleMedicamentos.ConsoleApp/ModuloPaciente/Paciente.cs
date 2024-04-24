using ControleMedicamentos.ConsoleApp.ModuloRequisicoes;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente;
internal class Paciente
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public string CartaoDoSus { get; set; }
    public int Id { get; set; }

    //public Requisicoes NovaRequisicoes { get; set; }

    public Paciente(string nome, string cpf, string endereco, string cartaoDoSus)
    {
        Nome = nome;
        Cpf = cpf;
        Endereco = endereco;
        CartaoDoSus = cartaoDoSus;
    }
}
