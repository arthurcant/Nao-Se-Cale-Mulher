# Nao-Se-Cale-Mulher
O projeto Não Se Cale é um site com intuito de divulgar informações de grande relevância social para mulheres que sofrem de violência domestica, física e psicológica.

Possuir um client feito em Reactjs e uma  API ``.Net 6.0``. Que possuir Swagger, Sistema de login com tokens JWT, Serilog entre outros, implementados.

# Como executar

- Realize o download do .Net 6 SDK e Visual Studio/Code.
- instale o mysql 8, 0, 31 e dentro da pasta Banco de dados tem todo o script do banco da aplicação.
- Vá para o arquivo appsetting.json e atualize a string de conexão para o da sua máquina.
- Vá para a pasta API-SITE-Mulher e rode esse seguinte comando:
> dotnet run

- Depois que dê um
> npm install
- Dentro da pasta naosecale para está instalando as dependencias necessarias para roda o client da aplicação.

# Collections
Na pasta Collections da API contem 4 arquivos de configuração para importar todos os end-points para um cliente como postman/insomnia.

## Autenticação
Neste projeto, algumas rotas precisam de autenticação/autorização. Para isso, você terá que utilizar a rota ``api/auth/v1/signin`` para obter o JWT.
Por padrão, você tem um usuário disponívei para login:
- Usuário teste: 
{
  "email": "Admin@gmail.com",
  "password": "admin213!"
}

Depois disso, você pode passar o JWT clicando no cadeado (se estiver usando swagger) ou via o cabeçalho `Authorization` se tiver realizando uma requisição http.

# Este projeto contém:
- Integração com o Banco de Dados MySql
- Versionamento de Endpoints
- Arquitetura em Camadas
- Generic Repository
- Value Object (VO)
- Custom Serialization
- Content Negociation
- Swagger (OpenAPI)
- CORS (Cross-origin resource sharing)
- Autenticação com tokens JWT
- Query Params e Paged Search (ou paginação)
- Consumindo a API com ReactJS
- SwaggerUI
- EntityFramework
- Injeção de Dependência

# Estrutura do Projeto

1. Business: a camada responsável por tratar das regras de negocios da Api fazendo chamadas diretamente para a camada Repository ou converte os dados do banco para VO (Value object) caso necessário.
2. Configurations: a camada que contém uma class chamada TokenConfiguration que esse class contém os atributos de configuração do token JWT.
3. Controllers: a camada que vai receber as requisições em Http do client.
4. Data : a camada que tabalha com o VO (value object) da aplicação.
5. Model:  é a camada que contém as entidades da aplicação que o ORM EntityFramework usar para mapear os objetos para o banco de dados da aplicação.
6. Repository: é a camada que mexer diretamente com o banco de dados.
7. Services: é a camada que Gerar os tokens JWT e outras coisas relacionadas também. `
8. Enum: é a camada que contem um arquivo de enumeradores

# Caso tenha gostado deste repositório, dê uma estrela!
Se este template foi útil para você ou se você aprendeu algo, por favor dê uma estrela! :star:
