﻿using LojaVirtual.Domain.Interfaces.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace LojaVirtual.Infra.Services
{
    public class RabbitMqService : IMessageBrokerService
    {
        private IModel channel;
        private IConnection connection;
        private BasicDeliverEventArgs ea;

        public void CreateConnection()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }

        public void CloseConnection()
        {
            this.channel.Close();
            this.connection.Close();
        }

        public void sendMessage(string queue, object body)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(body);
                var bodySended = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queue,
                                     basicProperties: null,
                                     body: bodySended);
            }
        }

        public void ReQueue()
        {
            this.channel.BasicNack(this.ea.DeliveryTag, false, true);
        }

        public void FinalizaQueue()
        {
            this.channel.BasicNack(this.ea.DeliveryTag, false, false);
        }

        public void receiveMessage(string queue, Action<ReadOnlyMemory<byte>> action)
        {
            this.channel.QueueDeclare(queue: queue,
                                             durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    this.ea = ea;
                    action(ea.Body);
                }
                catch (Exception)
                {
                    this.ReQueue();
                }
                finally
                {
                    this.FinalizaQueue();
                }
            };
            this.channel.BasicConsume(queue: queue,
                                 autoAck: false,
                                 consumer: consumer);
        }
    }
}
