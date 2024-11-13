# Car Rental API

API REST construída para gerenciar o aluguel de carros.

## Funcionalidades

- Adicionar um novo carro
- Listar todos os carros disponíveis para aluguel
- Alugar um carro por ID
- Alugar um carro por modelo
- Consultar o status de locação de um carro por ID
- Realizar a devolução de um carro por ID
- Realizar a devolução de um carro por modelo
- Deletar um carro por ID

## Tecnologias Utilizadas

- **ASP.NET Core**
- **C#**
- **Swagger**

## Endpoints Principais

- `POST /api/carros` - Adiciona um novo carro à frota
- `GET /api/carros` - Lista todos os carros disponíveis para aluguel
- `POST /api/carros/alugar/{id}` - Aluga um carro específico pelo ID
- `POST /api/carros/alugar/modelo/{modelo}` - Aluga um carro específico pelo modelo
- `GET /api/carros/{id}` - Consulta o status de locação de um carro por ID
- `PUT /api/carros/devolução/{id}` - Realiza a devolução de um carro pelo ID
- `PUT /api/carros/devolução/modelo/{modelo}` - Realiza a devolução de um carro pelo modelo
- `DELETE /api/carros/{id}` - Remove um carro da frota pelo ID
