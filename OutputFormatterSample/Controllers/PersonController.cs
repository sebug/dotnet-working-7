using Microsoft.AspNetCore.Mvc;
using GenFu;

namespace OutputFormatterSample.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<Person> Get()
    {
        var people = A.ListOf<Person>();

        return people;
    }
}