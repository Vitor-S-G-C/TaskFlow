using System;

namespace TaskFlow.Domain.Entities
{
    public enum StatusTarefa
    {
        Pendente = 0,
        EmProgresso = 1,
        Concluida = 2
    }

    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataConclusao { get; set; }
    }
}
