#!/bin/bash
# Esperar a que SQL Server esté listo
sleep 30s

# Ejecutar el script SQL
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P StrongP@ssw0rd! -d master -i /sqlserver/init.sql
