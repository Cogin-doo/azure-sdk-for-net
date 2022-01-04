using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace TestConsoleApp
{
	class Program
	{
		static async Task Main( string[] args )
		{
			var sbClient = new ServiceBusClient(@"Endpoint = sb://cogin-test-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=JTqcVcaXC0SlkdAlpaIVOC+QaLN290141cktoEJeJx0=" );
			var sess = sbClient.CreateReceiver("session1");
			var allSessions = await sess.GetAllSessionsAsync();
		    foreach (var session in allSessions)
			{
			    Console.WriteLine(session);
			}
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
