using ImageGenerator.Models;

namespace ImageGenerator.Presentation;

public partial record SecondModel
{
    private readonly INavigator _navigator;
    
    public SecondModel(INavigator navigator)
    {
        _navigator = navigator;
    }
    
    public string PageTitle => "Select Options";
    public string Subtitle => "Minimum of 6 options";
    public string StylesTitle => "Choose a style of picture";
    
    private readonly IImmutableList<SelectableOption> _options = new List<SelectableOption>
    {
        new SelectableOption { Name = "World", IsSelected = false },
        new SelectableOption { Name = "Winter", IsSelected = false },
        new SelectableOption { Name = "Trees", IsSelected = false },
        new SelectableOption { Name = "Fantasy", IsSelected = false },
        new SelectableOption { Name = "Nature", IsSelected = false },
        new SelectableOption { Name = "Abstract", IsSelected = false }
    }.ToImmutableList();
    
    private readonly IImmutableList<ArtStyle> _styles = new List<ArtStyle>
    {
        new ArtStyle { Name = "Cartoon", ImageUrl = "ms-appx:///Assets/cartoon.jpg" },
        new ArtStyle { Name = "Realistic", ImageUrl = "ms-appx:///Assets/realistic.jpg" },
        new ArtStyle { Name = "Watercolor Art", ImageUrl = "ms-appx:///Assets/watercolor.jpg" },
        new ArtStyle { Name = "Isometric", ImageUrl = "ms-appx:///Assets/isometric.jpg" },
        new ArtStyle { Name = "Pop Art", ImageUrl = "ms-appx:///Assets/popart.jpg" },
        new ArtStyle { Name = "Surrealism", ImageUrl = "ms-appx:///Assets/surrealism.jpg" },
        new ArtStyle { Name = "Minimalism", ImageUrl = "ms-appx:///Assets/minimalism.jpg" },
        new ArtStyle { Name = "Funko", ImageUrl = "ms-appx:///Assets/funko.jpg" },
        new ArtStyle { Name = "Anime", ImageUrl = "ms-appx:///Assets/anime.jpg" },
        new ArtStyle { Name = "Storybook", ImageUrl = "ms-appx:///Assets/storybook.jpg" },
    }.ToImmutableList();
    
    public IListState<SelectableOption> Options => ListState.Value(this, () => _options);
    public IListState<ArtStyle> Styles => ListState.Value(this, () => _styles);
    
    public IState<string> PromptText => State<string>.Value(this, () => string.Empty);
    public IState<ArtStyle?> SelectedStyle => State<ArtStyle?>.Value(this, () => _styles.FirstOrDefault());
    
    public async Task Generate()
    {
        var prompt = await PromptText;
        var style = await SelectedStyle;
        // Navegar a la página de generación
        await _navigator.NavigateViewModelAsync<ThirdModel>(this);
    }
}
