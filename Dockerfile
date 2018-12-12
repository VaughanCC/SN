FROM microsoft/dotnet:2.2-aspnetcore-runtime as base
WORKDIR /app
EXPOSE 80
RUN dotnet build Vcc.SocialNetwork.sln
RUN dotnet publish Vcc.SocialNetwork.sln --no-restore -c Release -o /publish

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vcc.SocialNet.Presentation.UI.dll"]




#---------------------------------------------------------------------------

FROM microsoft/aspnetcore-build:2

WORKDIR /api
COPY . .

RUN dotnet restore

RUN dotnet publish -o /publish

WORKDIR /publish
ENTRYPOINT ["dotnet", "/publish/api.dll"]
