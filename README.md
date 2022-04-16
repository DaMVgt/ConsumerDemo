# ConsumerDemo
Aplicativo para leer mensajes en espera en una cola enviada por el aplicativo [Producer Demo](https://github.com/DaMVgt/ProducerDemo) administrado por la herramienta RabbitMQ. Ejercicio realizado en la carrera FullStack .NET en Fundación Kinal.

> Se recomienda leer antes el documento [Producer Demo](https://github.com/DaMVgt/ProducerDemo) para realizar las configuraciones necesarias.

## Código
- Creación de metodo para poder imprimir los mensajes enviados por el [Producer Demo](https://github.com/DaMVgt/ProducerDemo), conviertiendo el menssaje de tipo JSON a string
```C#
    private static void ConsumerReceived(object? sender, BasicDeliverEventArgs e)
    {
        string message = Encoding.UTF8.GetString(e.Body.ToArray());
        Aspirante objeto = JsonSerializer.Deserialize<Aspirante>(message);
        Console.WriteLine($"Objeto: {objeto.Apellidos} {objeto.Nombres}");
        Console.WriteLine($"Mensaje recibido {message}");
    }
```
