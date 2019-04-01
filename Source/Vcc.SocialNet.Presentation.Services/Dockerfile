FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Source/Vcc.SocialNet.Presentation.Services/Vcc.SocialNet.Presentation.Services.csproj", "Source/Vcc.SocialNet.Presentation.Services/"]
RUN dotnet restore "Source/Vcc.SocialNet.Presentation.Services/Vcc.SocialNet.Presentation.Services.csproj"
COPY . .
WORKDIR "/src/Source/Vcc.SocialNet.Presentation.Services"
RUN dotnet build "Vcc.SocialNet.Presentation.Services.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Vcc.SocialNet.Presentation.Services.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vcc.SocialNet.Presentation.Services.dll"]