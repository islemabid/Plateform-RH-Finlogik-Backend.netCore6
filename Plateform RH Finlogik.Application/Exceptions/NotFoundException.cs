using System;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //nesta3mlouha wa9t for example , i  want to update something , but , mahiyech mawjouda 
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
        {
        }
    }
}
