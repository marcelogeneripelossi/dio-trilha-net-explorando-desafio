using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

try
{
    string nome = string.Empty;
    int qtdeDeHospedes = 1;
    byte capaciddeDaSuite = 0;
    int diasReservados = 0;
    decimal valorDaDiaria = 0;

    do
    {
        Console.WriteLine("Digite o nome do {0}º hóspede (<ENTER> para avançar):", qtdeDeHospedes);
        nome = Console.ReadLine();
        if (string.IsNullOrEmpty(nome))
            continue;

        hospedes.Add(new Pessoa(nome: nome));
        qtdeDeHospedes++;

    } while (!string.IsNullOrEmpty(nome));


    Console.WriteLine("Digite a capacidade da Suíte:");
    if (!byte.TryParse(Console.ReadLine(), out capaciddeDaSuite))
        throw new Exception("Capacidade inválida.");

    Console.WriteLine("Digite o valor da Diária:");
    if (!decimal.TryParse(Console.ReadLine(), out valorDaDiaria))
        throw new Exception("Valor inválido.");

    Console.WriteLine("Digite a quantidade de Dias para Reserva:");
    if (!int.TryParse(Console.ReadLine(), out diasReservados))
        throw new Exception("Quantidade de Dias inválido.");

    Console.WriteLine();

    // Cria a suíte
    Suite suite = new Suite(tipoSuite: "Premium", capacidade: capaciddeDaSuite, valorDiaria: valorDaDiaria);

    // Cria uma nova reserva, passando a suíte e os hóspedes
    Reserva reserva = new Reserva(diasReservados: diasReservados);
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    // Exibe a quantidade de hóspedes e o valor da diária
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor da Hospedagem: {reserva.CalcularValorHospedagem()}");
}
catch (Exception excecao)
{
    Console.WriteLine();
    Console.WriteLine(excecao.Message);
}
Console.ReadLine();