using ImageGenerator.Models;

namespace ImageGenerator.Presentation;

public partial record ThirdModel
{
    private readonly INavigator _navigator;
    
    public ThirdModel(INavigator navigator)
    {
        _navigator = navigator;
    }
    
    public string Title => "Picture\ngenerated";
    public string TimeLabel => "Time spent ";
    public string SecondsLabel => " Seconds";
    
    public IState<int> ElapsedSeconds => State<int>.Value(this, () => 0);
    public IState<bool> IsGenerating => State<bool>.Value(this, () => true);
    public IState<bool> IsImageVisible => State<bool>.Value(this, () => false);
    public IState<bool> IsFinishButtonVisible => State<bool>.Value(this, () => false);
    public IState<double> FinishButtonScale => State<double>.Value(this, () => 0.0);
    public IState<double> ImageAnimationOpacity => State<double>.Value(this, () => 0.9);
    public IState<double> TimerHighlightOpacity => State<double>.Value(this, () => 0.0);
    
    public string GeneratedImageUrl => "https://picsum.photos/seed/generated/400/500";
    
    public async Task Finish()
    {
        // Navegar al dashboard (reiniciar)
        await _navigator.NavigateViewModelAsync<MainModel>(this, qualifier: Qualifiers.ClearBackStack);
    }
}
