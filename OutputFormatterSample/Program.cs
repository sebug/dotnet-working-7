using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;
using OutputFormatterSample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddMvcOptions(options => {
    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
    options.OutputFormatters.Add(new VcardOutputFormatter());

    options.FormatterMappings.SetMediaTypeMappingForFormat(
        "xml", "application/xml"
    );
    options.FormatterMappings.SetMediaTypeMappingForFormat(
        "vcard", "text/vcard"
    );
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
