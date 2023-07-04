using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CoinGecho.MemoryApi;
using CoinGecko.UserControls;

namespace CoinGecko.Windows;

public partial class MainWindow : DiWindow
{
    public static DependencyProperty VisibilityErrorProperty = DependencyProperty.Register(
        nameof(VisibilityError),
        typeof(Visibility),
        typeof(MainWindow),
        new PropertyMetadata(Visibility.Collapsed)
    );

    public static DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(MainWindow),
        new PropertyMetadata("")
    );

    private readonly ICoinGeckoClientWrapper _client;


    private CancellationTokenSource _cancellationTokenSource = new();

    public MainWindow(IServiceProvider services, ICoinGeckoClientWrapper client) : base(services)
    {
        _client = client;
        _client.OnError += ClientOnOnError;

        InitializeComponent();
    }

    public Visibility VisibilityError
    {
        get => (Visibility)GetValue(VisibilityErrorProperty);
        set => SetValue(VisibilityErrorProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }


    private void ClientOnOnError()
    {
        _cancellationTokenSource.Cancel();

        _cancellationTokenSource = new CancellationTokenSource();

        var cancel = _cancellationTokenSource;

        Text = Random.Shared.Next().ToString();

        VisibilityError = Visibility.Visible;

        Task.Run(async () =>
        {
            await Task.Delay(5000);
            if (cancel.IsCancellationRequested)
                return;
            Dispatcher.Invoke(() => { VisibilityError = Visibility.Collapsed; });
        }, cancel.Token);
    }

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (NavList.SelectedIndex < 0)
            return;

        var selected = (IconMenu)NavList.SelectedItem;
        //var pageUri = selected.PageUri;

        var type = selected.PageType;

        if (type == null)
            return;

        var page = GetRequiredService<Page>(type);

        NavFrame.Navigate(page);
    }
}