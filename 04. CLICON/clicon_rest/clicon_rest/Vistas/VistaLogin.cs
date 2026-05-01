using ec.edu.monster.Controladores;

namespace ec.edu.monster.Cliente.Vistas;

public class VistaLogin
{
    private readonly ControladorAplicacion _controlador;

    public VistaLogin(ControladorAplicacion controlador)
    {
        _controlador = controlador;
    }

    public async Task IniciarAsync()
    {
        MensajeBienvenida();
        Console.WriteLine("=== SISTEMA DE CONVERSIÓN DE UNIDADES - .NET REST ===");

        while (true)
        {
            Console.Write("\nUsuario: ");
            string usuario = Console.ReadLine() ?? "";

            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine() ?? "";

            try
            {
                await _controlador.AutenticarAsync(usuario, contrasena);
                Console.WriteLine("Inicio de sesión exitoso. Token guardado.");

                var vistaConversion = new VistaConversion(_controlador);
                await vistaConversion.EjecutarMenuAsync();

                _controlador.CerrarSesion();
                Console.WriteLine("Sesión finalizada de forma segura.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }

    private void MensajeBienvenida()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        string mensaje = @"
╔────────────────────────────────────────────────────────────╗
│    ____            _   _       _     ____  ____  ____      │
│   / ___|___  _ __ | | | |_ __ (_)   / ___||  _ \| ___|     │
│  | |   / _ \| '_ \| | | | '_ \| |  | |  _ | |_) |___ \     │
│  | |__| (_) | | | | |_| | | | | |  | |_| ||  _ < ___) |    │
│   \____\___/|_| |_|\___/|_| |_|_|   \____||_| \_\____/     │
╚────────────────────────────────────────────────────────────╝";
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
}