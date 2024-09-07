namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal taxaDeEntrada = 0;
        private decimal precoPorHora = 0;
        private int totalDeVagas = 0;
        private int vagasLivres = 0; 
        private List<string> veiculos = new();
        private List<DateTime> horaDeEntrada = new();

        public Estacionamento(decimal taxaDeEntrada, decimal precoPorHora, int totalDeVagas)
        {
            this.taxaDeEntrada = taxaDeEntrada;
            this.precoPorHora = precoPorHora;
            this.totalDeVagas = totalDeVagas;
        }

        public void DisponibilidadeVagas()
        {
            Console.WriteLine($"Total de vagas do Estacionamento: {totalDeVagas}");

            Console.WriteLine($"Vagas Ocupadas: {veiculos.Count}");

            //Calculo de vagas Livres
            int  vagasLivres = totalDeVagas - veiculos.Count;

            Console.WriteLine($"Vagas Livres: {vagasLivres}");
        }

        public void AdicionarVeiculo()
        {
            //verifica se tem vagas livres
            if(veiculos.Count >= totalDeVagas)
            {
                Console.WriteLine("Descupe. Estamos sem vagas disponíveis.");
            }
            else
            {
                bool vazioOuEmBranco = true;

                while(vazioOuEmBranco == true)
                {
                    Console.WriteLine("Digite a placa do veículo para estacionar:");
                    string placaValida = Console.ReadLine();

                    //Verifica se a variável (placaValida) não está vazia ou apenas com espaços em branco:
                    if(string.IsNullOrWhiteSpace(placaValida))
                    {
                        Console.WriteLine("Você não informou a placa do carro. Este é um item OBRIGATÓRIO!");
                        Console.WriteLine("Por favor, Informe a placa do carro:");

                        vazioOuEmBranco = true;
                    }
                    else
                    {
                        ///Garanti que não tenha placas repetidas
                        if(veiculos.Contains(placaValida))
                        {
                            Console.WriteLine();

                            Console.WriteLine("Descupe, mas já existe um veículo cadastrado com essa placa.");
                            Console.WriteLine("Verifique se digitou corretamente e tente novamente.");

                            Console.WriteLine();

                            vazioOuEmBranco = true;
                        }
                        else
                        {
                            veiculos.Add(placaValida);
                            horaDeEntrada.Add(DateTime.Now);

                            vazioOuEmBranco = false;
                        }
                    
                    }
    
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
                        //índice da lista
                        int indice = veiculos.IndexOf(placa);

                        //Hora de saída
                        DateTime horaDeSaida = DateTime.Now;

                        //Calculo do tempo que ficou estacionado
                        TimeSpan tempoEstacionado = horaDeSaida - horaDeEntrada[indice];

                        //Calculo do Valor Total a ser pago
                        decimal valorTotal = taxaDeEntrada + precoPorHora * Convert.ToDecimal(tempoEstacionado.TotalHours); 

                        Console.Clear();

                        //Extrato
                        Console.WriteLine(); //pular linha
                        Console.WriteLine("EXTRATO:");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"Veículo (palca):        {veiculos[indice]:hh:mm:ss}");
                        Console.WriteLine($"Horário de Entrada:     {horaDeEntrada[indice]:hh:mm:ss}");
                        Console.WriteLine($"Horário de Saída:       {horaDeSaida:hh:mm:ss}");
                        Console.WriteLine($"Tempo Estacionado:      {tempoEstacionado:hh\\:mm\\:ss}");

                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"Taxa de Entrada:         {taxaDeEntrada:C2}");
                        Console.WriteLine($"Preço por hora:          {precoPorHora:C2}");
                        Console.WriteLine($"Valor:                   R$ {Math.Round(precoPorHora * Convert.ToDecimal(tempoEstacionado.TotalHours), 2)}  ");

                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"Valor Total:             R$ {Math.Round(valorTotal, 2)}");
                        Console.WriteLine(); //pular linha

                        
                        Console.WriteLine("Pressione Enter para confirmar o pagamento");

                        Console.ReadLine();

                        Console.WriteLine("Pagamento Recebido! \nObrigado por usar nosso serviços.");

                        Console.WriteLine(); // pular linha

                        //remover veículo o horário de entrada da lista
                        veiculos.RemoveAt(indice);
                        horaDeEntrada.RemoveAt(indice);

                        //encerrar laço de repetição
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
