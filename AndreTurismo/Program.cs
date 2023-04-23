using AndreTurismo.Controllers;
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
         CityModel cidade = new CityModel();
         cidade.Descricao = "Goiânia";
         cidade.Data_Cadastro_Cidade = DateTime.Now;

         new CityService().InserirCidade(cidade);

         AddressModel endereco = new AddressModel();
         endereco.Cidade = cidade;
         endereco.CEP = "12345678";
         endereco.Logradouro = "Rua Dapper";
         endereco.Numero = 123;
         endereco.Bairro = "Bairro Dapper";
         endereco.Complemento = "Complemento Dapper";
         endereco.Data_Cadastro_Endereco = DateTime.Now; 

         new AddressService().InserirEndereco(endereco);

         ClientModel cliente = new ClientModel();
         cliente.Nome = "Guilherme";
         cliente.Telefone = "(16)99999999";
         cliente.Data_Cadastro_Cliente = DateTime.Now;
         cliente.Endereco = endereco;

         new ClientService().InserirCliente(cliente);

         HotelModel hotel = new HotelModel();
         hotel.Nome = "Hotel 10 estrelas";
         hotel.Data_Cadastro_Hotel = DateTime.Now;
         hotel.Valor_Hotel = 200;
         hotel.Endereco = endereco;

         new HotelService().InserirHotel(hotel);

         TicketModel passagem = new TicketModel();
         passagem.Origem = endereco;
         passagem.Destino = endereco;
         passagem.Data = DateTime.Now;
         passagem.Cliente = cliente;
         passagem.Valor_Passagem = 100.0M;

         new TicketService().InserirPassagem(passagem);  

         PackageModel pacote = new PackageModel();
         pacote.Data_Cadastro_Pacote = DateTime.Now;
         pacote.Cliente_Pacote = cliente;
         pacote.Valor_Pacote = 100.0M;
         pacote.Hotel_Pacote = hotel;
         pacote.Passagem_Pacote = passagem;

         new PackageService().InserirPacote(pacote);
        */
        //Console.WriteLine(new CityService().RetornarCidade(1));

        //Console.WriteLine(new AddressService().RetornarEndereco(1));

        //Console.WriteLine(new ClientService().RetornarCliente(1));

        //Console.WriteLine(new HotelService().RetornarHotel(1));

        //Console.WriteLine(new TicketService().RetornarPassagem(1));

        /*
        List<PackageModel> pacotes = new List<PackageModel>();

        pacotes = new PackageService().ListarTodasPacotes();
        
        foreach (var pacote in pacotes)
        {
            Console.WriteLine(pacote);
            Console.WriteLine();
        }*/



        /******************************************************************/

        // INSERÇÃO E BUSCA DE CIDADE 

        /*
        CityModel cidade = new CityModel();
        cidade.Descricao = "Ribeirão Bonito";
        cidade.Data_Cadastro_Cidade = DateTime.Now; 

        bool verifica = new CityController().InsertCidade(cidade);

        if(verifica) 
        {
            Console.WriteLine("Cidade inserida com sucesso");
        }
        else
        {
            Console.WriteLine("Não possível inserir a cidade");
        }

        
        CityModel cidade = new CityModel();
        cidade = new CityController().RetornarCidadePorID(1);

        Console.WriteLine(cidade);  
        */

        //INSERÇÃO E BUSCA DE ENDEREÇO

        /*
        AddressModel endereco = new AddressModel();
        endereco.Logradouro = "Logradouro teste controller";
        endereco.Numero = 1;
        endereco.Bairro = "Bairro teste controller";
        endereco.CEP = "123456789";
        endereco.Complemento = "Próximo ao service";

        CityModel cidade = new CityModel();
        cidade.Descricao = "Cidade teste controller";
        cidade.Data_Cadastro_Cidade = DateTime.Now; 

        endereco.Cidade = cidade;
        endereco.Data_Cadastro_Endereco = DateTime.Now; 

        endereco = new AddressController().InsertEndereco(endereco);
        
        if(endereco.Id != 0) 
        {
            Console.WriteLine("Endereço inserido com sucesso !");
        }
        else
        {
            Console.WriteLine("Não possível inserir o endereco");
        }
        */

        AddressModel endereco = new AddressModel();
        endereco.Logradouro = "Logradouro teste controller 3";
        endereco.Numero = 1;
        endereco.Bairro = "Bairro teste controller 3";
        endereco.CEP = "12345678";
        endereco.Complemento = "Próximo ao service 3";

        CityModel cidade = new CityModel();
        cidade.Descricao = "Cidade teste controller 3";
        cidade.Data_Cadastro_Cidade = DateTime.Now;

        endereco.Cidade = cidade;
        endereco.Data_Cadastro_Endereco = DateTime.Now;

        //endereco = new AddressService().InserirEndereco(endereco);

        endereco = new AddressController().InsertEndereco(endereco);    

        Console.WriteLine(endereco.Id);

        Console.WriteLine("BUSCA POR ENDEREÇO");
        endereco = new AddressController().RetornarEnderecoPorID(1);
        Console.WriteLine(endereco);

        ClientModel cliente = new ClientModel();
        cliente.Telefone = "123456789";
        cliente.Nome = "Pedro";
        cliente.Data_Cadastro_Cliente = DateTime.Now;
        cliente.Endereco = endereco;

        cliente = new ClientController().InsertClient(cliente);
        
        Console.WriteLine("ID do cliente: " + cliente.Id);

        Console.WriteLine();    
        Console.WriteLine("Retorno do cliente");
        Console.WriteLine();
        cliente = new ClientController().RetornarClientePorID(2);
        Console.WriteLine(cliente);

        HotelModel hotel = new HotelModel();
        hotel.Nome = "Hotel 20 estrelas";
        hotel.Valor_Hotel = 200.0M;
        hotel.Data_Cadastro_Hotel = DateTime.Now;
        hotel.Endereco = endereco;

        hotel = new HotelController().InsertHotel(hotel);

        Console.WriteLine();
        Console.WriteLine("ID HOTEL:" + hotel.Id);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Pesquisa do hotel por ID");
        hotel = new HotelService().RetornarHotel(1);
        Console.WriteLine(hotel);   
       

        TicketModel passagem = new TicketModel();
        passagem.Origem = endereco;
        passagem.Destino = endereco;
        passagem.Cliente = cliente;
        passagem.Data = DateTime.Now;
        passagem.Valor_Passagem = 200;

        passagem = new TicketController().InsertPassagem(passagem);

        Console.WriteLine();
        Console.WriteLine("ID passagem: " + passagem.Id);
        Console.WriteLine();

        PackageModel pacote = new PackageModel();
        pacote.Cliente_Pacote = cliente;
        pacote.Hotel_Pacote = hotel;
        pacote.Data_Cadastro_Pacote = DateTime.Now;
        pacote.Passagem_Pacote = passagem;
        pacote.Valor_Pacote = 100;

        pacote = new PackageController().InsertPacote(pacote);
        
        Console.WriteLine();
        Console.WriteLine("ID do pacote:" + pacote.Id);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(pacote);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("##################");
        Console.WriteLine("TESTES DO TOSTRING()");
        //Console.WriteLine(endereco);
        Console.WriteLine(pacote);
    }
}