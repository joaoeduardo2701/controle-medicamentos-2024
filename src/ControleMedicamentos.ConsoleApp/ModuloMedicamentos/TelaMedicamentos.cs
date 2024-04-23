namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

public class TelaMedicamentos
{
    RepositorioMedicamentos repositorio = new RepositorioMedicamentos();

    public string ApresentarMenu()
    {
        Cabecario();

        Console.WriteLine("1 - Cadastrar medicamento");
        Console.WriteLine("2 - Editar medicamento");
        Console.WriteLine("3 - Excluir medicamento");
        Console.WriteLine("4 - Visualizar medicamento");
        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        string operacaoEscolhida = Console.ReadLine();

        return operacaoEscolhida;
    }

    public void CadastrarMedicamento()
    {
        Cabecario();

        Console.WriteLine("Cadastrando medicamento...");

        Console.Write("Digite o nome do medicamento: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a descrição do medicamento: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite o quantidade necessária: ");
        int quantidade = int.Parse(Console.ReadLine());

        Medicamento medicamento = new Medicamento(nome, descricao, quantidade);
        repositorio.CadastrarMedicamento(medicamento);

        Program.EnterParaContinuar();
    }
    
    public void EditarEquipamento()
    {
        Cabecario();

        Console.WriteLine("Editando Equipamento...");

        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.Write("\nDigite o ID do medicamento que deseja editar: ");
        int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.ExisteEquipamento(idMedicamentoEscolhido))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O medicamento" +
                " mencionado não existe!");
            Console.ResetColor();

            Console.Write("\nPressione ENTER para continuar...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine();

        Console.Write("Digite o nome do medicamento: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a descrição do medicamento: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite o quantidade necessária: ");
        int quantidade = int.Parse(Console.ReadLine());

        Medicamento medicamentoEditado = new Medicamento(nome, descricao, quantidade);

        bool conseguiuEditar = repositorio.EditarEquipamento(idMedicamentoEscolhido, medicamentoEditado);

        if (!conseguiuEditar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Houve um erro durante a edição do medicamento!");
            Console.ResetColor();

            return;
        }

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("O medicamento foi editado com sucesso!");
        Console.ResetColor();

        Program.EnterParaContinuar();
    }

    public void ExcluirMedicamento()
    {
        Cabecario();
        Console.WriteLine("Excluindo medicamento... ");
        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.WriteLine("\nDigite o id do medicamento que deseja excluir: ");
        int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.ExisteEquipamento(idEquipamentoEscolhido))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O medicamento mencionado não existe!");
            Console.ResetColor();

            Program.EnterParaContinuar();
            return;
        }

        bool conseguiuExcluir = repositorio.ExcluirEquipamento(idEquipamentoEscolhido);

        if (!conseguiuExcluir)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Houve um erro a excluir o medicamento!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMedicamento excluido com sucesso!");
            Console.ResetColor();
        }

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
    }
    
    public void VisualizarEquipamentos(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Cabecario();

            Console.WriteLine("Visualizando medicamentos...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -10}",
            "Id", "Nome", "Descrição", "Quantidade", "Data de Fabricação"
        );

        Medicamento[] equipamentosCadastrados = repositorio.SelecionarEquipamento();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Medicamento m = equipamentosCadastrados[i];

            if (m == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10}",
                m.Id, m.Nome, m.Descricao, m.Quantidade
            );
        }

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
    }

    public void Cabecario()
    {
        Console.Clear();

        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("|        Controle de Medicamentos       |");
        Console.WriteLine("-----------------------------------------");

        Console.WriteLine();
    }
}
