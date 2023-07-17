## Verzel Test - APP
<img src="https://lh3.googleusercontent.com/fife/AKsag4OkNsOXwv4KczPliZTUoUrsBZqPCMtGXxct4GNFptQ7hmZxtiG6PQZwfyC1VIEb6_KFIVaDepksFDL8y1Psvv5p8NSqhcFZpsSt0j3S6luE6fdbFBugclwFCWK19x-FXIfRaJQLmJeq4BBAzgS3QSLeiBgCmj9t9x0UAQ1A_yiy5WlBETOfrmnGGYS3yHb1uDbmBEk8A2EZd1U88r6xlf0z52SNcmgqm52UUsiNEUt0MGICK_-61GbUp9ShIsStgWwqL1vOolgmSmA33q7NZtTOLVd7wVyxn7-Px71ifFXC2I9BbHkYqWa2RTvH_487OIXVAHOI1koOb9c0OhjFY_XzTYEkITki9D56w1PtTXBcKvI9pANFWiqkW6PYi6Zewomyst1LuPkxuzOFjREmemRR57_UnzJM_oV7gVj0_g0Aww0q8H9xVKz9aedX19PWFBICSaZwNhxWfu1cU9lAQR8hTM21_lgSQyAOc7zYYMYRJNf_ApRE6XZNcayE3QZtML7Kw3flEtXkEyjp3CmAEWs5UEDfCE5JMvC4SHI6tKGnhFnyHBy2XBUNmG8Gjw6pniPMVly5gFbFfNRpalrSuOhIvC2_C3OrhdvGA8ZkRWsphy4RE__FSZNOO_QI0jK_fDiqhanznukWOLS2JQmNnWAdaCrq_HdTIuafDsSMi1Ag-Q8IgVRqJosSBFUwZdqdXi0SbYax63_wXD5SpqUgkXUsZU0O9_YeiRylteBDSryy_JU98i0657AM9lpuCCYcWpReaYlfxQgQ1ojSdg78fWdDTyh3s1FScxRmMQnQN8en1eezfBfJipdQ-d8BlDbPWpg6nzkcYqDTw1AQlUERqZKbDftx9je0wOy5n6sk1OvPTihUgttNftkvZ5EZDft6fuUOlGBEjAIufUpxqufdxl5w1ibneQ63aAD_m2DwZCh4BRTng3O6DUbWnCfmAmyrE8ohtx5Ja9VeRLzgB64tg3SuEpF6HnynmXhG_IDxXklU8TCXEqixWGVRW2yCiMaWdixdqF625ca_fqHcKiblVH86-VcodOmkImiArrPraDxMoXnlI86JUDl0el4lL9BzOyYzOWrzbblqt5PFvI-G7QQts7_V5mIw7eAuIKykZE1ts2t6wm5_QsZC5ntJL0MSAcJA5ABkTnrzzFB95oPhFsBNUHdGyrurzA4h4r8nOcKbX6r6FEbsLoE-_QwvSxnfzt-cAjZuhGmWJpiegdusuLJDJOVnMrLXaU-H_A-MYmnBVudEEvoKaoBTfzuEfGGODmJryB_o5fI28OouzY8KHeQeKQtN4ecbbCwGsu4SsZK87LKq7PsVPgI481Rxd6i23G51lAg-wl7A3iXwYWtkRAJnYXBOs6ipenaGWpahQsDV_7mc85htayb1NLPeK3GGZW372MmCy_2DXAbgordNuU3woHC4ZvYL3Ar977zk20ofG8FC7670kHDPR-zg6p1jeif_LtHVDNTxhHYkBJMIMIoMDdhAuYTfh-98hOZOTAbDmzTP7OqlKiWCdT4vJnR1ZivOD85V_Xxvf-wy1yxXkHbseda9hqZ3tSu28VPH-ANzoMyqx7ZEwGpXX8U3kPdjOqeFXYePeX-r8T8O3yh_YFgnzseDl-bZWDTOA2Tz5WU009Yi=w1920-h892">

## Descrição do Projeto
Essa api se trata do BackEnd da aplicação onde foi realizado o desenvolvimento de um sistema de vitrine de carros para o teste, utilizei como inspiração o site http://www.kavak.com/br/carros-usados como pedido pelo requisito do teste da Verzel.

## Tecnologias Utilizadas
- .NET 6
- Entity Framework (EF) Core
- SQL Server

## Pré-requisitos
Antes de executar o projeto, certifique-se de ter instalado o seguinte:

- .NET 6 SDK: Download .NET 6
- SQL Server: Download SQL Server

## Configuração do Banco de Dados
1. Certifique-se de ter o SQL Server instalado e em execução.
2. Crie um banco de dados vazio no SQL Server para o projeto.

## Instruções de Configuração
1. No arquivo appsettings.json e appsettings.Development.json, insira a string de conexão com o banco de dados:
```json
{
  "ConnectionStrings": {
    "DBConnection": "sua-string-de-conexao-aqui"
  }
}
```
Substitua "sua-string-de-conexao-aqui" pela string de conexão correta para o seu banco de dados SQL Server.

## Migrations do Entity Framework
As migrations do Entity Framework permitem criar e atualizar o esquema do banco de dados de acordo com as alterações no modelo de dados.

1. Navegue até o diretório do projeto no terminal ou prompt de comando.
2. No terminal rode o comando abaixo para rodar as criar as tabelas no banco de dados e rodar as migrations:
```bash
dotnet ef database update
```
## Instalação
1. Clone este repositório: git clone https://github.com/rufedupo/verzel-test-api
2. Navegue para o diretório do projeto: cd verzel-test-api

## Executando a Aplicação
Para executar a aplicação, siga os passos abaixo:

1. Restaure as dependências do projeto: dotnet restore
2. Execute a aplicação: dotnet run

## Arquitetura e Design
O projeto foi desenvolvido seguindo com uma base no Domain-Driven Design (DDD) e utilizando o .NET 6 como plataforma de desenvolvimento. A arquitetura segue uma abordagem modular, com uma divisão clara de responsabilidades entre as camadas da aplicação.