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
        var choferes = File.ReadAllLines(rutaArchivo);
        foreach (var chofer in choferes)
        {
            var datosChofer = chofer.Split(",");
            var nuevoChofer = new Chofer
            {
                Nombre = datosChofer[0],
                Apellido = datosChofer[1],
                Disponibilidad = bool.Parse(datosChofer[2]),
                Kilometros = int.Parse(datosChofer[3])
            };
            context.Choferes.Add(nuevoChofer);
        }

        context.SaveChanges();
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
            Console.WriteLine("Esta seguro que desea eliminar el chofer? (s/n)");
            var respuesta = Console.ReadLine();
            if (respuesta != null && respuesta.ToLower() == "s")
            {
                try{
                    context.Choferes.Remove(chofer);
                    context.SaveChanges();
                    Console.WriteLine("Chofer eliminado correctamente");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
                catch(Exception ex){
                    Console.WriteLine("Error al eliminar el chofer, verifique que no tenga viajes asociados");
                    Console.WriteLine(ex.Message);
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
