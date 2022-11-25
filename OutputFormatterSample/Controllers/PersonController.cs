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
    public ActionResult<List<Person>> Get()
    {
        var people = A.ListOf<Person>();

        return people;
    }

    [HttpPost]
    public IEnumerable<Person> Post([ModelBinder(binderType: typeof(PersonsCsvBinder))]
    IEnumerable<Person> persons)
    {
        return persons;
    }
}