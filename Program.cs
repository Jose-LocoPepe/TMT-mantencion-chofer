using TMT_mantencion_chofer;

var mantenimientoChofer = new MantenimientoChofer();
var opcion = 0;
while (true)
{
    Console.Clear();
    Console.WriteLine("Mantenimiento de Choferes");
    Console.WriteLine("1.- Agregar Choferes desde archivo");
    Console.WriteLine("2.- Listar Choferes");
    Console.WriteLine("3.- Eliminar Chofer");
    Console.WriteLine("4.- Modificar Chofer");
    Console.WriteLine("5.- Salir");
    Console.WriteLine("Ingrese una opcion:");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese la ruta del archivo:");
            var rutaArchivo = Console.ReadLine();
            try
            {
                mantenimientoChofer.AgregarDesdeArchivo(rutaArchivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar choferes: {ex.Message}");
            }
            break;
        case 2:
            mantenimientoChofer.ListarChoferes();
            break;
        case 3:
            Console.WriteLine("Ingrese el id del chofer a eliminar:");
            var id = int.Parse(Console.ReadLine());
            mantenimientoChofer.EliminarChofer(id);
            break;
        case 4:

            Console.WriteLine("Ingrese el id del chofer a modificar:");
            var idChofer = int.Parse(Console.ReadLine());
            mantenimientoChofer.ModificarChofer(idChofer);
            break;
        case 5:
            Console.WriteLine("Saliendo del programa...");
            return;
        default:
            Console.WriteLine("Opcion no valida");
            break;
    }
}
