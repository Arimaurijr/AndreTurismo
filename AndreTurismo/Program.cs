﻿using AndreTurismo.Controllers;
using AndreTurismo.Models;
using AndreTurismo.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        /*
        CityModel cidade = new()
        {
            Descricao = "São Carlos - SP",
            Data_Cadastro_Cidade = DateTime.Now
        };

        new CityController().InsertCidade(cidade);
        */

        /*
        AddressModel endereco = new AddressModel();
        AddressService enderecoservice = new AddressService();
        endereco.Cidade = new CityModel()
        {
            Descricao = "Matão - sp",
            Data_Cadastro_Cidade = DateTime.Now,
        };
        endereco.Logradouro = "Rua 2";
        endereco.Bairro = "Bairro 2";
        endereco.CEP = "12345678";
        endereco.Complemento = "próximo a escola";
        endereco.Data_Cadastro_Endereco = DateTime.Now;

        enderecoservice.InserirEndereco(endereco);

        ClientModel cliente = new ClientModel();

        cliente.Nome = "João";
        cliente.Telefone = "123456789";
        cliente.Data_Cadastro_Cliente = DateTime.Now;
        cliente.Endereco = endereco;

        ClientService clienteservice = new ClientService();
        clienteservice.InserirCliente(cliente); 

        */
        /*
        AddressModel endereco = new AddressModel();

        
        endereco.Logradouro = "Rua teste";
        endereco.Numero = 666;
        endereco.Bairro = "Bairro teste";
        endereco.CEP = "12345678";
        endereco.Complemento = "Próximo ao teste";
        endereco.Data_Cadastro_Endereco = DateTime.Now;
        */

        /*
        AddressModel endereco = new AddressModel();
        Console.WriteLine("Digite o logradouro");
        endereco.Logradouro = Console.ReadLine();

        Console.WriteLine("Digite o numero");
        endereco.Numero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o bairro");
        endereco.Bairro = Console.ReadLine();

        Console.WriteLine("Digite o CEP");
        endereco.CEP = Console.ReadLine();

        Console.WriteLine("Digite o complemento");
        endereco.Complemento = Console.ReadLine();

        endereco.Data_Cadastro_Endereco = DateTime.Now;

        
        AddressController enderecocontrole = new AddressController();
        enderecocontrole.Insert(endereco);
        */
        /*
        AddressController endereco = new AddressController();
        int id_endereco = endereco.Insert();

        Console.WriteLine(id_endereco);
        */

        /*
        ClientController cliente = new ClientController();
        int id_endereco = cliente.InsertClient();
        Console.WriteLine();
        Console.WriteLine("ID de endereço inserido: " + id_endereco);
        */

        /*
        AddressModel endereco = new AddressModel();

        AddressController endereco_controller = new AddressController();
        endereco = endereco_controller.Insert();

        Console.WriteLine(endereco);
        */

        /*
        ClientController cliente_controler = new ClientController();

        ClientModel cliente_model = new ClientModel();

        cliente_model = cliente_controler.InsertClient();

        Console.WriteLine(cliente_model);
        */

        /*
        HotelModel hotelModel = new HotelModel();

        HotelController hotelController = new HotelController();

        hotelModel = hotelController.InsertHotel();

        Console.WriteLine(hotelModel);
        */

        /*
        TicketModel passagem_model = new TicketModel();

        TicketController passagem_controller = new TicketController();

        passagem_model = passagem_controller.InsertPassagem();

        Console.WriteLine(passagem_model);
        */

        /*
        PackageModel pacote_model = new PackageModel();

        pacote_model = new PackageController().InserirPacote();

        Console.WriteLine(pacote_model);
        */

        //Console.WriteLine(new AddressService().RetornarEndereco(1));

        //Console.WriteLine(new ClientService().RetornarCliente(1));

        //Console.WriteLine(new HotelService().RetornarHotel(1));

        //Console.WriteLine(new TicketService().RetornarPassagem(1));

       /*
        List<PackageModel> pacotes = new List<PackageModel>();


        pacotes = new PackageService().ListarTodasPacotes();

        foreach(var pacote in pacotes)
        {
            Console.WriteLine(pacote);
            Console.WriteLine("\n");
        }
       */
       /*
        AddressModel endereco = new AddressModel();

        endereco = new AddressController().RetornarEnderecoPorID(1);

        new AddressService().AtualizarEndereco(endereco,"id_cidade_endereco", "'3'");

        string data = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        new AddressService().AtualizarEndereco(endereco, "data_cadastro_endereco", "'" + data + "'");
       */
        CityModel cidade = new CityModel();
        cidade = new CityController().RetornarCidadePorID(1);

        new CityService().AtualizarCidade(cidade, "descricao", "'cidade atualizada'");

        ClientModel cliente = new ClientModel();

        cliente = new ClientController().RetornarClientePorID(1);

        new ClientService().AtualizarCliente(cliente, "nome_cliente", "'Guilherme'");

        HotelModel hotel = new HotelModel();

        hotel = new HotelController().RetornarHotelPorID(1);

        new HotelService().AtualizarHotel(hotel, "nome_hotel", "'Hotel 50 estrelas'");

        TicketModel passagem = new TicketModel();
        passagem = new TicketController().RetornarPassagemPorID(1);

        new TicketService().AtualizarPassagem(passagem, "valor_passagem", "1000.10");

        PackageModel pacote = new PackageModel();

        pacote = new PackageService().RetornarPacote(3);

        new PackageService().AtualizarPacote(pacote, "passagem_pacote", "77");
    }
}