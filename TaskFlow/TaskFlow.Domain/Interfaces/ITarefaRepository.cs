using System.Collections.Generic;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        IEnumerable<Tarefa> GetAll();
        IEnumerable<Tarefa> GetFiltered(string? keyword, StatusTarefa? status);
        Tarefa? GetById(int id);
        void Add(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Tarefa tarefa);
        void SaveChanges();
    }
}
