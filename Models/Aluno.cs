namespace AlunosApi.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Curso { get; set; } = "";
    }

    public class CreateAlunoInputDto
    {
        public string Nome { get; set; } = "";
        public string Curso { get; set; } = "";
    }
}