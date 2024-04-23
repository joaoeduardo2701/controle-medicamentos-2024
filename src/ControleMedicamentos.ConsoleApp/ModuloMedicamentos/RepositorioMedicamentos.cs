using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

internal class RepositorioMedicamentos
{
    Medicamento[] medicamentos = new Medicamento[100];



    public void CadastrarMedicamento(Medicamento novoMedicamento)
    {
        novoMedicamento.Id = GeradorId.GerarIdEquipamento();

        RegistrarItem(novoMedicamento);
    }

    public bool EditarEquipamento(int id, Medicamento medicamentoEditado)
    {
        medicamentoEditado.Id = id;

        for (int i = 0; i < medicamentos.Length; i++)
        {
            if (medicamentos[i] == null)
            {
                continue;
            }
            else if (medicamentos[i].Id == id)
            {
                medicamentos[i] = medicamentoEditado;
                return true;
            }
        }

        return false;
    }

    public bool ExcluirEquipamento(int medicamentoEscolhido)
    {
        for (int i = 0; i < medicamentos.Length; i++)
        {
            if (medicamentos[i] == null)
            {
                continue;
            }
            else if (medicamentos[i].Id == medicamentoEscolhido)
            {
                medicamentos[i] = null;
                return true;
            }
        }
        return false;
    }

    public Medicamento[] SelecionarEquipamento()
    {
        return medicamentos;
    }

    public bool ExisteEquipamento(int id)
    {
        for (int i = 0; i < medicamentos.Length; i++)
        {
            Medicamento e = medicamentos[i];

            if (e == null)
            {
                continue;
            }
            else if (e.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    private void RegistrarItem(Medicamento medicamento)
    {
        for (int i = 0; i < medicamentos.Length; i++)
        {
            if (medicamentos[i] != null)
            {
                continue;
            }
            else
            {
                medicamentos[i] = medicamento;
                break;
            }
        }
    }
}
