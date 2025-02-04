# Usar una imagen base con Node.js
FROM node:16

# Crear un directorio para la aplicación
WORKDIR /app

# Copiar el package.json e instalar dependencias
COPY package*.json ./
RUN npm install

# Copiar el resto de los archivos
COPY . .

# Exponer el puerto 3000
EXPOSE 3000

# Comando para ejecutar la aplicación
CMD ["node", "index.js"]