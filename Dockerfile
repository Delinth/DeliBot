FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# COPY DeliBot.Console ./
# COPY DeliBot.Data ./
# COPY DeliBot.Service ./
# COPY DeliBot.sln ./
COPY . ./
RUN dotnet restore
RUN dotnet publish ./DeliBot.Console -c Release -o out


FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DeliBot.Console.dll"]