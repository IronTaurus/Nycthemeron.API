public class InventoryDto
{
    public int Id { get; set; }

    public List<ItemDto> Items { get; set; } = new();

    public int? MainHandId { get; set; }
    public int? OffHandId { get; set; }
    public int? EquippedArmorId { get; set; }
}