namespace PetrolStation;

public abstract class Product
{
    protected float Price;
    protected string ReceiptName;
    
    public Product() {}

    public Product(float pr, string name)
    {
        Price = pr;
        ReceiptName = name;
    }
    
    public virtual float GetPrice()
    {
        return Price;
    }

    public string GetName()
    {
        return ReceiptName;
    }
}
