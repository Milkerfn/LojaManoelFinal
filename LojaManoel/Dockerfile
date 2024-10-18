## Use a imagem do SDK .NET 8 para compilar o projeto
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#
## Define o diretório de trabalho
#WORKDIR /app
#
## Copie o arquivo do projeto e restaure as dependências
#COPY LojaManoel/LojaManoel.csproj ./LojaManoel/
#RUN dotnet restore "LojaManoel/LojaManoel.csproj"

## Copie todos os arquivos do projeto
#COPY LojaManoel/. ./LojaManoel/
#
## Compila o projeto
#RUN dotnet build "LojaManoel/LojaManoel.csproj" -c Release -o /app/build
#
## Use a imagem do runtime do .NET
#FROM mcr.microsoft.com/dotnet/aspnet:8.0
#WORKDIR /app
#COPY --from=build /app/build .
#
## Exponha a porta e inicie a aplicação
#EXPOSE 80
#ENTRYPOINT ["dotnet", "LojaManoel.dll"]
#