using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            _logger.LogInformation("request: /api/students");
            var students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                students.Add(new Student() { Id = i, FirstName = $"Student {i}", LastName = $"Name {i}" });
            }
            return Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            _logger.LogInformation("request: /api/students/{id}", id);
            return new Student() { Id = id, FirstName = $"Student {id}", LastName = $"Name {id}" };
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
