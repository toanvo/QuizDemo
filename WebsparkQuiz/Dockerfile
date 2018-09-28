FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 61042
EXPOSE 44372

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebsparkQuiz/WebsparkQuiz.csproj", "WebsparkQuiz/"]
RUN dotnet restore "WebsparkQuiz/WebsparkQuiz.csproj"
COPY . .
WORKDIR "/src/WebsparkQuiz"
RUN dotnet build "WebsparkQuiz.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebsparkQuiz.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebsparkQuiz.dll"]