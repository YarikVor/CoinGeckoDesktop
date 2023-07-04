using System.Windows;
using System.Windows.Controls;

namespace CoinGecko.UserControls;

public partial class PriceChangePercentageItem : UserControl
{
    public static readonly DependencyProperty PercentProperty = DependencyProperty.Register(
        nameof(Percent),
        typeof(float),
        typeof(PriceChangePercentageItem),
        new PropertyMetadata(ChangedPercent)
    );

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(PriceChangePercentageItem)
    );

    public static readonly DependencyProperty SignCharProperty = DependencyProperty.Register(
        nameof(SignChar),
        typeof(char),
        typeof(PriceChangePercentageItem)
    );

    public static readonly DependencyProperty ColorStatusProperty = DependencyProperty.Register(
        nameof(ColorStatus),
        typeof(string),
        typeof(PriceChangePercentageItem)
    );

    public PriceChangePercentageItem()
    {
        InitializeComponent();
    }

    public float Percent
    {
        get => (float)GetValue(PercentProperty);
        set => SetValue(PercentProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public char SignChar => (char)GetValue(SignCharProperty);

    public char SignCharCalc => Percent switch
    {
        > 0 => '⯅',
        < 0 => '⯆',
        _ => '='
    };

    public string ColorStatus => (string)GetValue(ColorStatusProperty);

    public string ColorStatusCalc => Percent switch
    {
        > 0 => "Green",
        < 0 => "Red",
        _ => " "
    };

    private static void ChangedPercent(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var instance = (PriceChangePercentageItem)d;
        instance.UpdateProperties();
    }

    private void UpdateProperties()
    {
        SetValue(SignCharProperty, SignCharCalc);
        SetValue(ColorStatusProperty, ColorStatusCalc);
    }
}