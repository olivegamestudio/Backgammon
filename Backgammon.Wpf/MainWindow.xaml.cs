using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Backgammon.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    BackgammonBoardViewModel _game = new();
    Dice _dice = new();
    BackgammonPlayer _whitePlayer = new() { Color = PieceColor.White };
    BackgammonPlayer _blackPlayer = new() { Color = PieceColor.Black };

    public MainWindow()
    {
        InitializeComponent();

        _game.Board = new();
        DataContext = _game;
    }

    async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await _game.Board.CreateGameBoard();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        foreach (int die in _dice.GetDice(2, true))
        {
            await _whitePlayer.TakeTurn(_game.Board, die);
        }

        _game.UpdateBoard();

        foreach (int die in _dice.GetDice(2, true))
        {
            await _blackPlayer.TakeTurn(_game.Board, die);
        }

        _game.UpdateBoard();
    }
}
