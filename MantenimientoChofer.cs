using TMT_mantencion_chofer.Models;

namespace TMT_mantencion_chofer;

public class MantenimientoChofer
{

    public TransporteContext context;
    public List<Chofer> ListaChofer { get; set; }

    public MantenimientoChofer()
    {
        context = new TransporteContext();
        ListaChofer = new List<Chofer>();
    }

    public void AgregarDesdeArchivo(string rutaArchivo)
    {
        int contador = 0;
        var choferes = File.ReadAllLines(rutaArchivo);
        foreach (var chofer in choferes)
        {
            var datosChofer = chofer.Split(",");
            var choferExistente = context.Choferes.FirstOrDefault(x => x.Nombre == datosChofer[0] && x.Apellido == datosChofer[1]);
            if (choferExistente != null)
            {
                Console.WriteLine($"El chofer {datosChofer[0]} {datosChofer[1]} ya existe");
                continue;
            }
            else
            {
                Console.WriteLine($"Agregando chofer {datosChofer[0]} {datosChofer[1]}");
            }

            if (datosChofer.Length != 4)
            {
                Console.WriteLine($"Error al leer los datos del chofer {datosChofer[0]} {datosChofer[1]}");
                continue;
            }

            var nuevoChofer = new Chofer
            {
                Nombre = datosChofer[0],
                Apellido = datosChofer[1],
                Disponibilidad = bool.Parse(datosChofer[2]),
                Kilometros = int.Parse(datosChofer[3])
            };
            context.Choferes.Add(nuevoChofer);
            contador++;
        }
        context.SaveChanges();
        if (contador == 0)
        {
            Console.WriteLine("No se agregaron choferes");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }
        Console.WriteLine($"Se agregaron {contador} choferes correctamente");
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    public void ListarChoferes()
    {
        ListaChofer = context.Choferes.ToList();
        foreach (var chofer in ListaChofer)
        {
            string disponibilidad = chofer.Disponibilidad ? "Disponible" : "No Disponible";
            Console.WriteLine($"Id: {chofer.Id} - Nombre: {chofer.Nombre} {chofer.Apellido} - Disponibilidad: {disponibilidad} - Kilometros: {chofer.Kilometros}");
        }
        Console.WriteLine("¨Presione una tecla para continuar...");
        Console.ReadKey();
    }


    public void EliminarChofer(int id)
    {
        var chofer = context.Choferes.FirstOrDefault(x => x.Id == id);
        if (chofer != null)
        {
            Console.WriteLine($"Esta seguro que desea eliminar el chofer {chofer.Nombre} {chofer.Apellido}? (s/n)");
            var respuesta = Console.ReadLine();
            if (respuesta != null && respuesta.ToLower() == "s")
            {
                try
                {
                    context.Choferes.Remove(chofer);
                    context.SaveChanges();
                    Console.WriteLine("Chofer eliminado correctamente");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el chofer, verifique que no tenga viajes asociados");
                    Console.WriteLine(ex.Data);
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
        else
        {
            Console.WriteLine("Chofer no encontrado");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }

    public void ModificarChofer(int id)
    {
        var chofer = context.Choferes.FirstOrDefault(x => x.Id == id);
        if (chofer != null)
        {
            if (chofer.Disponibilidad == true)
            {
                Console.Write("Actualmente el chofer esta disponible, desea cambiar la disponibilidad? (s/n): ");
                var respuesta = Console.ReadLine();
                if (respuesta != null && respuesta.ToLower() == "s")
                {
                    chofer.Disponibilidad = false;
                    context.SaveChanges();
                    Console.WriteLine("Disponibilidad cambiada correctamente");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Write("Actualmente el chofer no esta disponible, desea cambiar la disponibilidad? (s/n): ");
                var respuesta = Console.ReadLine();
                if (respuesta != null && respuesta.ToLower() == "s")
                {
                    chofer.Disponibilidad = true;
                    context.SaveChanges();
                    Console.WriteLine("Disponibilidad cambiada correctamente");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
        else
        {
            Console.WriteLine("Chofer no encontrado");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
