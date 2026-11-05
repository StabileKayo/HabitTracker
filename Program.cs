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

                // Cria um novo objeto Habit e adiciona à lista
                habits.Add(new Habit
                {
                    //Atribui o Id atual e incrementa proximoId em 1
                    Id = proximoId++,
                    //Atribui o nome informado, se o nome for null, utiliza uma string vazia
                    Name = nome ?? "",
                    //Registra a data e o horário atual
                    CreatedAt = DateTime.Now 
                });
                // Informa que o cadastro foi realizado e encerra o case
                Console.WriteLine("Hábito adicionado!");
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