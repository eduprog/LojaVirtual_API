using LojaVirtual.Domain.Commands.Order.FinishOrder;
using LojaVirtual.Domain.Commands.Order.ProcessOrder;
using LojaVirtual.Domain.Interfaces.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace LojaVirtual.WorkerApp
{
    public class App
    {
        private readonly IConfiguration _config;
        private readonly IMessageBrokerService messageBrokerService;
        private readonly IMediator mediator;

        public App(
            IConfiguration config, 
            IMessageBrokerService messageBrokerService,
            IMediator mediator
        )
        {
            _config = config;
            this.messageBrokerService = messageBrokerService;
            this.mediator = mediator;
        }

        public void Run()
        {
            this.messageBrokerService.CreateConnection();
                
            this.messageBrokerService.receiveMessage("orderProcessing", async (ReadOnlyMemory<byte> body) => {

                //try
                //{
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    var order = System.Text.Json.JsonSerializer.Deserialize<FinishOrderRequest>(message);

                    var request = new ProcessOrderRequest(order.UserId, order.ReferenceDiscount, order.Items);
                    var response = await mediator.Send(request, CancellationToken.None);

                    //if (response.Success == false)
                    //{
                    //    throw new Exception(response.Message);
                    //}
                //}
                //catch (Exception)
                //{
                //    throw;
                //}
            });

            Console.WriteLine("Aguardando para executar a fila");

            Console.ReadKey();

            this.messageBrokerService.CloseConnection();
        }


    }
}
