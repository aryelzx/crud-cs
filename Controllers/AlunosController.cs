using Microsoft.AspNetCore.Mvc;
using AlunosApi.Models;
using AlunosApi.Data;

namespace AlunosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AlunosController : ControllerBase 
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var alunos = FakeDatabase.CarregarAlunos();
            return Ok(alunos); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = FakeDatabase.CarregarAlunos().FirstOrDefault(a => a.Id == id);
            return aluno != null ? Ok(aluno) : NotFound();
        }

        [HttpPost]
        public IActionResult Create(CreateAlunoInputDto aluno)
        {
            var alunos = FakeDatabase.CarregarAlunos();
            var novoAluno = new Aluno
            {
                Id = alunos.Any() ? alunos.Max(a => a.Id) + 1 : 1, 
                Nome = aluno.Nome,
                Curso = aluno.Curso
            };
            FakeDatabase.SalvarAlunos(alunos); 
            return CreatedAtAction(nameof(GetById), new { id = novoAluno.Id }, novoAluno); 
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Aluno alunoAtualizado)
        {
            var alunos = FakeDatabase.CarregarAlunos();
            var index = alunos.FindIndex(a => a.Id == id);

            if (index == -1)
                return NotFound();

            alunoAtualizado.Id = id; 
            alunos[index] = alunoAtualizado; 
            FakeDatabase.SalvarAlunos(alunos); 

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var alunos = FakeDatabase.CarregarAlunos(); 
            var aluno = alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
                return NotFound();


            alunos.Remove(aluno); 
            FakeDatabase.SalvarAlunos(alunos);

            return NoContent();
        }
    }
}