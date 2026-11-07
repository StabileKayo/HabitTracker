// Importa o namespace HabitTracker, permitindo utilizar suas classes
using HabitTracker;


var service = new HabitService();
var rodando = true;

// Executa o bloco de código repetidamente enquanto rodando for true
while (rodando)
{
    // Exibe as opçoes disponíveis no menu e solicita uma opção
    Console.WriteLine("\nHabit Tracker");
    Console.WriteLine("1 - Listar hábitos");
    Console.WriteLine("2 - Adicionar hábito");
    Console.WriteLine("3 - Alterar hábito");
    Console.WriteLine("4 - Excluir hábito");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Escolha: ");

    // Lê a opção digitada e returna uma string
    var opcao = Console.ReadLine();

    // Analisa o valor armazenado e executa o bloco
    // correspondente à opção escolhida
    switch (opcao)
    {
        case "0":
            // altera rodando para false finalizando o laço de repetição
            rodando = false;
            Console.WriteLine("Até logo!");
            break;
        case "1":
            // Chama o método responsável por listar os hábitos
            ListarHabitos(service);
            break;
        case "2":
            // Chama o método responsável por adicionar um hábito
            AdicionarHabito(service);
            break;
        case "3":
            // Chama o método responsável por alterar um hábito
            AlterarHabito(service);
            break;
        case "4":
            // Chama o método responsável por excluir um hábito
            ExcluirHabito(service);
                break;
        default:
            // Caso digite uma opção não específicada
            Console.WriteLine("Opção inválida");
            break;
    }
}

// Recebe o serviço responsável pelo gerenciamento dos hábitos.
static void ListarHabitos(HabitService service)
{
    // Solicita ao serviço todos os hábitos cadastrados
    var habits = service.ListarTodos();
    // Verifica se não existe nenhum hábito
    if (habits.Count == 0)
    {
        // Caso não exista hábitos criados, exibe uma mensagem informando
        Console.WriteLine("Nenhum hábito cadastrado");
        return;
    }

    Console.WriteLine("\nSeus hábitos:");
    // Percorre todos elementos da lista habits
    foreach (var h in habits)
    {   
        // Exibe Id, nome e data de criação do hábito
        Console.WriteLine($" {h.Id} - {h.Name} (criado em {h.CreatedAt:dd/MM/yyyy})");
    }
}
// Recebe o serviço responsável pelo gerenciamento dos hábitos
static void AdicionarHabito(HabitService service)
{
    Console.Write("Nome do hábito: ");
    // Lê o nome digitado
    var nome = Console.ReadLine();

    // Solicita ao serviço que tente adicionar o hábito
    // O resultado será um objeti Habit ou null
    var habit = service.Adicionar(nome);

    // verifica se o serviço retornou null
    if (habit is null)
        // Informa que o nome fornecido é inválido
        Console.WriteLine("O nome não pode ser vazio.");
    else
        // exibe o nome e o ID do hábito criado
        Console.WriteLine($"Hábito \"{habit.Name}\" adicionado com Id {habit.Id}.");
}

// Recebe o serviço responsável pelo gerenciamento dos hábitos
static void AlterarHabito(HabitService service)
{
    // Exibe todos os hábitos cadastrados
    ListarHabitos(service);

    // Verifica se a lista está vazia
    // Se estiver, encerra o método e retorna ao menu
    if (service.ListarTodos().Count == 0)
        return;

    // Solicita o ID ao usuário e tenta realizar sua conversão
    // Retorna um número inteiro ou null caso a entrada seja inválida 
    var id = LerId("Id do hábito que deseja alterar: ");

    // Se o ID for null, interrompe o método
    if (id is null) 
        return;

    // Solicita o novo nome do hábito
    Console.Write("Novo nome: ");
    var novoNome = Console.ReadLine();

    // Solicita ao serviço que tente alterar o hábito
    // id.Value obtém o valor inteiro amrazenado ao nullable int
    if (service.Alterar(id.Value, novoNome))
        Console.WriteLine("Hábito alterado com sucesso.");
    else
        Console.WriteLine("Não foi possível alterar (Id inexistente ou nome vazio).");
}
// Recebe o serviço responsável pelo gerenciamento dos hábitos
static void ExcluirHabito(HabitService service)
{
    // Exibe todos os hábitos cadastrados
    ListarHabitos(service);

    // verifica se existem hábitos para excluir
    // se alista estiver vazia, encerra o método
    if (service.ListarTodos().Count == 0) return;

    // Solicita o ID do hábito que será excluido
    var id = LerId("Id do hábito que deseja excluir: ");

    // Se o ID for inválido, encerra o método
    if (id is null)
        return;

    // Solicita ao serviço que tente excluir o hábito
    // Retorna true se conseguir excluir ou false se não encontrar o hábito
    if (service.Excluir(id.Value))
        Console.WriteLine("Hábito excluído.");
    else
        Console.WriteLine("Hábito não encontrado.");
}

// Recebe uma mensagem que será exibida ao solicitar um ID
// Retorna um número inteiro ou null caso a entrada seja inválida
static int? LerId(string mensagem)
{
    // Exibe a mensagem recebida como parâmetro
    Console.Write(mensagem);

    // Tenta converter a entrada do usuário para um número inteiro
    if (int.TryParse(Console.ReadLine(), out var id))
        // Se a conversão funcionar, retorna o ID informado
        return id;

    Console.WriteLine("Id inválido: digite apenas números.");
    // Retorna null para indicar que a entrada foi inválida
    return null;
}