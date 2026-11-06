// Importa o namespace HabitTracker, permitindo utilizar suas classes
using HabitTracker;


// Cria uma lista vazia de objetos do tipo Habit
var habits = new List<Habit>();
// Controla o próximo Id que será atribuido a um hábito
var proximoId = 1;
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
            // Chama o método ListarHabitos caso digite 1
            ListarHabitos(habits);
            break;
        case "2":
            {
                // Solicita o nome do novo hábito
                Console.WriteLine("Nome do hábito: ");
                var nome = Console.ReadLine();

                // Verifica se o nome é nulo, vazio ou contém apenas espaços em branco
                if (string.IsNullOrWhiteSpace(nome))
                {   
                    Console.WriteLine("O nome não pode ser vazio.");
                    break;
                }

                // Cria um novo objeto Habit e adiciona à lista
                habits.Add(new Habit
                {
                    //Atribui o Id atual e incrementa proximoId em 1
                    Id = proximoId++,
                    //Atribui o nome informado, remove espaços em branco do inicio e do final do nome
                    Name = nome.Trim(),
                    //Registra a data e o horário atual
                    CreatedAt = DateTime.Now 
                });
                // Informa que o cadastro foi realizado e encerra o case
                Console.WriteLine("Hábito adicionado!");
                break;
            }
        case "3":
            {
                // Exibe todos os hábitos cadastrados
                ListarHabitos(habits);

                // Verifica se a lista está vazia
                // se não houver hábitos, interrompe o switch e volta ao menu
                if (habits.Count == 0) break;

                Console.Write("Id do háabito que deseja alterar: ");

                // Tenta converter a entrada do usuário para inteiro
                // Se a conversão falhar, exibe uma mensagem e interrompe o switch
                if (!int.TryParse(Console.ReadLine(), out var id))
                {
                    Console.WriteLine("Id inválido: digite apenas números.");
                    break;
                }

                // Procura na lista o primeiro hábito cujo ID corresponde ao informado
                // se não encontrar nenhum, retorna null
                var habit = habits.FirstOrDefault(h => h.Id == id);

                // verifica se o hábito nao foi encontrado
                if (habit is null)
                {
                    Console.WriteLine("Hábito não encontrado.");
                    break;
                }

                Console.Write("Novo nome: ");
                var novoNome = Console.ReadLine();

                // Verifica se o novo nome é null, vazio ou contém espaços
                if (string.IsNullOrWhiteSpace(novoNome))
                {
                    Console.WriteLine("O nome não pode ser vazio.");
                    break;
                }

                // Atualiza o nome do hábito, removendo espaços extras do inicio e do final
                habit.Name = novoNome.Trim();

                Console.WriteLine("Hábito alterado.");
                break;
            }
        
        case "4":
            {
                ListarHabitos(habits);
                if (habits.Count == 0) break;

                // Tenta converter a entrada do usuário para inteiro
                // Se a conversão falhar, exibe uma mensagem e interrompe o switch
                Console.Write("Id do hábito que deseja excluir: ");
                if (!int.TryParse(Console.ReadLine(), out var id))
                {
                    Console.WriteLine("Id invpalido: digite apenas números");
                    break;
                }

                var habit = habits.FirstOrDefault(h => h.Id == id);
                if (habit is null)
                {
                    Console.WriteLine("Hábito não encontrado");
                    break;
                }

                // Remove da lista o objeto correspondente ao hábito encontrado.
                habits.Remove(habit);
                Console.WriteLine("Hábito excluído.");
                break;
            }
        default:
            // Caso digite uma opção não específicada
            Console.WriteLine("Opção inválida");
            break;
    }
}

// Declara um método estático que recebe uma lista de objetos Habit como parâmetro
static void ListarHabitos(List<Habit> habits)
{
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