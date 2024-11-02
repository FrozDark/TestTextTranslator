using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TestTextTranslator;
using TestTextTranslator.gRPCServices;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });
    options.Listen(IPAddress.Loopback, 5002, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=cacheapp.db"))
    .AddStackExchangeRedisCache(options => {
        options.Configuration = "localhost";
        options.InstanceName = "local";
    })
    .AddGrpc();

var app = builder.Build();

app.MapGrpcService<TranslatorgRPCService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
