namespace TMT_mantencion_chofer;

public class MantenimientoChofer
{

    public TransporteContext context;
    public List<Chofer> ListaChofer { get; set; }

    public MantenimientoChofer()
    {
        context = new TransporteContext();
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
                IdBus = null
            };
            if(datosChofer[3] == "" || datosChofer[3] == null){
                nuevoChofer.IdBus = int.Parse(datosChofer[3]);
            }
            context.Chofers.Add(nuevoChofer);
        }
        context.SaveChanges();
    }

    public void ListarChoferes()
    {
        ListaChofer = context.Chofers.ToList();
        foreach (var chofer in ListaChofer)
        {
            Console.WriteLine($"Nombre: {chofer.Nombre} {chofer.Apellido}");
            string disponibilidad = chofer.Disponibilidad ? "Disponible" : "No Disponible";
            Console.WriteLine($"Disponibilidad: {disponibilidad}");
            Console.WriteLine($"Id Bus: {chofer.IdBus}");
            Console.WriteLine();
        }
        Console.WriteLine("¨Presione una tecla para continuar...");
        Console.ReadKey();
    }


    public void EliminarChofer(int id)
    {
        var chofer = context.Chofers.FirstOrDefault(x => x.Id == id);
        if (chofer != null)
        {
            Console.WriteLine("Esta seguro que desea eliminar el chofer? (s/n)");
            var respuesta = Console.ReadLine();
            if (respuesta.ToLower() == "s")
            {
                context.Chofers.Remove(chofer);
                context.SaveChanges();
                Console.WriteLine("Chofer eliminado correctamente");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
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
        var chofer = context.Chofers.FirstOrDefault(x => x.Id == id);
        if (chofer != null)
        {
            if (chofer.Disponibilidad == true)
            {
                Console.Write("Actualmente el chofer esta disponible, desea cambiar la disponibilidad? (s/n): ");
                var respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "s")
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
                if (respuesta.ToLower() == "s")
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
