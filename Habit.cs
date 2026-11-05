namespace HabitTracker;

// A classe 'Habit' representa um hábito e define quais informações ele possui
public class Habit
{
    // Identificador único do hábito
    // get permite consultar o valor e set permite modificar ele
    public int Id { get; set; }
    //Nome do hábito
    public string Name { get; set; } = "";
    //Armazena data e horário em que o hábito foi criado
    public DateTime CreatedAt { get; set; }
}