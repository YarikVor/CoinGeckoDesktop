using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoinGecko.UserControls;

public partial class IconMenu : UserControl
{
    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
        nameof(ImageSource),
        typeof(ImageSource),
        typeof(IconMenu)
    );

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(IconMenu)
    );

    public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
        nameof(Color),
        typeof(Color),
        typeof(IconMenu),
        new PropertyMetadata(Colors.Black)
    );

    public IconMenu()
    {
        InitializeComponent();
        DataContext = this;
    }

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

    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public Type? PageType { get; set; }

    public event Action? OnClick;
}