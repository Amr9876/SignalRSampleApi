using API.Hubs;
using Microsoft.AspNetCore.ResponseCompression;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new string[]
    {
        MediaTypeNames.Application.Octet
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapHub<ChatHub>("/chat");

app.Run();
