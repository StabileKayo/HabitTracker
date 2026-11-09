namespace HabitTracker;

// Concentra a lógica dos hábitos. Não lê teclado nem imprime nada
// isso é responsabilidade do program.cs

public class HabitService
{
    // Cria uma lista privada para armazenar os hábitos
    // readonly impede que a variável receba uma nova lista,
    // mas prmite adicionar, remover e modificar seus elementos
    private readonly List<Habit> _habits = new();
    // Armazena o próximo ID que será atribuido a aum hábito
    // Começa em 1
    private int _proximoId = 1;
    // Cria uma lista privada para armazenar as conclusões dos hábitos
    private readonly List<Completion> _completions = new();
    // Retorna a lista de hábitos como uma coleção somente para leitura
    public IReadOnlyList<Habit> ListarTodos() => _habits;
    // Procura um hábito pelo ID informado
    // Retorna o hábito encontrado ou null caso não exista
    public Habit? BuscarPorId(int id) => _habits.FirstOrDefault(h => h.Id == id);

    // Recebe o nome de um hábito e tenta adiciona-lo à lista.
    // o parâmetro aceita string ou null.
    // retornaa o hábito criado ou null se o nome for inválido
    public Habit? Adicionar(string? nome)
    {
        // Verifica se o nome é null, vazio ou contém apenas espaços.
        if (string.IsNullOrWhiteSpace(nome))
            return null;

        // cria um novo objeto da classe Habit
        var habit = new Habit
        {
            // Atribui o ID atual e incrementa o contador
            Id = _proximoId++,

            // remove espaços em branco do inicio e do final do nome
            Name = nome.Trim(),

            // registra a data e o horário atuais
            CreatedAt = DateTime.Now
        };

        // Adicionado o novo hábito à lista
        _habits.Add(habit);

        // retorna o objeto criado para quem chamou o método
        return habit;
    }
    // Recebe o ID do hábito e seu novo nome
    // Retorna true se a alteração for realizada ou false se falhar
    public bool Alterar(int id, string? novoNome)
    {
        // Impede a alteração caso o novo nome seja inválido
        if (string.IsNullOrWhiteSpace(novoNome))
            return false;

        // procura o hábito pelo ID utilizando o método BuscarPorId
        var habit = BuscarPorId(id);

        // Verifica se o hábito não foi encontrado
        if (habit is null)
            return false;

        // Atualiza o nome do hábito, removendo espaços extras
        habit.Name = novoNome.Trim();
        return true;
    }
    // Recebe o ID de um hábito e tenta removê-lo da lista
    // Retorna true se conseguir excluir ou false se o hábito não existir
    public bool Excluir(int id)
    {
        // Procura o hábito que possui o ID informado
        var habit = BuscarPorId(id);

        // Se não encontrar o hábito, retorna false
        if (habit is null)
            return false;

        // Remove o hábito da lista e retorna o resultado da operação
        return _habits.Remove(habit);
    }

    public IReadOnlyList<Completion> ListarConclusoes() => _completions;

    public bool EstaConcluido(int habitId, DateOnly date) =>
        _completions.Any(c => c.HabitId == habitId && c.Date == date);

    // Marca ou desmarca o hábito naquele dia
    // Devolve true se agora está concluído, false se a conclusão foi removida
    // e null se o hábito não existe.
    public bool? AlternarConclusao(int habitId, DateOnly date)
    {
        // Verifica se existe um hábito com o ID informado
        // Se não existir, retorna null e encerra o método
        if (BuscarPorId(habitId) is null)
            return null;

        // Procura uma conclusão que corresponda ao ID do hábito
        // e à data informada
        var existente = _completions.FirstOrDefault(
            c => c.HabitId == habitId && c.Date == date);
        
        // Verifica se já existe uma conclusão para esse hábito nessa data
        if (existente is not null)
        {
            // Remove a conclusão existente da lista
            _completions.Remove(existente);
            return false;
        }
        // Se não existir uma conclusão, cria uma nova
        // Passa o ID do hábito e a data para Completion
        _completions.Add(new Completion(habitId, date));
        return true;
    }


}