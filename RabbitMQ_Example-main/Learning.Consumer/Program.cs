using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

ConnectionFactory factory = new();
factory.Uri = new("amqp://guest:guest@localhost:5672");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();
channel.QueueDeclare(queue: "example-queue", exclusive: false);


EventingBasicConsumer consumer = new(channel);

channel.BasicConsume(queue: "example-queue", false, consumer);


consumer.Received += (sender, e) =>
{

    Console.WriteLine($"Kuyruk mesaj  byte verisi {Encoding.UTF8.GetString(e.Body.Span)}");

};

Console.Read();