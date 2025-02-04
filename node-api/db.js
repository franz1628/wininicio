const sql = require('mssql');

const config = {
    user: 'sa',
    password: 'StrongP@ssw0rd!',
    server: 'sqlserver',
    database: 'transactions_db',
    options: {
        encrypt: false,
        trustServerCertificate: true
    },
};

const pool = new sql.ConnectionPool(config);
pool.connect().then(() => console.log('Conectado a SQL Server'));

module.exports = pool;