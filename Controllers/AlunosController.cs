using Microsoft.AspNetCore.Mvc; // For API controllers
using AlunosApi.Models;
using AlunosApi.Data;

namespace AlunosApi.Controllers
{
    [ApiController] // Define this class as an API controller
    [Route("api/[controller]")] // Route for the controller
    public class AlunosController : ControllerBase // Controller for handling Alunos
    {
        [HttpGet]
        public IActionResult GetAll() // IActionResult = ActionResult for API responses
        {
            var alunos = FakeDatabase.CarregarAlunos();
            return Ok(alunos); // Return all alunos with a 200 OK status
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = FakeDatabase.CarregarAlunos().FirstOrDefault(a => a.Id == id);
            return aluno != null ? Ok(aluno) : NotFound(); // Return aluno by ID or 404 if not found
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            var alunos = FakeDatabase.CarregarAlunos();
            aluno.Id = alunos.Any() ? alunos.Max(a => a.Id) + 1 : 1; // Generate new ID
            alunos.Add(aluno);
            FakeDatabase.SalvarAlunos(alunos); // Save updated list to database
            return  CreatedAtAction(nameof(GetById), new { id = aluno.Id}, aluno); // Return 201 Created with the new aluno
        }
    }
}