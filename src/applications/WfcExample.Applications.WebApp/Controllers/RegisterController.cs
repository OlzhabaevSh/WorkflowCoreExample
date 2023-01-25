using Microsoft.AspNetCore.Mvc;
using WfcExample.Core.Domains;

namespace WfcExample.Applications.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly RegistrationDomain domain;

    public RegisterController(RegistrationDomain domain)
    {
        this.domain = domain;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> SendRequestToRegister([FromBody] SendRequestToRegisterModel model) 
    {
        var processId = await this.domain.CreateUser(model.Login, model.Password);

        return Ok(new { ProcessId = processId });
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> SendCode([FromBody] SendCodeModel model)
    {
        var actionId = await this.domain.SendCode(model.Login, model.Code);

        return Ok(new { ActionId = actionId });
    }
}

public class SendRequestToRegisterModel 
{
    public string Login { get; set; }

    public string Password { get; set; }
}

public class SendCodeModel 
{
    public string Login { get; set; }

    public string Code { get; set; }
}
