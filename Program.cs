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

// Percorre todos os elementos da lista habits.
foreach (var h in habits)
{   
    // Exibe o Id e o Nome do hábito atual
    Console.WriteLine($"{h.Id} - {h.Name}");
}