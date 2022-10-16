using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento.Models
{
    public class Estacionamento
    {
        public decimal precoInicial = 0;
        public decimal PrecoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string? placa = null;

            Console.Clear();

            while (string.IsNullOrEmpty(placa) == true)
            {
                Console.WriteLine("Digite a placa do veículo que voce quer estacionar:");
                placa = Console.ReadLine();

            }

                this.veiculos.Add(placa);

                           

        }

        public void RemoverVeiculo()
        {
            string? placa = null;
            int horas = 0; 
            decimal valorTotal = 0;
            string? tempo = null;
            bool numerico = false;

            Console.Clear();

            while (string.IsNullOrEmpty(placa) == true)
            {
                Console.WriteLine("Digite a placa do veículo que voce quer remover:");
                placa = Console.ReadLine();
            }

            if(veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                while (string.IsNullOrEmpty(tempo) == true || numerico == false)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    tempo = Console.ReadLine();
                    numerico = int.TryParse(tempo, out horas);
                    
                }


                valorTotal = this.precoInicial + this.PrecoPorHora*horas;
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }

            this.veiculos.Remove(placa);

        }

        public void ListarVeiculos()
        {
            Console.Clear();

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
