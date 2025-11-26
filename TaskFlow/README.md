# **TaskFlow Jr. – Mini Sistema de Gestão de Tarefas (Desafio Técnico)**

Aplicação ASP.NET MVC para gerenciamento interno de tarefas, permitindo criar, editar, listar, filtrar, concluir e excluir tarefas.
O projeto segue arquitetura em camadas (Domain, Data, Services, Web) com classes POCO.

---

##  **Tecnologias Utilizadas**

* **C#**
* **ASP.NET Core MVC** (atualizado para **.NET 8**)
* **Entity Framework Core 8**
* **SQL Server / LocalDB**
* **Bootstrap 5** (layout simples)

---

##  **Funcionalidades**

* CRUD completo de tarefas:

  * Criar
  * Editar
  * Listar
  * Excluir
* Marcar tarefa como **concluída**
* Filtros no painel:

  * Por status (Pendente / Concluída)
  * Por palavra-chave no título
* Validações server-side:

  * Título obrigatório
  * `DataConclusao` só pode ser preenchida quando o status for **Concluída**
* Mensagens amigáveis de feedback para o usuário

---

##  **Arquitetura do Projeto**

O projeto está dividido em 4 camadas:

### **1. TaskFlow.Domain**

* Entidades
* Enums
* Interfaces (ex: repositórios, serviços)

### **2. TaskFlow.Data**

* `AppDbContext`
* Repositórios
* Configurações do Entity Framework Core
* Migrations (Code First)

### **3. TaskFlow.Services**

* Regras de negócio
* Implementação dos serviços e validações

### **4. TaskFlow.Web**

* Controllers
* Views (Razor)
* ViewModels
* Configuração MVC

---

##  **Versões e Branches**

A solução está atualmente em:

* **.NET 8**
* **EF Core 8**

Caso o avaliador exija **.NET 7**, existe a possibilidade de criar uma branch específica ou fornecer instruções de downgrade.

---

##  **Como Rodar o Projeto (Windows / PowerShell)**

### 1. Verifique o SDK instalado

```powershell
dotnet --list-sdks
```

O projeto requer **.NET 8**.

---

### 2. Instale as dependências (restauração)

```powershell
dotnet restore
```

---

### 3. Aplicar migrations ao banco

```powershell
dotnet ef database update --project TaskFlow.Data --startup-project TaskFlow.Web
```

Isso criará o banco LocalDB automaticamente.

---

### 4. Rodar a aplicação

```powershell
dotnet run --project TaskFlow.Web
```

A aplicação ficará disponível em:

```
https://localhost:5001
```
