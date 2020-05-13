using System;

namespace LojaVirtual.Domain.Interfaces.Services
{
    public interface IMessageBrokerService
    {
        void sendMessage(string queue, object body);
        void CreateConnection();
        void CloseConnection();
        void receiveMessage(string queue, Action<ReadOnlyMemory<byte>> action);
        void ReQueue();
        void FinalizaQueue();
    }
}
