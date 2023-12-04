using Domain.Entities;
using MediatR;
using System.Text.Json;

namespace Application.Notifications
{
    public class ProductCreateNotification : INotification
    {
        public Product Product { get; set; }
    }

    public class ProductCreateNotificationHandler : INotificationHandler<ProductCreateNotification>
    {
        public Task Handle(ProductCreateNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Shu maxsulot qo'shildida qara:" + JsonSerializer.Serialize(notification.Product));

            return Task.CompletedTask;
        }
    }
}
