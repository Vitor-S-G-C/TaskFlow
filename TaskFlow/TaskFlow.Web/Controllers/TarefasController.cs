using Microsoft.AspNetCore.Mvc;
using TaskFlow.Domain.Entities;
using TaskFlow.Services.Interfaces;

namespace TaskFlow.Web.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaService _service;
        public TarefasController(ITarefaService service)
        {
            _service = service;
        }

        public IActionResult Index(string? keyword, StatusTarefa? status)
        {
            var model = _service.Listar(keyword, status);
            ViewBag.Keyword = keyword;
            ViewBag.Status = status;
            return View(model);
        }
        
        public IActionResult Create()
        {
            return View(new Tarefa());
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            try
            {
                if (!ModelState.IsValid) return View(tarefa);
                _service.Criar(tarefa);
                TempData["Success"] = "Tarefa criada com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tarefa);
            }
        }

        public IActionResult Edit(int id)
        {
            var t = _service.Obter(id);
            if (t == null) return NotFound();
            return View(t);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            try
            {
                if (!ModelState.IsValid) return View(tarefa);
                _service.Atualizar(tarefa);
                TempData["Success"] = "Tarefa atualizada.";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(tarefa);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Excluir(id);
                TempData["Success"] = "Tarefa excluída.";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult MarcarConcluida(int id)
        {
            try
            {
                _service.MarcarConcluida(id);
                TempData["Success"] = "Tarefa marcada como concluída.";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
