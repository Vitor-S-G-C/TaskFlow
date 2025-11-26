using System.Collections.Generic;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Services.Interfaces
{
    public interface ITarefaService
    {
        IEnumerable<Tarefa> Listar(string? keyword, StatusTarefa? status);
        Tarefa? Obter(int id);
        void Criar(Tarefa tarefa);
        void Atualizar(Tarefa tarefa);
        void Excluir(int id);
        void MarcarConcluida(int id);
    }
}
