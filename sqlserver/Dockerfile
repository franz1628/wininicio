# Usar la imagen oficial de SQL Server como base
FROM mcr.microsoft.com/mssql/server:2019-latest

# Ejecutar como root
USER root

# Configurar la variable de entorno para aceptar la licencia automáticamente
ENV ACCEPT_EULA=Y

RUN apt-get update && \
    apt-get install -y curl gnupg2 && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/msprod.list && \
    apt-get update && \
    apt-get install -y mssql-tools unixodbc-dev


# Volver al usuario por defecto de SQL Server
USER mssql
