#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY Source/Vcc.SocialNet.Presentation.UI/Vcc.SocialNet.Presentation.UI.csproj Source/Vcc.SocialNet.Presentation.UI/
COPY Source/Vcc.SocialNet.Data/Vcc.SocialNet.Data.csproj Source/Vcc.SocialNet.Data/
COPY Source/Vcc.SocialNet.Domain.Model/Vcc.SocialNet.Domain.Model.csproj Source/Vcc.SocialNet.Domain.Model/
RUN dotnet restore Source/Vcc.SocialNet.Presentation.UI/Vcc.SocialNet.Presentation.UI.csproj
COPY . .
WORKDIR /src/Source/Vcc.SocialNet.Presentation.UI
RUN dotnet build Vcc.SocialNet.Presentation.UI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Vcc.SocialNet.Presentation.UI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vcc.SocialNet.Presentation.UI.dll"]
