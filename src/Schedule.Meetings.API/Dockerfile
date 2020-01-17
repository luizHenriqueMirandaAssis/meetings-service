FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Schedule.Meetings.API/Schedule.Meetings.API.csproj", "src/Schedule.Meetings.API/"]
COPY ["src/Schedule.Meetings.Infrastructure.Ioc/Schedule.Meetings.Infrastructure.Ioc.csproj", "src/Schedule.Meetings.Infrastructure.Ioc/"]
COPY ["src/Schedule.Meetings.Application/Schedule.Meetings.Application.csproj", "src/Schedule.Meetings.Application/"]
COPY ["src/Schedule.Meetings.Domain/Schedule.Meetings.Domain.csproj", "src/Schedule.Meetings.Domain/"]
COPY ["src/Schedule.Meetings.Infrastructure.Data/Schedule.Meetings.Infrastructure.Data.csproj", "src/Schedule.Meetings.Infrastructure.Data/"]
RUN dotnet restore "src/Schedule.Meetings.API/Schedule.Meetings.API.csproj"
COPY . .
WORKDIR "/src/src/Schedule.Meetings.API"
RUN dotnet build "Schedule.Meetings.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Schedule.Meetings.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Schedule.Meetings.API.dll"]