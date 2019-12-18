using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1
{
    public class Connector
    {
        public const string NameSpace = "PizzaDeliverySB"; // service bus name  

        public const string QueueName = "pizzadeliveryqueue"; // queue name  

        public const string key = "aSrZTUdftiIMhK4wq1TZf1gFJaGzjfwHq7v5oYWVZR8=";

        public static QueueClient OrdersQueueClient;

        public static NamespaceManager CreateNamespaceManager()
        {
            var uri = ServiceBusEnvironment.CreateServiceUri(
                "sb", NameSpace, String.Empty);

            var tP = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                "RootManageSharedAccessKey", key);

            return new NamespaceManager(uri, tP);
        }

        public static void Initialize()
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Http;

            var namespaceManager = CreateNamespaceManager();

            var messagingFactory = MessagingFactory.Create
                 (namespaceManager.Address, namespaceManager.Settings.TokenProvider);

            OrdersQueueClient = messagingFactory.CreateQueueClient(QueueName);
        }
    }
}
