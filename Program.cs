// Importa o namespace HabitTracker, permitindo utilizar suas classes
using HabitTracker;


// Cria uma lista vazia de objetos do tipo Habit
var habits = new List<Habit>();

// Cria um novo objeto Habit e adicionaa à Lista
habits.Add(new Habit 
{ 
    Id = 1, 
    Name = "Academia", 
    CreatedAt = DateTime.Now 
});

// Chama o método ListarHabitos e passa a lista habits como argumento
ListarHabitos (habits);

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