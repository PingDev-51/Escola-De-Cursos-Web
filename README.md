<div align="center">

# 🎓 Escola de Cursos

### Sistema de gerenciamento de cursos em **ASP.NET MVC com Entity Framework**
Controle de cursos, categorias, instrutores, módulos, alunos, turmas e matrículas com separação de responsabilidades e regras de negócio reais.

---

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/GitHub_Actions-2088FF?style=for-the-badge&logo=github-actions&logoColor=white)
![Status](https://img.shields.io/badge/Status-Concluído-brightgreen?style=for-the-badge)

</div>

---

## 📌 Sobre o Projeto

A **Escola de Cursos** é um sistema completo para gerenciamento de uma plataforma educacional. A aplicação permite cadastrar cursos organizados por categorias e módulos, gerenciar instrutores e alunos, criar turmas e controlar matrículas — tudo com validações robustas e persistência de dados com Entity Framework.

O projeto foi desenvolvido com foco em:

- Organização em camadas (MVC)
- Separação de responsabilidades
- Regras de negócio reais
- Persistência de dados com Entity Framework Core
- Interface web responsiva e intuitiva

---

## 🌐 Acesse no Navegador

A aplicação está publicada e disponível online — sem necessidade de instalação:

**👉 [Acessar Escola De Cursos](https://escoladecursos-pingdev-dcazheaag5g2gufd.centralus-01.azurewebsites.net)**

---


## 🎬 Demonstração

![Demonstração do Sistema](./demo.gif)

---

## ✅ Funcionalidades

### 📚 Cursos

- Cadastro de cursos
- Visualização, edição e exclusão

**Regras:**
- Nome obrigatório (2 a 100 caracteres)
- Nível obrigatório: `Fácil`, `Médio` ou `Difícil`
- Carga horária obrigatória e maior que zero
- Módulo obrigatório
- Categoria obrigatória
- Não é permitido cadastrar dois cursos com o mesmo nome

---

### 🏷️ Categorias

- Cadastro de categorias
- Visualização, edição e exclusão

**Regras:**
- Nome obrigatório (2 a 100 caracteres)
- Não é permitido cadastrar duas categorias com o mesmo nome

---

### 👨‍🏫 Instrutores

- Cadastro de instrutores
- Visualização, edição e exclusão

**Regras:**
- Nome obrigatório (2 a 100 caracteres)
- Telefone obrigatório (formato `(XX) XXXX-XXXX` ou `(XX) XXXXX-XXXX`)
- Email obrigatório (formato válido)
- Graduação obrigatória (2 a 100 caracteres)
- Não é permitido cadastrar dois instrutores com o mesmo nome

---

### 🗂️ Módulos do Curso

- Cadastro de módulos
- Visualização, edição e exclusão

**Regras:**
- Nome obrigatório (2 a 100 caracteres)
- Duração obrigatória (valor não pode ser negativo)
- A ordem do módulo dentro de um curso não pode se repetir
- Não é permitido cadastrar dois módulos com o mesmo nome

---

### 🎓 Alunos

- Cadastro de alunos
- Visualização, edição e exclusão

**Regras:**
- Nome obrigatório (2 a 100 caracteres)
- Telefone obrigatório (formato `(XX) XXXX-XXXX` ou `(XX) XXXXX-XXXX`)
- Email obrigatório (formato válido)
- Número de matrícula gerado automaticamente após o cadastro
- Não é permitido cadastrar dois alunos com a mesma matrícula

---

### 👥 Turmas

- Cadastro de turmas
- Visualização, edição e exclusão

**Regras:**
- Nome obrigatório (2 a 100 caracteres)
- Curso obrigatório
- Instrutor obrigatório (cada turma deve possuir exatamente um instrutor)
- Número máximo de alunos obrigatório (1 a 100)
- Data de início obrigatória
- Data de término obrigatória e posterior à data de início
- Um aluno não pode ser matriculado duas vezes na mesma turma

---

### 📋 Matrículas

- Adição e remoção de alunos em turmas
- Visualização de todos os alunos de uma turma

**Regras:**
- Aluno obrigatório (somente alunos já cadastrados)
- Número da matrícula gerado automaticamente
- Curso obrigatório (somente turmas já cadastradas)
- Não é permitido matricular o mesmo aluno duas vezes na mesma turma

---

## 🧠 Conceitos Aplicados

| Conceito | Aplicação |
|---|---|
| 🏗️ Classes e Objetos | Modelagem das entidades do sistema |
| 🔒 Encapsulamento | Proteção dos dados internos |
| 📐 Padrão MVC | Separação entre Model, View e Controller |
| ⚙️ Regras de Negócio | Validações, restrições e geração automática de dados |
| 🗄️ Entity Framework Core | Persistência de dados em banco relacional |
| 🔗 Comunicação entre Classes | Integração entre os módulos |
| 🌐 Aplicação Web | Interface responsiva via navegador |

---

## ⚙️ Tecnologias Utilizadas

- C#
- ASP.NET MVC
- Entity Framework Core
- Bootstrap

---

## ▶️ Como Executar Localmente

### 1. Clone o repositório

```bash
git clone github.com/PingDev-51/Escola-De-Cursos-Web.git
```

### 2. Acesse a pasta do projeto

```bash
cd escola-de-cursos
```

### 3. Configure a string de conexão

No arquivo `appsettings.json`, ajuste a string de conexão com o seu banco de dados:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=seu-servidor;Database=EscolaDeCursos;Trusted_Connection=True;"
}
```

### 4. Aplique as migrations

```bash
dotnet ef database update
```

### 5. Execute o projeto

```bash
dotnet run --project EscolaDeCursos.WebApp
```

### 6. Acesse no navegador

```
https://localhost:5001
```

---

## 📋 Requisitos

- .NET SDK instalado
- Visual Studio 2022 ou superior
- SQL Server ou banco compatível com Entity Framework Core

---

## 🎯 Objetivo de Aprendizado

Este projeto foi desenvolvido para praticar:

- ✔️ Desenvolvimento de aplicações web com ASP.NET MVC
- ✔️ Persistência de dados com Entity Framework Core
- ✔️ Estilização responsiva com Bootstrap
- ✔️ Modelagem de entidades reais com regras de negócio
- ✔️ Organização modular e código limpo

---

## 👨‍💻 Autores

<div align="center">

Desenvolvido como parte dos estudos em **C# Desenvolvimento Web, Banco de dados SQL e Azure** na **Academia do Programador FullStack**.

[![GitHub](https://img.shields.io/badge/GitHub-KauanGalvani-181717?style=for-the-badge&logo=github)](https://github.com/KauanGalvani)
[![GitHub](https://img.shields.io/badge/GitHub-k--silvax19-181717?style=for-the-badge&logo=github)](https://github.com/k-silvax19)

</div>