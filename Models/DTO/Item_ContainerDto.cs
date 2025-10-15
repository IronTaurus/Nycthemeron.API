public class ContainerDto : ItemDto
{
    public List<ItemDto>? ContainedItems { get; set; } = new();
}