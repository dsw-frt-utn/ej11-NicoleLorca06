using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{
    private Dictionary<int, Alumno> diccionarioAlumno= new Dictionary<int, Alumno>();

    public void AgregarAlumno (Alumno alumno)
    {
        if (!diccionarioAlumno.ContainsKey(alumno.Id))
        {
            diccionarioAlumno.Add(alumno.Id, alumno);
        }
    }

    public Alumno BuscarPorId(int id)
    {
        if (diccionarioAlumno.TryGetValue(id, out Alumno alumno))
        {
            return alumno;
        }
        return null;
    }

    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        return diccionarioAlumno;
    }

    public bool EliminarPorId(int id)
    {
        return diccionarioAlumno.Remove(id);
    }
}
