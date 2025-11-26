

**TaskFlow Jr.** - Mini sistema de gestão de tarefas (Desafio Técnico)

**Descrição**
- Aplicação ASP.NET MVC para gerenciar tarefas internas (CRUD, marcar concluída, filtros por status/título). Projeto organizado em camadas (Domain, Data, Services, Web) seguindo POCO.

**Stack**
- Linguagem: `C#`
- Framework: `ASP.NET Core (MVC)`
- ORM: `Entity Framework Core`
- Banco: `SQL Server` (LocalDB usado por padrão)

**Funcionalidades**
- CRUD completo de Tarefas (Listar, Criar, Editar, Excluir)
- Marcar tarefa como concluída
- Filtros: Status e palavra-chave no título
- Validações server-side: Título obrigatório; `DataConclusao` somente quando status for `Concluída`
- Mensagens de sucesso/erro amigáveis e layout simples com Bootstrap

**Onde estão os projetos**
- `TaskFlow.Domain` — entidades, enums, interfaces
- `TaskFlow.Data` — `AppDbContext`, repositório, migrations (Code First)
- `TaskFlow.Services` — regras de negócio (Services)
- `TaskFlow.Web` — camada MVC (Views, Controllers)

**Observação importante sobre versão**
- Atualização: o repositório foi atualizado para **.NET 8** e EF Core **8.0.0**. Se o avaliador exigir .NET 7, podemos reverter ou criar uma branch específica. Veja seção *Branches*.

**Como rodar (Windows / PowerShell)**
1. Verifique o SDK instalado:

```powershell
dotnet --list-sdks
```

2. Restaurar e compilar a solução (a partir da raiz onde está `TaskFlow.sln`):

```powershell
cd "c:\Users\vitor\Downloads\TaskFlow\TaskFlow"
dotnet restore "TaskFlow.sln"
dotnet build "TaskFlow.sln" -c Debug
```

3. (Opcional) Instalar/atualizar `dotnet-ef` (para migrações):

```powershell
dotnet tool install --global dotnet-ef --version 8.0.0
# ou
dotnet tool update --global dotnet-ef --version 8.0.0
```

4. Aplicar migrações / criar banco (a partir da pasta Web):

```powershell
cd "TaskFlow.Web"
# Se já existir migrações no projeto Data, apenas rode:
dotnet ef database update -p ..\TaskFlow.Data -s .
# Se for a primeira vez e quiser gerar a migração (faça apenas uma vez):
dotnet ef migrations add InitialCreate -p ..\TaskFlow.Data -s .
dotnet ef database update -p ..\TaskFlow.Data -s .
```

5. Executar a aplicação Web:

```powershell
dotnet run --project "TaskFlow.Web\TaskFlow.Web.csproj"
```

Abra no navegador: `https://localhost:5001/Tarefas` ou `http://localhost:5000/Tarefas`.

**Connection string**
- Ajuste `TaskFlow.Web\appsettings.json` se não quiser usar LocalDB. Exemplo padrão usado:

```json
"ConnectionStrings": {
	"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskFlowDb;Trusted_Connection=True;"
}
```

**Migrations / Banco**
- As migrations estão em `TaskFlow.Data\Migrations` (migration `InitialCreate` gerada). Incluir as migrations no repositório torna a reprodução do banco simples via `dotnet ef database update`.

**Branches / mudanças realizadas**
- `dotnet-8-upgrade` (recomendado): branch criada para agrupar a atualização para .NET 8, mudanças nos `*.csproj`, atualizações EF Core e pequenas correções nas Views.
- `main` / `submission`: se você prefere submeter com `.NET 7`, podemos preparar uma branch `submission-net7` com o código revertido para `net7.0` (posso fazer isso se desejar).

**Decisões de implementação**
- Padrão Repository para acesso a dados (`TarefaRepository`).
- Services (`TarefaService`) isolam regras de negócio e validações.
- Views simples com Razor + Bootstrap sem uso pesado de JavaScript.

**Notas de validação e usabilidade**
- Validação server-side implementada no `TarefaService` (lança `ArgumentException` quando necessário). Views exibem mensagens via `TempData`.

**Como preparar para envio (checklist)**
- Incluir migrations no repositório (`TaskFlow.Data\Migrations`) — já incluídas.
- Garantir `README.md` com instruções claras para execução — (este arquivo).
- Fazer commits claros e separáveis (ex.: `feat: upgrade to net8.0`, `fix: razor view issues`) — posso criar commits locais para você revisar.

**Contato / Observações finais**
- Projeto minimalista para fins do desafio técnico. Posso ajudar a:
	- Reverter para `.NET 7` se for um requisito
	- Criar branch limpa para submissão
	- Gerar Dockerfile / CI com imagem `mcr.microsoft.com/dotnet/aspnet:8.0`




