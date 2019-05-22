using RabbitMQApp.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Messages mgs = new Messages();
            mgs.CreateMessage_Success();

            mgs.RetrieveMessage_Success();

        }
    }
}
