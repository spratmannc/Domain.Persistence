using Domain.Persistence.Entities;
using Domain.Persistence.Events;
using System.Collections.Generic;

namespace Domain.Persistence
{

    // with mediator, this could listen for events too (?)
    public class ServerEventProcessor
    {
        public void Handle(Server server, IEnumerable<IEvent> events)
        {
            foreach (var evt in events)
            {
                // do it
                switch (evt)
                {
                    case ActivationChangedEvent activation:
                        server.Active = activation.Active;
                        break;

                    default:
                        break;
                }

                // update the entity

                // persist the result
                
                // using mediatr, trigger the update of customer level events
            }
        }
    }
}
