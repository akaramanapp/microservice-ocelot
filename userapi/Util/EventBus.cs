using System.Text;
using RabbitMQ.Client;

public class EventBus: IEventBus {

    public void SendEmailEvent(string email){
        var factory = new ConnectionFactory() { HostName = "192.168.1.38" }; // IP global config'den alınacak
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "NewUserEvent",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string userMail = email;
                var body = Encoding.UTF8.GetBytes(userMail);

                channel.BasicPublish(exchange: "",
                                     routingKey: "NewUserEvent",
                                     basicProperties: null,
                                     body: body);
            }
    }
}