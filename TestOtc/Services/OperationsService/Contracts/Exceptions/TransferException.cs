using System;
using System.Collections.Generic;

namespace OperationsService.Contracts.Exceptions
{
    public class TransferException: Exception
    {
        public readonly IEnumerable<string> Messages;

        public TransferException(IEnumerable<string> messages)
        {
            Messages = messages;
        }

        public TransferException(string message): base(message)
        {
            Messages = new List<string> { message };
        }
    }
}
