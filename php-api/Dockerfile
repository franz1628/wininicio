# Usar una imagen base con PHP y Apache
FROM php:8.2-apache

# Habilitar el módulo de Apache para reescribir URLs
RUN a2enmod rewrite

# Copiar los archivos de la aplicación
COPY . /var/www/html/

# Instalar PDO para MySQL
RUN docker-php-ext-install pdo pdo_mysql

# Exponer el puerto 80
EXPOSE 80