using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicoes;
using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        TelaMedicamentos telaMedicamentos = new TelaMedicamentos();

        bool opcaoSairEscolhida = true;

        while (opcaoSairEscolhida)
        {
            char opcaoEscolhida = ApresentarMenuPrincipal();

            switch (opcaoEscolhida.ToString().ToUpper())
            {
                case "1":
                    string opcao = telaMedicamentos.ApresentarMenu();

                    if (opcao == "1")
                    {
                        telaMedicamentos.CadastrarMedicamento();
                    }
                    else if (opcao == "2")
                    {
                        telaMedicamentos.EditarEquipamento();
                    }
                    else if (opcao == "3")
                    {
                        telaMedicamentos.ExcluirMedicamento();
                    }
                    else if (opcao == "4")
                    {
                        telaMedicamentos.VisualizarEquipamentos(true);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por favot indira uma opção válida!!!");
                        Console.ResetColor();

                        EnterParaContinuar();
                    }
                    break;
                case "2":
                    Console.WriteLine("Controle de pacientes");
                    EnterParaContinuar();
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
        Console.WriteLine("2 - Controle de Pacientes [Não disponível]");
        Console.WriteLine("3 - Controle de Requisições [Não disponível]");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        Console.Clear();

        return operacaoEscolhida;
    }
}
