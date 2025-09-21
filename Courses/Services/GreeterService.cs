using Grpc.Core;
using Courses;

namespace Courses.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        if (request.Name == "Slim Shady")
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Will the REAL Slim Shady please stand up?"
            });
        }
        
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}