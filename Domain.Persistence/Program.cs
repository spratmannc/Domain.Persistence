using Domain.Persistence.Entities;
using Domain.Persistence.Events;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Domain.Persistence
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server { MachineName = "01-MMD93" };

            var db = new EventStoreDb();

            var e = db.Events.FirstOrDefault();

            ServerEventProcessor processor = new ServerEventProcessor();

            processor.Handle(server, new[] { e.Event });

            Console.WriteLine($"{server.MachineName} is active: {server.Active}");
        }

        private static ActivationChangedEvent AddAndSaveEvent()
        {
            var evt = new ActivationChangedEvent { Active = true };

            var db = new EventStoreDb();

            var wrapper = new EventEntity(evt);

            db.Events.Add(wrapper);
            db.SaveChanges();

            Console.WriteLine($"Save complete.  New Id = {wrapper.Id}");
            return evt;
        }
    }
}
