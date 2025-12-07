using ImageGenerator.Models;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

namespace ImageGenerator.Presentation;

public sealed partial class SecondPage : Page
{
    private Grid? _selectedStyleGrid;
    private ArtStyle? _selectedStyle;
    private readonly HashSet<Grid> _selectedOptionGrids = new();
    
    public SecondPage()
    {
        this.InitializeComponent();
    }
    
    private void OptionItem_Tapped(object sender, TappedRoutedEventArgs e)
    {
        if (sender is Grid tappedGrid)
        {
            var border = FindChild<Border>(tappedGrid, "SelectionBorder");
            if (border == null) return;
            
            // Toggle: si ya está seleccionado, deseleccionar
            if (_selectedOptionGrids.Contains(tappedGrid))
            {
                border.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(0, 0, 0, 0)); // Transparent
                _selectedOptionGrids.Remove(tappedGrid);
            }
            else
            {
                border.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255)); // White
                _selectedOptionGrids.Add(tappedGrid);
            }
        }
    }
    
    private void StyleItem_Tapped(object sender, TappedRoutedEventArgs e)
    {
        if (sender is Grid tappedGrid && tappedGrid.DataContext is ArtStyle tappedStyle)
        {
            // Si es el mismo elemento, deseleccionar
            if (_selectedStyle == tappedStyle)
            {
                ClearStyleSelection();
                return;
            }
            
            // Limpiar selección anterior
            ClearStyleSelection();
            
            // Seleccionar nuevo
            _selectedStyleGrid = tappedGrid;
            _selectedStyle = tappedStyle;
            
            // Encontrar el border y cambiar su color
            var border = FindChild<Border>(tappedGrid, "SelectionBorder");
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 152, 192, 254)); // #98C0FE
            }
        }
    }
    
    private void ClearStyleSelection()
    {
        if (_selectedStyleGrid != null)
        {
            var border = FindChild<Border>(_selectedStyleGrid, "SelectionBorder");
            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(0, 0, 0, 0)); // Transparent
            }
        }
        _selectedStyleGrid = null;
        _selectedStyle = null;
    }
    
    private T? FindChild<T>(DependencyObject parent, string name) where T : FrameworkElement
    {
        int childCount = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childCount; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T typedChild && typedChild.Name == name)
            {
                return typedChild;
            }
            var result = FindChild<T>(child, name);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }
}

