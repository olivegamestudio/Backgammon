using CommunityToolkit.Mvvm.ComponentModel;

namespace Backgammon.Wpf;

public partial class BackgammonPointViewModel : ObservableObject
{
    [ObservableProperty]
    int _id;

    [ObservableProperty]
    int _count;

    [ObservableProperty]
    PieceColor _color;
}
