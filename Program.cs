// Importa o namespace HabitTracker, permitindo utilizar suas classes
using HabitTracker;


// Cria uma lista vazia de objetos do tipo Habit
var habits = new List<Habit>();
var rodando = true;

// Executa o bloco de código repetidamente enquanto rodando for true
while (rodando)
{

    // Exibe as opçoes disponíveis no menu e solicita uma opção
    Console.WriteLine("\nHabit Tracker");
    Console.WriteLine("1 - Listar hábitos");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Escolha: ");

    // Lê a opção digitada e returna uma string
    var opcao = Console.ReadLine();

    // Analisa o valor armazenado e executa o bloco
    // correspondente à opção escolhida
    switch (opcao)
    {
        case "1":
            // Chama o método ListarHabitos caso digite 1
            ListarHabitos(habits);
            break;
        case "0":
            // altera rodando para false finalizando o laço de repetição
            rodando = false;
            Console.WriteLine("Até logo!");
            break;
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