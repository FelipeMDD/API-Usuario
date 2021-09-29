API-Usuario

Projeto de API .Net Core, utilizando autenticação BEARER JWT, com conexão de dados SQL, utilizando uma base online hospedada no serviço AWS, Unit Tests, Entity Framework

Tutorial para utilização:

1 - Deve ser gerado um token de acesso utilizando o endpoint de login, enviar pelo body login e senha Ex: { "login": "admin",  "password": "admin" }, utilizamos dois usuarios de acesso, administrador que possui permissão para adicionar usuarios e visualizar todos os usuários, e o usuarios comum, que pode alterar sua própria senha e checar suas irformção

2 - Utilizando o token no postman selecionar a autenticação Bearer Token e adicionar o token enviado pelo endpoint de login 

3 - Acessar endpoints enviando informações pelo body ou rota

Usuarios:

    Administrador
    login: admin
    senha: admin

    Usuario
    login: usuario
    senha: usuario

Endpoints:

  /api/login - aberto

  /api/Administrador/adicionar - administrador
  /api/Administrador/usuarios - administrador
  
  /api/Common/{id} - administrador e usuario
  /api/Common/alterar - administrador e usuario


O projeto foi desenvolvido para aplicar conhecimentos 
