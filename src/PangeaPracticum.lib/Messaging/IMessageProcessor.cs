using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PangeaPracticum.lib.Messaging
{
    public interface IBusMessageProcessor<T>
    {
        void Process(T msg);
    }

    public interface IBusPublisher
    {
        void Publish<T>(T message);
    }

    public class BusPublisherService: IBusPublisher
    {
        private IBusClient _bus;

        public BusPublisherService(IBusClient bus)
        {
            _bus = bus;
        }

        public void Publish<T>(T message)
        {
            _bus.PublishAsync<T>(message);
        }
    }
}
