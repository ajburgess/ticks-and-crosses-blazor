#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TicksBlazorWebAssembly/Server/TicksBlazorWebAssembly.Server.csproj", "TicksBlazorWebAssembly/Server/"]
COPY ["TicksBlazorWebAssembly/Client/TicksBlazorWebAssembly.Client.csproj", "TicksBlazorWebAssembly/Client/"]
COPY ["TicksBlazorWebAssembly/Shared/TicksBlazorWebAssembly.Shared.csproj", "TicksBlazorWebAssembly/Shared/"]
RUN dotnet restore "TicksBlazorWebAssembly/Server/TicksBlazorWebAssembly.Server.csproj"
COPY . .
WORKDIR "/src/TicksBlazorWebAssembly/Server"
RUN dotnet build "TicksBlazorWebAssembly.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicksBlazorWebAssembly.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicksBlazorWebAssembly.Server.dll"]