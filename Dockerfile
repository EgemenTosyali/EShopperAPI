FROM mcr.microsoft.com/dotnet/sdk:6.0 as sdkimage
WORKDIR /app

COPY ["EShopperAPI/Presentation/EShopperAPI.API/EShopperAPI.API.csproj", "EShopperAPI/Presentation/EShopperAPI.API/"]
COPY ["EShopperAPI/Core/EShopperAPI.Application/EShopperAPI.Application.csproj", "EShopperAPI/Core/EShopperAPI.Application/"]
COPY ["EShopperAPI/Core/EShopperAPI.Domain/EShopperAPI.Domain.csproj", "EShopperAPI/Core/EShopperAPI.Domain/"]
COPY ["EShopperAPI/Infrastructure/EShopperAPI.Infrastructure/EShopperAPI.Infrastructure.csproj", "EShopperAPI/Infrastructure/EShopperAPI.Infrastructure/"]
COPY ["EShopperAPI/Infrastructure/EShopperAPI.Persistence/EShopperAPI.Persistence.csproj", "EShopperAPI/Infrastructure/EShopperAPI.Persistence/"]
COPY ["EShopperAPI/Infrastructure/EShopperAPI.SignalR/EShopperAPI.SignalR.csproj", "EShopperAPI/Infrastructure/EShopperAPI.SignalR/"]
COPY ./*.sln .

RUN dotnet restore

COPY . .

RUN dotnet publish "EShopperAPI/Presentation/EShopperAPI.API/EShopperAPI.API.csproj" -o /publish/

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=sdkimage /publish .
ENV ASPNETCORE_URLS="http://+:1234" 
ENTRYPOINT ["dotnet", "EShopperAPI.API.dll", "--launch-profile EShopperAPI.API"]