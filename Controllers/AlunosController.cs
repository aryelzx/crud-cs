using Microsoft.AspNetCore.Mvc;

[ApiController] //definindo que a classe é um controlador de API
[Route("api/[controller]")] //rota base para o controlador
public class Teste : ControllerBase
{
    [HttpGet] //método para obter dados
    public IActionResult Get()
    {
        return Ok("Funcionando!");
    }

}