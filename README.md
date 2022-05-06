This project uses User-Secrets

To init User-Secrets do:
dotnet user-secrets init --project Api

To set ConnectionString Secret do:
dotnet user-secrets set "DbVariables:ConnectionString" "server=xxxxx;user=xxx;database=xxx;password=xxx" --project 

