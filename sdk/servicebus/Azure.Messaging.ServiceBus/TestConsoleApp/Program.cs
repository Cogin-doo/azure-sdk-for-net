using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Configuration;
using static System.Collections.Specialized.BitVector32;

namespace TestConsoleApp
{
	class Program
	{
		static async Task Main( string[] args )
		{
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            var secretProvider = config.Providers.First();
            secretProvider.TryGet("SbConnectionString", out var connectionString );

			var sbClient = new ServiceBusClient( connectionString );
			var sess = sbClient.CreateReceiver("session1");
			var allSessions = await sess.GetAllSessionsAsync();
		    foreach (var session in allSessions)
            {
			    Console.WriteLine(session);
			}
            Console.WriteLine("Total: " + allSessions.Count);

            //var queues = await adminClient.GetQueuesAsync().ToListAsync();
            //foreach( var queue in queues )
            //{
            //    Console.WriteLine(queue.Name);
            //}
            //            var subs = await adminClient.GetSubscriptionsAsync("t1");
            //            Console.WriteLine(queue.Name);
            //            Console.WriteLine(runtimeProps.TotalMessageCount);
        }
    }
}
