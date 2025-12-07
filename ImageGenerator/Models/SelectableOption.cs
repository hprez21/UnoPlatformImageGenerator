namespace ImageGenerator.Models;

public partial record SelectableOption
{
    public string Name { get; init; } = string.Empty;
    public bool IsSelected { get; init; } = false;
}
