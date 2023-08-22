using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

ConnectionFactory factory = new();

factory.Uri = new("amqp://guest:guest@localhost:5672");


using IConnection connection = factory.CreateConnection();

using IModel channel = connection.CreateModel();

channel.QueueDeclare("example-queue",exclusive:false);

//byte[] message =  Encoding.UTF8.GetBytes("Merhaba");

//channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);
await Task.Delay(3000);
for (int i = 0; i < 100; i++)
{
    byte[] message = Encoding.UTF8.GetBytes("Merhaba " + i);

    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);
    await Task.Delay(1000);
}



Console.Read();
