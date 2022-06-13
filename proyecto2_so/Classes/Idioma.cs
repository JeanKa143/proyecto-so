namespace proyecto2_so.Classes;

public class Idioma
{
    public string nombre { get; set; }

    private List<Animal> animales = new List<Animal>();

    public void AgregarAnimal(Animal animal) => animales.Add(animal);

    public Animal ObtenerAnimalPorId(int animalId) => animales.Find(x => x.Id == animalId);

    public Animal ObtenerAnimalPorNombre(string nombreAnimal) =>
        animales.Find(x => x.Nombre.ToLower() == nombreAnimal.ToLower());
}
