using ControleDespesas.Models;

namespace ControleDespesas
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Controle de Despesas Iniciado");
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Adicionar Despesa");
                Console.WriteLine("2. Atualizar Despesa");
                Console.WriteLine("3. Excluir Despesa");
                Console.WriteLine("4. Visualizar Todas as Despesas");
                Console.WriteLine("5. Visualizar Resumo Geral");
                Console.WriteLine("6. Visualizar Resumo do Mês Atual");
                Console.WriteLine("7. Sair");
                Console.Write("Opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        // Lógica para adicionar despesa
                        Despesa.AdicionarDespesa();
                        break;
                    case "2":
                        // Lógica para atualizar despesa
                        Despesa.AtualizarDespesa();
                        break;
                    case "3":
                        // Lógica para excluir despesa
                        Despesa.ExcluirDespesa();
                        break;
                    case "4":
                        // Lógica para visualizar todas as despesas
                        Despesa.ListarDespesas();
                        break;
                    case "5":
                        // Lógica para visualizar resumo geral
                        Despesa.VisualizarResumoGeral();
                        break;
                    case "6":
                        // Lógica para visualizar resumo do mês atual
                        Despesa.VisualizarResumoMesAtual();
                        break;
                    case "7":
                        sair = true;
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            System.Console.WriteLine("Controle de Despesas Finalizado");
        }
    }
}