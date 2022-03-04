using System;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
    public class BadRequestException: ApplicationException
    {
        //nesta3mlouha wa9t par example il input null 
        public BadRequestException(string message): base(message)
        {

        }
    }
}
