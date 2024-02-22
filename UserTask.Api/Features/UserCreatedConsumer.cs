using Masstransit.Shared;
using MassTransit;
using System.Text.Json;

namespace UserTask.Api.Features
{
    public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
    {
        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

            Console.WriteLine($"NotificationCreated event consumed. Message: {serializedMessage}");

            await Task.CompletedTask;
        }
    }
}