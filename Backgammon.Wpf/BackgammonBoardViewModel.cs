using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Backgammon.Wpf;

public partial class BackgammonBoardViewModel : ObservableObject
{
    [ObservableProperty]
    BackgammonBoard _board;

    [ObservableProperty]
    ObservableCollection<BackgammonPointViewModel> _points = new();

    partial void OnBoardChanged(BackgammonBoard value)
    {
        UpdateBoard();
    }

    public void UpdateBoard()
    { 
        Points.Clear();
        foreach(BackgammonPoint point in Board.Points.OrderBy(it=>it.Point))
        {
            Points.Add(new BackgammonPointViewModel { Id=point.Point, Color = point.Color, Count = point.Count });
        }
    }
}
