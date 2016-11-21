using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CorporateWebsite.Application.Rabbit
{
    /// <summary>
    /// Rabbit业务队列
    /// </summary>
    public class RabbitManage
    {
        /// <summary>
        /// 业务一
        /// </summary>
        public void BussniessOne()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "caixiao";
            factory.Password = "123456";
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    string message = "Hello World";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello", null, body);
                    Console.WriteLine(" set {0}", message);
                }
            }
        }
    }
}
