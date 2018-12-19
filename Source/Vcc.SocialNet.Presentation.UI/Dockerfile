FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Source/Vcc.SocialNet.Presentation.UI/Vcc.SocialNet.Presentation.UI.csproj", "Source/Vcc.SocialNet.Presentation.UI/"]
RUN dotnet restore "Source/Vcc.SocialNet.Presentation.UI/Vcc.SocialNet.Presentation.UI.csproj"
COPY . .
WORKDIR "/src/Source/Vcc.SocialNet.Presentation.UI"
RUN dotnet build "Vcc.SocialNet.Presentation.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Vcc.SocialNet.Presentation.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ASP.NET Core 2.1 with Angular 7.dll"]