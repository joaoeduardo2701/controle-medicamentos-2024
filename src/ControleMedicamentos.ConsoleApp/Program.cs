using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicoes;
using GestaoEquipamentos.ConsoleApp.Compartilhado;
using GestaoEquipamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        TelaMedicamentos telaMedicamentos = new TelaMedicamentos();
        TelaPaciente telaPaciente = new TelaPaciente();

        bool opcaoSairEscolhida = true;

        while (opcaoSairEscolhida)
        {
            char opcaoEscolhida = ApresentarMenuPrincipal();

            switch (opcaoEscolhida.ToString().ToUpper())
            {
                case "1":
                    string opcao1 = telaMedicamentos.ApresentarMenu();

                    if (opcao1 == "1")
                    {
                        telaMedicamentos.CadastrarMedicamento();
                    }
                    else if (opcao1 == "2")
                    {
                        telaMedicamentos.EditarEquipamento();
                    }
                    else if (opcao1 == "3")
                    {
                        telaMedicamentos.ExcluirMedicamento();
                    }
                    else if (opcao1 == "4")
                    {
                        telaMedicamentos.VisualizarEquipamentos(true);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por favor insira uma opção válida!!!");
                        Console.ResetColor();

                        EnterParaContinuar();
                    }
                    break;
                case "2":
                    string opcao2 = telaPaciente.ApresentarMenu();

                    if (opcao2 == "1")
                    {
                        telaPaciente.CadastrarPaciente();
                    }
                    else if (opcao2 == "2")
                    {
                        telaPaciente.EditarPaciente();
                    }
                    else if (opcao2 == "3")
                    {
                        telaPaciente.ExcluirPaciente();
                    }
                    else if (opcao2 == "4")
                    {
                        telaPaciente.VisualizarPaciente(true);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por favor insira uma opção válida!!!");
                        Console.ResetColor();

                        EnterParaContinuar();
                    }
                    break;
                case "3":
                    Console.WriteLine("Controle de requisições");
                    EnterParaContinuar();
                    break;
                case "S":
                    Console.WriteLine("Encerrando programa...");
                    opcaoSairEscolhida = false;
                    EnterParaContinuar();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor insira uma opção válida");
                    Console.ResetColor();
                    EnterParaContinuar();
                    break;
            }
        }
    }

    public static void EnterParaContinuar()
    {
        Console.WriteLine("\nDigite enter para continuar...");
        Console.ReadKey();
    }

    public static char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|       Controle de Medicamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Medicamentos");
        Console.WriteLine("2 - Controle de Pacientes");
        Console.WriteLine("3 - Controle de Requisições [Não disponível]");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        Console.Clear();

        return operacaoEscolhida;
    }
}
