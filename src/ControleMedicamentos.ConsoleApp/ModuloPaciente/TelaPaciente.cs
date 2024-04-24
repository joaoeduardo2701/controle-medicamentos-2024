using ControleMedicamentos.ConsoleApp;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace GestaoEquipamentos.ConsoleApp.ModuloPaciente;
internal class TelaPaciente
{
    RepositorioPaciente repositorio = new RepositorioPaciente();

    public TelaPaciente()
    {
        Paciente equipTest = new Paciente("Arlindo", "123-456-789-10", "Avenida Marechal Floriano", "38912");

        repositorio.CadastrarPaciente(equipTest);
    }

    public string ApresentarMenu()
    {
        Cabecario();

        Console.WriteLine("1 - Cadastrar paciente");
        Console.WriteLine("2 - Editar paciente");
        Console.WriteLine("3 - Excluir paciente");
        Console.WriteLine("4 - Visualizar paciente");

        Console.WriteLine("S - Voltar");

        Console.Write("\nEscolha uma das opções: ");
        string operacaoEscolhida = Convert.ToString(Console.ReadLine());

        Program.EnterParaContinuar();

        return operacaoEscolhida;
    }

    public void CadastrarPaciente()
    {
        Cabecario();
        Console.WriteLine("Cadastrando paciente ...");
        Console.WriteLine();

        Console.Write("Digite o nome do paciente: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o CPF paciente (formato: xxx.xxx.xxx-xx):  ");
        string cpf = Console.ReadLine();

        Console.Write("Digite o endereço do paciente: ");
        string endereco = Console.ReadLine();

        Console.Write("Digite o cartão do SUS do paciente: ");
        string cartaoSus = Console.ReadLine();

        Paciente paciente = new Paciente(nome, cpf, endereco, cartaoSus);

        repositorio.CadastrarPaciente(paciente);

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"O paciente ${paciente.Nome}foi cadastrado com sucesso!");
        Console.ResetColor();

        Program.EnterParaContinuar();
    }

    public void EditarPaciente()
    {
        Cabecario();

        Console.WriteLine("Editando Equipamento...");

        Console.WriteLine();

        VisualizarPaciente(false);

        Console.Write("\nDigite o ID do equipamento que deseja editar: ");
        int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.ExistePaciente(idEquipamentoEscolhido))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O equipamento mencionado não existe!");
            Console.ResetColor();

            Program.EnterParaContinuar();
            return;
        }

        Console.Write("\nDigite o nome do paciente: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o CPF paciente (formato: xxx.xxx.xxx-xx):  ");
        string cpf = Console.ReadLine();

        Console.Write("Digite o endereço do paciente: ");
        string endereco = Console.ReadLine();

        Console.Write("Digite o cartão do SUS do paciente: ");
        string cartaoSus = Console.ReadLine();

        Paciente pacienteEditado = new Paciente(nome, cpf, endereco, cartaoSus);

        bool conseguiuEditar = repositorio.EditarPaciente(idEquipamentoEscolhido, pacienteEditado);

        if (!conseguiuEditar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Houve um erro durante a edição do equipamento!");
            Console.ResetColor();

            return;
        }

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("O equipamento foi editado com sucesso!");
        Console.ResetColor();

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
    }

    public void ExcluirPaciente()
    {
        Cabecario();
        Console.WriteLine("Excluindo equipamento... ");
        Console.WriteLine();

        VisualizarPaciente(false);

        Console.WriteLine("\nDigite o id do equipamento que deseja excluir: ");
        int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.ExistePaciente(idEquipamentoEscolhido))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O equipamento mencionado não existe!");
            Console.ResetColor();

            Console.Write("\nPressione ENTER para continuar...");
            Console.ReadKey();
            return;
        }

        bool conseguiuExcluir = repositorio.ExcluirPaciente(idEquipamentoEscolhido);

        if (!conseguiuExcluir)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Houve um erro a excluir o paciente!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPaciente excluido com sucesso!");
            Console.ResetColor();
        }

        Program.EnterParaContinuar();
    }
    
    public void VisualizarPaciente(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Cabecario();

            Console.WriteLine("Visualizando Equipamentos...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -30} | {4, -10}",
            "Id", "Nome", "CPF", "Endereço", "Cartão do SUS"
        );

        Paciente[] equipamentosCadastrados = repositorio.SelecionarPaciente();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Paciente p = equipamentosCadastrados[i];

            if (p == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -30} | {4, -10}",
                p.Id, p.Nome, p.Cpf, p.Endereco, p.CartaoDoSus
            );
        }

        Program.EnterParaContinuar();
    }

    public void Cabecario()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();
    }
}
