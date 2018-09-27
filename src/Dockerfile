FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY CustomerInviter/*.csproj ./CustomerInviter/
COPY CustomerInviter.Test/*.csproj ./CustomerInviter.Test/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app/CustomerInviter
RUN dotnet build

FROM build AS test
WORKDIR /app/CustomerInviter.Test
RUN dotnet test --verbosity:normal

FROM build AS publish
WORKDIR /app/CustomerInviter
RUN dotnet publish -c Release -o out

# Build runtime imageP
FROM microsoft/dotnet:2.1-runtime
WORKDIR /app
COPY --from=publish /app/CustomerInviter/out ./
ENTRYPOINT ["dotnet", "CustomerInviter.dll"]