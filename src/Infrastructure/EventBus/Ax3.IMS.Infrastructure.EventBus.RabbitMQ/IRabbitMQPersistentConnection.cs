using RabbitMQ.Client;
using System;

namespace Ax3.IMS.Infrastructure.EventBus.RabbitMQ
{
    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}