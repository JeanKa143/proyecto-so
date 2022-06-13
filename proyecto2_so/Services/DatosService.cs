using proyecto2_so.Classes;

namespace proyecto2_so.Services;

public class DatosService
{
    private List<Idioma> idiomas = new List<Idioma>();

    private bool ExisteIdioma(string nombreIdioma) => idiomas.Any(idioma => idioma.nombre == nombreIdioma);

    private Idioma ObtenerIdioma(string nombreIdioma) => idiomas.Find(x => x.nombre.ToLower() == nombreIdioma.ToLower());

    public void AgregarAnimal(string nombreIdioma, Animal animal)
    {
        if (!ExisteIdioma(nombreIdioma))
        {
            idiomas.Add(new Idioma { nombre = nombreIdioma });
        }

        var idioma = idiomas.Find(x => x.nombre == nombreIdioma);
        idioma.AgregarAnimal(animal);
    }

    public void AgregarAnimales(string nombreIdioma, IEnumerable<Animal> animales)
    {
        foreach (var animal in animales)
        {
            AgregarAnimal(nombreIdioma, animal);
        }
    }

    public Animal ObtenerAnimalPorId(string nombreIdioma, int animalId)
    {
        var idioma = ObtenerIdioma(nombreIdioma);
        return idioma != null ? idioma.ObtenerAnimalPorId(animalId) : null;
    }

    public Animal ObtenerAnimalPorNombre(string nombreIdioma, string nombreAnimal)
    {
        var idioma = ObtenerIdioma(nombreIdioma);
        return idioma != null ? idioma.ObtenerAnimalPorNombre(nombreAnimal) : null;
    }
}
