const express = require('express');
const bodyParser = require('body-parser');
const sql = require('mssql');
const db = require('./db');

const app = express();
app.use(bodyParser.json());

setTimeout(async () => {
    try {
        await db.connect();
        console.log('Conectado a SQL Server');
    } catch (err) {
        console.error('Error al conectar a SQL Server:', err);
    }
}, 30000);

app.post('/transactions', async (req, res) => {
    const { user_id, amount } = req.body;
    const request = new sql.Request(db);
    request.input('user_id', sql.Int, user_id);
    request.input('amount', sql.Decimal(10, 2), amount);
    await request.query('INSERT INTO transactions (user_id, amount) VALUES (@user_id, @amount)');
    res.json({ message: 'Transacción creada' });
});

app.get('/transactions', async (req, res) => {
    const request = new sql.Request(db);
    const result = await request.query('SELECT * FROM transactions');
    res.json(result.recordset);
});

app.get('/transactions/user/:userId', async (req, res) => {
    const { userId } = req.params;
    const request = new sql.Request(db);
    request.input('user_id', sql.Int, userId);
    const result = await request.query('SELECT * FROM transactions WHERE user_id = @user_id');
    res.json(result.recordset);
});

app.get("/health", (req, res) => {
    res.status(200).send("OK");
});

app.listen(3000, () => console.log('API de transacciones en http://localhost:3000'));