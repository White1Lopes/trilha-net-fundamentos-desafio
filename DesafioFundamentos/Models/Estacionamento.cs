using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models;


public class Estacionamento
{
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
        
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        var placaDoVeiculo = Console.ReadLine();

        if (!VerificaPlaca(placaDoVeiculo))
        {
            Console.WriteLine("Placa inválida! Não é possível adicionar o veículo.");
            return;
        }

        veiculos.Add(placaDoVeiculo.ToUpper());

    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");

        
        var placaDoVeiculo = Console.ReadLine();

        if (!VerificaPlaca(placaDoVeiculo))
        {
            Console.WriteLine("Placa inválida! Não é possível remover o veículo.");
            return;
        }

        
        if (veiculos.Any(x => x.ToUpper() == placaDoVeiculo.ToUpper()))
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            var horas = Convert.ToInt32(Console.ReadLine());
            decimal valorTotal = precoInicial + precoPorHora * horas;

            veiculos.Remove(placaDoVeiculo);

            Console.WriteLine($"O veículo {placaDoVeiculo} foi removido e o preço total foi de: R$ {valorTotal}");
        }
        else
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculos.Any())
        {
            Console.WriteLine("Os veículos estacionados são:");
            
            foreach (var veiculo in veiculos) Console.WriteLine(veiculo);

        }
        else
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
    }

    private bool VerificaPlaca(string placa)
    {
        string placaModeloAntigo = @"^[a-zA-Z]{3}\s?[0-9]{4}";
        string placaModeloMercosul = @"^[a-zA-Z]{3}\d{1}[a-zA-Z]{1}\d{2}$";

        placa = placa.Replace("-", "");
        placa = placa.Replace(" ", "");

        if (placa.Length != 7) return false;

        return Regex.IsMatch(placa, placaModeloAntigo) || Regex.IsMatch(placa, placaModeloMercosul);


    }
}
