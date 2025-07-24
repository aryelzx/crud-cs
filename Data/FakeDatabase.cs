using AlunosApi.Models;
using System.Text.Json;

/* 
O namespace é uma forma de organizar e agrupar o código em áreas lógicas. Ele ajuda a:
- Evitar conflitos entre nomes de classes com o mesmo nome.
- Organizar melhor o projeto (por funcionalidade, módulo, camada etc).
- Deixar o código mais modular e escalável.
 */

namespace AlunosApi.Data
{
    public static class FakeDatabase
    {
        private static readonly string filePath = "Data/alunos.json";

        public static List<Aluno> CarregarAlunos() // Método para carregar os alunos do arquivo JSON
        {
            if (!File.Exists(filePath))
            {
                return new List<Aluno>();  // Retorna uma lista vazia se o arquivo não existir

            }

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Aluno>>(json) ?? new List<Aluno>(); // Deserializa o JSON para uma lista de Alunos, ou retorna uma lista vazia se falhar
        }
        public static void SalvarAlunos(List<Aluno> alunos)
        {
            var json = JsonSerializer.Serialize(alunos, new JsonSerializerOptions { WriteIndented = true });    
            File.WriteAllText(filePath, json); // Serializa a lista de Alunos para JSON e salva no arquivo
        }
    }
}