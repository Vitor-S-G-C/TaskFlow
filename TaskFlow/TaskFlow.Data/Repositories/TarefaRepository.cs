using System.Collections.Generic;
using System.Linq;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;
        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tarefa> GetAll() => _context.Tarefas.OrderByDescending(t => t.DataCriacao).ToList();

        public IEnumerable<Tarefa> GetFiltered(string? keyword, StatusTarefa? status)
        {
            var query = _context.Tarefas.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(t => t.Titulo.Contains(keyword));
            if (status.HasValue)
                query = query.Where(t => t.Status == status.Value);
            return query.OrderByDescending(t => t.DataCriacao).ToList();
        }

        public Tarefa? GetById(int id) => _context.Tarefas.Find(id);

        public void Add(Tarefa tarefa) => _context.Tarefas.Add(tarefa);

        public void Update(Tarefa tarefa) => _context.Tarefas.Update(tarefa);

        public void Delete(Tarefa tarefa) => _context.Tarefas.Remove(tarefa);

        public void SaveChanges() => _context.SaveChanges();
    }
}
