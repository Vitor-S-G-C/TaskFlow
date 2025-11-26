using System;
using System.Collections.Generic;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Services.Interfaces;

namespace TaskFlow.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repo;
        public TarefaService(ITarefaRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Tarefa> Listar(string? keyword, StatusTarefa? status)
            => _repo.GetFiltered(keyword, status);

        public Tarefa? Obter(int id) => _repo.GetById(id);

        public void Criar(Tarefa tarefa)
        {
            if (string.IsNullOrWhiteSpace(tarefa.Titulo))
                throw new ArgumentException("Título é obrigatório.");

            if (tarefa.Status == StatusTarefa.Concluida)
                tarefa.DataConclusao = tarefa.DataConclusao ?? DateTime.UtcNow;
            else
                tarefa.DataConclusao = null;

            tarefa.DataCriacao = DateTime.UtcNow;
            _repo.Add(tarefa);
            _repo.SaveChanges();
        }

        public void Atualizar(Tarefa tarefa)
        {
            if (string.IsNullOrWhiteSpace(tarefa.Titulo))
                throw new ArgumentException("Título é obrigatório.");

            var existent = _repo.GetById(tarefa.Id) ?? throw new InvalidOperationException("Tarefa não encontrada.");
            // business rule: DataConclusao only if status is Concluida
            if (tarefa.Status == StatusTarefa.Concluida && !existent.DataConclusao.HasValue)
                tarefa.DataConclusao = DateTime.UtcNow;
            if (tarefa.Status != StatusTarefa.Concluida)
                tarefa.DataConclusao = null;

            _repo.Update(tarefa);
            _repo.SaveChanges();
        }

        public void Excluir(int id)
        {
            var t = _repo.GetById(id) ?? throw new InvalidOperationException("Tarefa não encontrada.");
            _repo.Delete(t);
            _repo.SaveChanges();
        }

        public void MarcarConcluida(int id)
        {
            var t = _repo.GetById(id) ?? throw new InvalidOperationException("Tarefa não encontrada.");
            t.Status = StatusTarefa.Concluida;
            t.DataConclusao = t.DataConclusao ?? DateTime.UtcNow;
            _repo.Update(t);
            _repo.SaveChanges();
        }
    }
}
