using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoinGecko.Panels;

public partial class IconMenu : UserControl
{
    public IconMenu()
    {
        InitializeComponent();
        DataContext = this;
    }

    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
        nameof(IconMenu.ImageSource),
        typeof(ImageSource),
        typeof(IconMenu)
    );
    
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(IconMenu.Title),
        typeof(string),
        typeof(IconMenu)
    );

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public Type PageType { get; set; }
    
    public event Action OnClick;
}