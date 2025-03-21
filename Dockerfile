FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV DB_CONECTION_STRING="Server=sqlserverdocker; DataBase=DBNur;User ID=usNur;Password=xyz.789;Application Name=DBNur;TrustServerCertificate=True;Application Name=DBNur"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NutriCenter.API/NutriCenter.API.csproj", "NutriCenter.API/"]
COPY ["NutriCenter.Aplication/NutriCenter.Aplication.csproj", "NutriCenter.Aplication/"]
COPY ["NutriCenter.Infraestructure/NutriCenter.Infraestructure.csproj", "NutriCenter.Infraestructure/"]
COPY ["NutriCenter.Domian/NutriCenter.Domain.csproj", "NutriCenter.Domian/"]
COPY ["NutriCenter.Mapper/NutriCenter.Mapper.csproj", "NutriCenter.Mapper/"]
RUN dotnet restore "./NutriCenter.API/NutriCenter.API.csproj"
COPY . .
WORKDIR "/src/NutriCenter.API"
RUN dotnet build "./NutriCenter.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NutriCenter.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NutriCenter.API.dll"]


#docker build --no-cache -t tuapi:latest .
#docker run -d -p 9014:8080 --name atuapi tuimagen:latest
#docker exec -it apicontainer sh
#docker system prune -a
