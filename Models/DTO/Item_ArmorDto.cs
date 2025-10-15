public class ArmorDto : ItemDto
{
    public int ArmorValue { get; set; }
    public int Initative { get; set; }
    public List<string>? Resistances { get; set; }
    public List<string>? Penalties { get; set; }
    public List<string>? Effects { get; set; }
}