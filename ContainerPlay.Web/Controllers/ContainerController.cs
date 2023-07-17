using ContainerPlay.Abstract;
using ContainerPlay.Web.Infrastructure;
using ContainerPlay.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContainerPlay.Web.Controllers;

[ApiController]
[Route("api/container")]
public class ContainerController : ControllerBase
{
    private readonly ILogger<ContainerController> _logger;
    private readonly ApplicationSettings _applicationSettings;
    private readonly IContainerRuntime _containerRuntime;

    public ContainerController(
        ILogger<ContainerController> logger,
        ApplicationSettings applicationSettings,
        IContainerRuntime containerRuntime)
    {
        _logger = logger;
        _applicationSettings = applicationSettings;
        _containerRuntime = containerRuntime;
    }

    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAll()
    {
        if (!EnsureAccessSecretToken())
            return Forbid();

        try
        {
            var containers = await _containerRuntime.GetAll();

            var responseData = containers.Select(x => new GetContainerResponse
            {
                Name = x.Name,
                Image = x.Image,
                IsRunning = x.IsRunning,
                RuntimeType = x.RuntimeType.ToString()
            });
            return Ok(responseData);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(ContainerController)}: Problems with handling.");
            return BadRequest(new { e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContainerCreateRequest model)
    {
        if (!EnsureAccessSecretToken())
            return Forbid();

        try
        {
            if (model == null)
                throw new Exception("Empty model.");

            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("Empty Name.");

            if (string.IsNullOrWhiteSpace(model.Image))
                throw new Exception("Empty Image.");

            if (model.Ports == null || model.Ports.Length == 0 || model.Ports.Length != new HashSet<int>(model.Ports).Count)
                throw new Exception("Empty or duplicated Ports.");

            if (model.RuntimeType == 0)
                throw new Exception("Empty RuntimeType.");

            await _containerRuntime.CreateContainer(model.Name, model.Image, model.Ports, model.RuntimeType);

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(ContainerController)}: Problems with handling.");
            return BadRequest(new { e.Message });
        }
    }

    [HttpDelete]
    [Route("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        if (!EnsureAccessSecretToken())
            return Forbid();

        try
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Empty name.");

            await _containerRuntime.DeleteContainer(name);

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(ContainerController)}: Problems with handling.");
            return BadRequest(new { e.Message });
        }
    }

    [HttpPut]
    [Route("start/{name}")]
    public async Task<IActionResult> Start(string name)
    {
        if (!EnsureAccessSecretToken())
            return Forbid();

        try
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Empty name.");

            await _containerRuntime.StartContainer(name);

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(ContainerController)}: Problems with handling.");
            return BadRequest(new { e.Message });
        }
    }

    [HttpPut]
    [Route("stop/{name}")]
    public async Task<IActionResult> Stop(string name)
    {
        if (!EnsureAccessSecretToken())
            return Forbid();

        try
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Empty name.");

            await _containerRuntime.StopContainer(name);

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(ContainerController)}: Problems with handling.");
            return BadRequest(new { e.Message });
        }
    }

    private bool EnsureAccessSecretToken()
    {
        if (string.IsNullOrEmpty(_applicationSettings.AccessSecretToken))
        {
            _logger.LogError($"{nameof(ContainerController)}: Empty AccessSecretToken.");
            throw new Exception("Empty AccessSecretToken.");
        }

        if (!Request.Headers.ContainsKey("X-Access-Secret-Token") ||
            Request.Headers["X-Access-Secret-Token"].FirstOrDefault() != _applicationSettings.AccessSecretToken)
        {
            _logger.LogError($"{nameof(ContainerController)}: Invalid data access secret token.");
            return false;
        }

        return true;
    }
}
