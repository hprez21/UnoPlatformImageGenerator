using ImageGenerator.Models;

namespace ImageGenerator.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public string? Title { get; }
    public string Greeting => "Hello there,";
    public string UserName => "Héctor";
    
    private readonly IImmutableList<Profile> _profiles = new List<Profile>
    {
        new Profile
        {
            Name = "Héctor",
            ProfileImage = "ms-appx:///Assets/profile1.jpg",
            NoPhotos = 12
        },
        new Profile
        {
            Name = "Maddy",
            ProfileImage = "ms-appx:///Assets/profile2.jpg",
            NoPhotos = 5
        },
        new Profile
        {
            Name = "Henry",
            ProfileImage = "ms-appx:///Assets/profile3.jpg",
            NoPhotos = 25
        },
    }.ToImmutableList();
    
    private readonly IImmutableList<GeneratedImage> _generatedImages = new List<GeneratedImage>
    {
        new GeneratedImage
        {
            ImagePath = "ms-appx:///Assets/dashboard1.jpg",
            MainKeyword = "Castle",
            Keywords = new List<string>{
                "Epic", "hill", "mountain", "trees", "blue sky"
            }
        },
        new GeneratedImage
        {
            ImagePath = "ms-appx:///Assets/dashboard2.jpg",
            MainKeyword = "Mountains",
            Keywords = new List<string>{
                "Landscape", "photorealistic", "dawn", "mountains", "moon"
            }
        },
        new GeneratedImage
        {
            ImagePath = "ms-appx:///Assets/dashboard3.jpg",
            MainKeyword = "Robot",
            Keywords = new List<string>{
                "AI", "robotic", "human", "light", "metal"
            }
        },
    }.ToImmutableList();
    
    public IListState<Profile> Profiles => ListState.Value(this, () => _profiles);
    public IListState<GeneratedImage> GeneratedImages => ListState.Value(this, () => _generatedImages);

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

    public async Task CreateNew()
    {
        await _navigator.NavigateViewModelAsync<SecondModel>(this);
    }
}
