<?php
require 'db.php';

header("Content-Type: application/json");

// Obtener la ruta solicitada
$request_uri = $_SERVER['REQUEST_URI'];
$uri_parts = explode('/', trim($request_uri, '/'));

// Determinar el método HTTP
$method = $_SERVER['REQUEST_METHOD'];

// Manejar las rutas

if ($uri_parts[0] == 'users') {
    if ($method === 'POST') {

        $data = json_decode(file_get_contents('php://input'), true);
        $name = $data['name'];
        $email = $data['email'];

        $stmt = $conn->prepare("INSERT INTO users (name, email) VALUES (:name, :email)");
        $stmt->bindParam(':name', $name);
        $stmt->bindParam(':email', $email);
        $stmt->execute();

        echo json_encode(['message' => 'Usuario creado']);
    } elseif ($method === 'GET' && !isset($uri_parts[1])) {
        $stmt = $conn->query("SELECT * FROM users");
        $users = $stmt->fetchAll(PDO::FETCH_ASSOC);
        echo json_encode($users);
    } elseif ($method === 'GET' && isset($uri_parts[1])) {
        $id = $uri_parts[1];
        $stmt = $conn->prepare("SELECT * FROM users WHERE id = :id");
        $stmt->bindParam(':id', $id);
        $stmt->execute();
        $user = $stmt->fetch(PDO::FETCH_ASSOC);
        echo json_encode($user);
    } elseif ($method === 'DELETE' && isset($uri_parts[1])) {
        $id = $uri_parts[1];
        $stmt = $conn->prepare("DELETE FROM users WHERE id = :id");
        $stmt->bindParam(':id', $id);
        $stmt->execute();
        echo json_encode(['message' => 'Usuario eliminado']);
    }
} else {
    http_response_code(404);
    echo json_encode(['message' => 'Ruta no encontrada']);
}
?>