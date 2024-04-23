using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicoes;
internal class Requisicoes
{
    public Medicamento NovoMedicamento { get; set; }
    public Paciente NovoPaciente { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataDeValidade { get; set; }
}
