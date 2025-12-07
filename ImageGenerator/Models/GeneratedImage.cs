namespace ImageGenerator.Models;

public class GeneratedImage
{
    public string? ImagePath { get; set; }
    public string? MainKeyword { get; set; }
    public List<string> Keywords { get; set; } = new();
    
    public string KeywordsText => string.Join(", ", Keywords);
}
