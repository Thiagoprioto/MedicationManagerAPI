# MedicationManagerAPI

# Medication Manager API

Este projeto é uma **API REST** para o gerenciamento de médicos e medicamentos, desenvolvida em **C#** com o framework **.NET 10**.  
A aplicação permite o **cadastro, atualização, consulta e remoção de medicamentos e médicos**, com suporte a **vínculo com usuários autenticados via JWT**, utilizando uma arquitetura em camadas bem definida, ORM moderno e um sistema global de tratamento de exceções.

🌐 **API em Produção / Documentação Live:**  
👉 [https://medicationmanagerapi.onrender.com/scalar/v1](https://medicationmanagerapi.onrender.com/scalar/v1)
---

## 🚀 Tecnologias e Ferramentas

- **C# / .NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core 10.0**
- **Microsoft SQL Server**
- **JWT (JSON Web Tokens)**
- **Scalar API Reference / OpenAPI 10.0**
- **Docker**
- **Render / Somee** (Hospedagem & Nuvem)

---

## 🏗️ Arquitetura do Projeto

A aplicação segue uma **arquitetura em camadas**, garantindo separação de responsabilidades, manutenibilidade e escalabilidade:

- **Controller**
    - Exposição dos endpoints REST
    - Recebimento e validação de requests
- **Service**
    - Regras de negócio
    - Gerenciamento de autenticação e geração de tokens
- **Repository / Context**
    - Persistência de dados via Entity Framework Core (`DbContext`)
- **DTO (Data Transfer Object)**
    - Abstração das entradas e saídas de dados
    - Proteção das entidades de domínio
- **Entity**
    - Representação do banco de dados (`MedicationEntity`, `DoctorEntity`, `UserEntity`)
- **Mapper**
    - Conversão entre Entidades e DTOs
- **Exception Handler**
    - Tratamento global de exceções via `IExceptionHandler`
    - Padronização de respostas de erro (`ProblemDetails`)

---

## 📦 Estrutura de Pastas

```bash
MedicationManager
│
├── Context
│   └── MedicationManagerContext.cs
├── Controller
│   ├── AuthController.cs
│   ├── DoctorController.cs
│   └── MedicationController.cs
├── DTO
│   ├── Auth
│   │   ├── AuthResponseDTO.cs
│   │   ├── LoginDTO.cs
│   │   └── RegisterDTO.cs
│   ├── DoctorDTO.cs
│   └── MedicationDTO.cs
├── Entities
│   ├── DoctorEntity.cs
│   ├── MedicationEntity.cs
│   └── UserEntity.cs
├── Enums
│   └── DrugClassification.cs
├── Exception
│   └── GlobalExceptionHandler.cs
├── Mapper
│   ├── DoctorMapper.cs
│   └── MedicationMapper.cs
├── Migrations
└── Service
    ├── Interfaces
    │   ├── IAuth
    │   │   └── ITokenService.cs
    │   ├── IDoctorService.cs
    │   └── IMedicationService.cs
    ├── DoctorService.cs
    ├── MedicationService.cs
    └── TokenService.cs
```

---

## 🛣️ Endpoints da API

### 🔹 Criar um Novo Usuário
**POST** `/api/Auth/register`

#### Request Body
```json
{
  "name": "Teste",
  "email": "emailTeste@email.com",
  "password": "Senha123!"
}
```

### 🔹 Login de Usuário
**POST** `/api/Auth/login`

#### Request Body
```json
{
  "email": "emailTeste@email.com",
  "password": "Senha123!"
}
```

### 🔹 Todos os Endpoints (Requer Autenticação)
**POST** `/api/Doctor` ///
**POST** `/api/Medication`

#### Request Body
```http request
KEY = Authorization || VALUE = Bearer <seu_token_jwt>
```
```json
{
  "name": "Dr. Carlos Eduardo",
  "email": "carlos@hospital.com",
  "crm": "123456/SP",
  "userId": 1
}
```

---

## 🐳 Docker

```bash
docker build -t medication-manager .
docker run -p 8080:8080 medication-manager
```

---

## ▶️ Como Executar o Projeto

```bash
git clone [https://github.com/Thiagoprioto/MedicationManager.git](https://github.com/Thiagoprioto/MedicationManager.git)
cd MedicationManager
```

---

## 📌 Autor

Desenvolvido por **Thiago Prioto** 🚀

---

## 📄 Licença

MIT
