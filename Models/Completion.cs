namespace HabitTracker;

// Uma conclusão: "o hábito X foi feito no dia Y".
// record = classe imutável feita para guardar dados (Equals e ToString prontos).
public record Completion(int HabitId, DateOnly Date);