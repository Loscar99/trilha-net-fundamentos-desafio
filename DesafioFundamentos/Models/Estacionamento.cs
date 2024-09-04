namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            bool vazioOuEmBranco = true;
            while(vazioOuEmBranco == true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string veiculoValido = Console.ReadLine();

                //Verifica se a variável (veiculoValido) é válida (não está vazia ou apenas com espaços em branco)
                if(string.IsNullOrWhiteSpace(veiculoValido) == true)
                {
                    Console.WriteLine("Você não informou a placa do carro. Este é um item OBRIGATÓRIO!");
                    Console.WriteLine("Por favor, Informe a placa do carro:");

                    vazioOuEmBranco = true;
                }
                else
                {
                    veiculos.Add(veiculoValido);
                    vazioOuEmBranco = false;
                }
                
            }
            
        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            bool repetirLaco = true;
            while(repetirLaco == true)
            {
                Console.WriteLine("Digite a placa do veículo para remover:");

                string placa = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(placa))
                {
                    Console.WriteLine("Desculpe, mas você não informou um placa. Por favor, informe uma placa válida.");
                    repetirLaco = true;
                }
                else
                {
                    // Verifica se o veículo existe
                    if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                        int horas = Convert.ToInt32(Console.ReadLine());
                        decimal valorTotal = precoInicial + precoPorHora * horas; 

                        veiculos.Remove(placa);

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

                        Console.WriteLine("Pressione Enter para confirmar o pagamento.");
                        Console.ReadLine();
                        repetirLaco = false;
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Verifique se digitou corretamente e tente novamente.");

                        int resposta;
                        do
                        {
                            Console.WriteLine("Deseja repetir? \n" +
                                            "1 - Sim \n"+
                                            "2 - Não");

                            resposta = Convert.ToInt32(Console.ReadLine());
                            switch(resposta)
                            {
                                case 1:
                                    repetirLaco = true;
                                    break;
                                case 2:
                                    repetirLaco = false;
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida.");
                                    repetirLaco = true;
                                    break;
                            }
                        }while(resposta != 1 && resposta != 2);
                    }
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach(string veiculosEstacionados in veiculos )
                {
                    Console.WriteLine(veiculosEstacionados);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
