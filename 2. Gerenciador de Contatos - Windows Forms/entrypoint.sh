#!/bin/bash
/opt/mssql/bin/sqlservr &

echo "Aguardando SQL Server iniciar..."
sleep 10s

echo "Executando init.sql..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i /usr/src/app/init.sql

# Mantém o container ativo
wait