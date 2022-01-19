### Rodar projeto
```bash
dotnet run
dotnet watch run

# Via VS Code
F5

# Caso ocorra esse erro MySqlConnector.MySqlException... rode
yarn dev
yarn start
```

### Migrations
```bash
# Criar migration
dotnet ef migrations add <nome>

# Rodar as migration
dotnet ef database update

# Rollback
dotnet ef database update 0
dotnet ef migrations remove
```

#### Comandos executados para criar e atualizar o Projeto durante o desenvolemento
```bash
# Criar o projeto
dotnet new webapi

# Habilitar rodar o projeto em desenvolvimento com https sem ssl
dotnet dev-certs https --trust
```
