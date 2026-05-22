using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        Console.WriteLine("-------EJEMPLO LISTA--------");
        CasoList casoList = new CasoList();

        casoList.AgregarAlumno(new Alumno(1, "Ana Gómez", 8.5));
        casoList.AgregarAlumno(new Alumno(2, "Pedro Martínez", 6.2));
        casoList.AgregarAlumno(new Alumno(3, "Lucía Fernández", 9.1));

        foreach (var alu in casoList.ObtenerLista())
        {
            Console.WriteLine(alu);
        }

        Console.WriteLine("\n-> Buscando a 'Ana Gómez'...");
        Alumno encontrado = casoList.BuscarPorNombre("Ana Gómez");
        Console.WriteLine(encontrado != null ? $"Encontrado con éxito: {encontrado}" : "No existe");

        Console.WriteLine("\n-> Buscando a 'Carlos'...");
        Alumno noEncontrado = casoList.BuscarPorNombre("Carlos");
        Console.WriteLine(noEncontrado != null ? $"Encontrado: {noEncontrado}" : "No existe");

        Alumno aEliminar = casoList.BuscarPorNombre("Pedro Martínez");
        if (aEliminar != null) casoList.EliminarAlumno(aEliminar);

        Console.WriteLine("\nLista tras eliminar a Pedro:");
        foreach (var alu in casoList.ObtenerLista()) Console.WriteLine(alu);

        casoList.EliminarEnPosicion(0);

        Console.WriteLine("\nLista tras eliminar la primera posición (índice 0):");
        foreach (var alu in casoList.ObtenerLista()) Console.WriteLine(alu);
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Console.WriteLine("\n--------------- EJEMPLO DICCIONARIO ----------------");
        CasoDictionary casoDict = new CasoDictionary();


        casoDict.AgregarAlumno(new Alumno(10, "Javier López", 7.4));
        casoDict.AgregarAlumno(new Alumno(20, "Sonia Toledo", 8.9));
        casoDict.AgregarAlumno(new Alumno(30, "Marta Juárez", 6.5));

        foreach (var par in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave [ID]: {par.Key} -> {par.Value}");
        }

        Console.WriteLine("\n-> Buscando clave 20...");
        Alumno aluC = casoDict.BuscarPorId(20);
        Console.WriteLine(aluC != null ? $"Encontrado: {aluC}" : "No existe");

        Console.WriteLine("\n-> Buscando clave 999...");
        Alumno aluF = casoDict.BuscarPorId(999);
        Console.WriteLine(aluF != null ? $"Encontrado: {aluF}" : "No existe");


        casoDict.EliminarPorId(10);
        Console.WriteLine("\nDiccionario tras eliminar clave 10:");
        foreach (var par in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine(par.Value);
        }

    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("\n================ EJEMPLO LINQ ================");

        
        List<Libro> listaLibros = Libro.CrearLista();

        CasoLinq casoLinq = new CasoLinq(listaLibros);

        Console.WriteLine($"Primer libro: {listaLibros.FirstOrDefault()?.Titulo}");

        // 2. Último libro
        Console.WriteLine($"Último libro: {casoLinq.GetUltimo()?.Titulo}");

        // 3. Suma de precios
        Console.WriteLine($"Suma total de precios: {casoLinq.GetTotalPrecios():C}");

        // 4. Promedio de precios
        decimal promedio = casoLinq.GetPromedioPrecios();
        Console.WriteLine($"Promedio de precios: {promedio:C}");

        // 5. Libros con ID mayor a 15
        Console.WriteLine("\nLibros con ID > 15 (primeros 3 de la lista filtrada):");
        casoLinq.GetListById().Take(3).ToList().ForEach(l => Console.WriteLine($"- ID: {l.Id}: {l.Titulo}"));

        // 6. Lista formateada como String y Moneda
        Console.WriteLine("\nListado Formato Moneda (primeros 3 ejemplos):");
        casoLinq.GetLibros().Take(3).ToList().ForEach(s => Console.WriteLine(s));

        // 7 y 8. Extremos
        Console.WriteLine($"\nLibro con precio más alto: {casoLinq.GetMayorPrecio()?.Titulo} ({casoLinq.GetMayorPrecio()?.Precio:C})");
        Console.WriteLine($"Libro con precio más bajo: {casoLinq.GetMenorPrecio()?.Titulo} ({casoLinq.GetMenorPrecio()?.Precio:C})");

        // 9. Mayor al promedio
        Console.WriteLine($"\nLibros con precio mayor al promedio de {promedio:C} (mostrando 2 ejemplos):");
        casoLinq.GetMayorPromedio().Take(2).ToList().ForEach(l => Console.WriteLine($"- {l.Titulo} ({l.Precio:C})"));

        // 10. Ordenados por título descendente
        Console.WriteLine("\nTodos los libros ordenados desc. por título:");
        casoLinq.GetOrdenadosPorTitulo().ToList().ForEach(l => Console.WriteLine($"- {l.Titulo}"));
    }
}
