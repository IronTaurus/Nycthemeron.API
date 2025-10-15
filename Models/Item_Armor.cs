namespace Nycthemeron.API.Models;
public class Armor : Item
{
    public int ArmorValue { get; set; }
    public int Initative { get; set; }
    public List<string>? Resistances { get; set; }
    public List<string>? Penalties { get; set; }
    public List<string>? Effects { get; set; }
}
