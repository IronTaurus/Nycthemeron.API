namespace Nycthemeron.API.Models;
public class Container : Item
{
    public List<Item>? ContainingItems { get; set; } = new();
    public bool Equipped { get; set; } = false;
}