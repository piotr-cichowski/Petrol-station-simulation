namespace PetrolStation;

public class Car
{
    private string? Plate;

    public Car(string? p)
    {
        Plate = p;
    }

    public string GetPlate()
    {
        return Plate;
    }
}
