using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente;
internal class RepositorioPaciente
{
    private Paciente[] pacientes = new Paciente[100];

    public void CadastrarPaciente(Paciente novoPaciente)
    {
        novoPaciente.Id = GeradorId.GerarIdEquipamento();

        RegistrarItem(novoPaciente);
    }

    public bool EditarPaciente(int id, Paciente pacienteEditado)
    {
        pacienteEditado.Id = id;

        for (int i = 0; i < pacientes.Length; i++)
        {
            if (pacientes[i] == null)
            {
                continue;
            }
            else if (pacientes[i].Id == id)
            {
                pacientes[i] = pacienteEditado;
                return true;
            }
        }

        return false;
    }

    public bool ExcluirPaciente(int pacienteEscolhido)
    {
        for (int i = 0; i < pacientes.Length; i++)
        {
            if (pacientes[i] == null)
            {
                continue;
            }
            else if (pacientes[i].Id == pacienteEscolhido)
            {
                pacientes[i] = null;
                return true;
            }
        }
        return false;
    }

    public Paciente[] SelecionarPaciente()
    {
        return pacientes;
    }

    public bool ExistePaciente(int id)
    {
        for (int i = 0; i < pacientes.Length; i++)
        {
            Paciente p = pacientes[i];

            if (p == null)
            {
                continue;
            }
            else if (p.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    private void RegistrarItem(Paciente paciente)
    {
        for (int i = 0; i < pacientes.Length; i++)
        {
            if (pacientes[i] != null)
            {
                continue;
            }
            else
            {
                pacientes[i] = paciente;
                break;
            }
        }
    }
}
