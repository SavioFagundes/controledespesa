using System.Collections.Generic;
using System.Linq;

namespace ControleDespesas.Models
{
    public class Despesa
    {
        // Variáveis estáticas para controlar IDs e lista de despesas
        private static int proximoId = 1;
        private static List<Despesa> despesas = new List<Despesa>();

        public int Id { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public Despesa(int id, string categoria, decimal valor, DateTime data)
        {
            Id = id;
            Categoria = categoria;
            Valor = valor;  
            Data = data;
        }

        public static void AdicionarDespesa()
        {
            System.Console.WriteLine("Adicionar Despesa selecionado.");
            System.Console.WriteLine("Digite a descrição da despesa:");

            string? descricao = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(descricao))
            {
                System.Console.WriteLine("Descrição não pode estar vazia.");
                return;
            }

            System.Console.WriteLine("Digite o valor da despesa:");
            if(decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Despesa novaDespesa = new Despesa(proximoId++, descricao, valor, DateTime.Now);
                despesas.Add(novaDespesa);
                System.Console.WriteLine("Despesa adicionada com sucesso!");
            }
            else
            {
                System.Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }

        // Método para listar todas as despesas
        public static void ListarDespesas()
        {
            if (despesas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma despesa cadastrada.");
                return;
            }

            System.Console.WriteLine("\n--- Lista de Despesas ---");
            foreach (var despesa in despesas)
            {
                System.Console.WriteLine($"ID: {despesa.Id} | Categoria: {despesa.Categoria} | Valor: R$ {despesa.Valor:F2} | Data: {despesa.Data:dd/MM/yyyy}");
            }
        }

        // Método para obter todas as despesas
        public static List<Despesa> ObterDespesas()
        {
            return new List<Despesa>(despesas);
        }

        // Método para obter o próximo ID disponível
        public static int ObterProximoId()
        {
            return proximoId;
        }

        // Método para atualizar uma despesa
        public static void AtualizarDespesa()
        {
            if (despesas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma despesa cadastrada para atualizar.");
                return;
            }

            ListarDespesas();
            System.Console.WriteLine("\nDigite o ID da despesa que deseja atualizar:");
            
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var despesa = despesas.Find(d => d.Id == id);
                if (despesa != null)
                {
                    System.Console.WriteLine($"Despesa encontrada: {despesa.Categoria} - R$ {despesa.Valor:F2}");
                    
                    System.Console.WriteLine("Digite a nova descrição (ou pressione Enter para manter a atual):");
                    string? novaCategoria = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(novaCategoria))
                    {
                        despesa.Categoria = novaCategoria;
                    }

                    System.Console.WriteLine("Digite o novo valor (ou pressione Enter para manter o atual):");
                    string? valorInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(valorInput) && decimal.TryParse(valorInput, out decimal novoValor))
                    {
                        despesa.Valor = novoValor;
                    }

                    System.Console.WriteLine("Despesa atualizada com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Despesa não encontrada.");
                }
            }
            else
            {
                System.Console.WriteLine("ID inválido.");
            }
        }

        // Método para excluir uma despesa
        public static void ExcluirDespesa()
        {
            if (despesas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma despesa cadastrada para excluir.");
                return;
            }

            ListarDespesas();
            System.Console.WriteLine("\nDigite o ID da despesa que deseja excluir:");
            
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var despesa = despesas.Find(d => d.Id == id);
                if (despesa != null)
                {
                    System.Console.WriteLine($"Confirma a exclusão da despesa: {despesa.Categoria} - R$ {despesa.Valor:F2}? (s/n)");
                    string? confirmacao = Console.ReadLine();
                    
                    if (confirmacao?.ToLower() == "s" || confirmacao?.ToLower() == "sim")
                    {
                        despesas.Remove(despesa);
                        System.Console.WriteLine("Despesa excluída com sucesso!");
                    }
                    else
                    {
                        System.Console.WriteLine("Exclusão cancelada.");
                    }
                }
                else
                {
                    System.Console.WriteLine("Despesa não encontrada.");
                }
            }
            else
            {
                System.Console.WriteLine("ID inválido.");
            }
        }

        // Método para visualizar resumo geral
        public static void VisualizarResumoGeral()
        {
            if (despesas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma despesa cadastrada.");
                return;
            }

            decimal total = despesas.Sum(d => d.Valor);
            decimal media = despesas.Average(d => d.Valor);
            var maiorDespesa = despesas.OrderByDescending(d => d.Valor).First();
            var menorDespesa = despesas.OrderBy(d => d.Valor).First();

            System.Console.WriteLine("\n--- Resumo Geral ---");
            System.Console.WriteLine($"Total de despesas: {despesas.Count}");
            System.Console.WriteLine($"Valor total: R$ {total:F2}");
            System.Console.WriteLine($"Valor médio: R$ {media:F2}");
            System.Console.WriteLine($"Maior despesa: {maiorDespesa.Categoria} - R$ {maiorDespesa.Valor:F2}");
            System.Console.WriteLine($"Menor despesa: {menorDespesa.Categoria} - R$ {menorDespesa.Valor:F2}");

            // Resumo por categoria
            var resumoPorCategoria = despesas.GroupBy(d => d.Categoria)
                                           .Select(g => new { Categoria = g.Key, Total = g.Sum(d => d.Valor), Quantidade = g.Count() })
                                           .OrderByDescending(x => x.Total);

            System.Console.WriteLine("\n--- Resumo por Categoria ---");
            foreach (var item in resumoPorCategoria)
            {
                System.Console.WriteLine($"{item.Categoria}: {item.Quantidade} despesa(s) - R$ {item.Total:F2}");
            }
        }

        // Método para visualizar resumo do mês atual
        public static void VisualizarResumoMesAtual()
        {
            var agora = DateTime.Now;
            var despesasDoMes = despesas.Where(d => d.Data.Year == agora.Year && d.Data.Month == agora.Month).ToList();

            if (despesasDoMes.Count == 0)
            {
                System.Console.WriteLine($"Nenhuma despesa cadastrada para {agora:MMMM/yyyy}.");
                return;
            }

            decimal totalMes = despesasDoMes.Sum(d => d.Valor);
            decimal mediaMes = despesasDoMes.Average(d => d.Valor);

            System.Console.WriteLine($"\n--- Resumo de {agora:MMMM/yyyy} ---");
            System.Console.WriteLine($"Total de despesas do mês: {despesasDoMes.Count}");
            System.Console.WriteLine($"Valor total do mês: R$ {totalMes:F2}");
            System.Console.WriteLine($"Valor médio do mês: R$ {mediaMes:F2}");

            // Resumo por categoria do mês
            var resumoPorCategoriaMes = despesasDoMes.GroupBy(d => d.Categoria)
                                                   .Select(g => new { Categoria = g.Key, Total = g.Sum(d => d.Valor), Quantidade = g.Count() })
                                                   .OrderByDescending(x => x.Total);

            System.Console.WriteLine("\n--- Resumo por Categoria do Mês ---");
            foreach (var item in resumoPorCategoriaMes)
            {
                System.Console.WriteLine($"{item.Categoria}: {item.Quantidade} despesa(s) - R$ {item.Total:F2}");
            }

            System.Console.WriteLine("\n--- Despesas do Mês ---");
            foreach (var despesa in despesasDoMes.OrderBy(d => d.Data))
            {
                System.Console.WriteLine($"ID: {despesa.Id} | {despesa.Categoria} | R$ {despesa.Valor:F2} | {despesa.Data:dd/MM/yyyy}");
            }
        }
    }
}