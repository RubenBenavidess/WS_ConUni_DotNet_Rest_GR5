using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WS_ConUni_DotNet_Rest_GR5.Seguridad;

namespace WS_ConUni_DotNet_Rest_GR5.Controladores;

[ApiController]
[Route("api/seguridad")]
public class SeguridadController : ControllerBase
{
    private readonly ServicioAutenticacion _servicioAutenticacion;

    public SeguridadController(ServicioAutenticacion servicioAutenticacion)
    {
        _servicioAutenticacion = servicioAutenticacion;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
    {
        var token = _servicioAutenticacion.Autenticar(request.Usuario, request.Contrasena);
        if (token is null)
        {
            return Unauthorized("Credenciales inválidas");
        }

        return Ok(new LoginResponse { Token = token });
    }

    [Authorize(AuthenticationSchemes = "BearerToken")]
    [HttpPost("cambiar-contrasena")]
    public IActionResult CambiarContrasena([FromBody] CambiarContrasenaRequest request)
    {
        var cambioExitoso = _servicioAutenticacion.CambiarContrasena(request.ContrasenaActual, request.NuevaContrasena);
        if (!cambioExitoso)
        {
            return BadRequest("No se pudo cambiar la contraseña");
        }

        return Ok("Contraseña actualizada");
    }
}
