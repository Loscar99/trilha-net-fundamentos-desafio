using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

// DateTime data1 = DateTime.Now;
// DateTime data2 = Convert.ToDateTime("08:30");

// TimeSpan data3 = data2 - data1;
// //double totalHoras = data3.TotalHours;
// decimal valorPorHora = 10.00m;

// decimal valorTotal = Convert.ToDecimal(data3.TotalHours) * valorPorHora;

// valorTotal = Math.Round(valorTotal, 2);

// Console.WriteLine(data1);
// Console.WriteLine(data2);
// Console.WriteLine(data3);
// Console.WriteLine(valorTotal);

decimal taxaDeEntrada = 0;
decimal precoPorHora = 0;
int totalVagas = 0;
 
Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Vamos iniciar as configurações inciais:");

Console.Write("Total de vagas do estacionamento: ");
totalVagas = Convert.ToInt32(Console.ReadLine());

Console.Write("Preço/Taxa de entrada: ");
taxaDeEntrada = Convert.ToDecimal(Console.ReadLine());

Console.Write("Preço por hora: ");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

Console.Clear();

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new(taxaDeEntrada, precoPorHora, totalVagas);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Consultar Vagas Disponiveis");
    Console.WriteLine("2 - Cadastrar veículo");
    Console.WriteLine("3 - Remover veículo");
    Console.WriteLine("4 - Listar veículos");
    Console.WriteLine("5 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.DisponibilidadeVagas();
            break;
        case "2":
            es.AdicionarVeiculo();
            break;

        case "3":
            es.RemoverVeiculo();
            break;

        case "4":
            es.ListarVeiculos();
            break;

        case "5":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
