using Wfc.Domains;
using Wfc.Domains.Workflows.Registrations;
using Wfc.Providers.LocalProviders;
using WfcExample.Core;
using WorkflowCore.Interface;

namespace WfcExample.Applications.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddWfc(config =>
        {
            config.AddLocalProviders();
            config.AddFlows(addWorkflow: true);
        });

        builder.Services.AddControllers();
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

        var host = app.Services.GetService<IWorkflowHost>();
        host.RegisterWorkflow<RegistrationWorkflow, RegistrationWorkflowModel>();
        host.Start();

        app.Run();
    }
}
