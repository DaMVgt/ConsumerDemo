using System.Text;
using System.Text.Json;
using ProducerDemo.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class program
{
    public static void Main(string[] args)
    {
        IConnection conexion = null;
        IModel channel = null;
        var connectionFactory = new ConnectionFactory();
        connectionFactory.Port = 5672;
        connectionFactory.UserName = "guest";
        connectionFactory.Password = "guest";
        conexion = connectionFactory.CreateConnection();
        channel = conexion.CreateModel();
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += ConsumerReceived;
        var consumerTag = channel.BasicConsume("queue-demo", true, consumer);

        Console.WriteLine("Mensaje leido correctamente de la cola, presione una tecla para finalizar...");
        Console.ReadLine();
    }

    private static void ConsumerReceived(object? sender, BasicDeliverEventArgs e)
    {
        string message = Encoding.UTF8.GetString(e.Body.ToArray());
        Aspirante objeto = JsonSerializer.Deserialize<Aspirante>(message);
        Console.WriteLine($"Objeto: {objeto.Apellidos} {objeto.Nombres}");
        Console.WriteLine($"Mensaje recibido {message}");
    }
}