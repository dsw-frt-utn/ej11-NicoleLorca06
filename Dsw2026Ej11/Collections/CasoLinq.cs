using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */
public class CasoLinq
{
    private List<Libro> libros;
    public CasoLinq(List<Libro> listaLibros)
    {
        libros = listaLibros;
    }
    public Libro? GetPrimero()
    {
        return libros.FirstOrDefault();
    }
    public Libro? GetUltimo()
    {
        return libros.LastOrDefault();
    }
    public decimal GetTotalPrecios()
    {
        return libros.Sum(libro => libro.Precio);
    }
    public decimal GetPromedioPrecios()
    {
        return libros.Average(libro => libro.Precio);
    }
    public List<Libro> GetListById()
    {
        return libros
                .Where(libro => libro.Id > 15)
                .ToList();
    }
    public List<string> GetLibros()
    {
        return libros
               .Select(libro => $"{libro.Titulo}-{libro.Precio:c}")
               .ToList();
    }
    public Libro? GetMayorPrecio()
    {
        return libros
               .OrderByDescending(libro => libro.Precio)
               .FirstOrDefault();
    }
    public Libro? GetMenorPrecio()
    {
        return libros
               .OrderBy(libro => libro.Precio)
               .FirstOrDefault();
    }
    public List<Libro> GetMayorPromedio()
    {
        decimal promedio = libros.Average(libro => libro.Precio);
        return libros
               .Where(libro => libro.Precio > promedio)
               .ToList();

    }
    public List<Libro> GetOrdenadosPorTitulo()
    {
        return libros
            .OrderByDescending(libro => libro.Titulo)
            .ToList();
    }

}
