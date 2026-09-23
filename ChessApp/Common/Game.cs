using ChessApp.Abstracts;
using ChessApp.Models;

namespace ChessApp.Common;

public class Game
{
    #region Private Fields

    /// <summary>
    /// Все возможные фигуры.
    /// </summary>
    private static readonly IReadOnlyDictionary<string, Func<FigureColorEnum, (int Row, int Col), IChessFigure>> AllChessFigures;
    
    /// <summary>
    /// Шахматная доска.
    /// </summary>
    private readonly IChessBoard _board = new ChessBoard();
    
    /// <summary>
    /// Выбранная фигура.
    /// </summary>
    private IChessFigure? _figure;
    
    #endregion

    
    #region Constructors
    
    static Game()
    {
        AllChessFigures = new Dictionary<string, Func<FigureColorEnum, (int Row, int Col), IChessFigure>>
        {
            [Pawn.LongName] = (color, coords) => new Pawn(color, coords),
            [Knight.LongName] = (color, coords) => new Knight(color, coords),
            [Rook.LongName] = (color, coords) => new Rook(color, coords),
            [Bishop.LongName] = (color, coords) => new Bishop(color, coords),
            [King.LongName] = (color, coords) => new King(color, coords),
            [Queen.LongName] = (color, coords) => new Queen(color, coords)
        };
    }
    
    #endregion
    
    
    #region Public Methods

    public void Play()
    {
        Console.Clear();

        var color = ChooseColor();
        var coords = ChooseCoordinates();
        _figure = ChooseFigure(color, coords);
        
        var moves = _figure.GetAllowedMoves(_board);
        _board.DrawBoardWithFigure(_figure, moves);
    }

    #endregion
    
    
    #region Private Methods

    /// <summary>
    /// Выбрать цвет фигуры.
    /// </summary>
    private static FigureColorEnum ChooseColor()
    {
        while (true)
        {
            Console.WriteLine("Выберите цвет фигуры:");
            Console.WriteLine("1. Белые");
            Console.WriteLine("2. Чёрные");

            var key = Console.ReadKey();
            Console.WriteLine();
            if (char.IsDigit(key.KeyChar))
            {
                var number = int.Parse(key.KeyChar.ToString());
                switch (number)
                {
                    case 1:
                        return FigureColorEnum.White;
                    case 2:
                        return FigureColorEnum.Black;
                }
            }
        }
    }
    
    /// <summary>
    /// Выбор клетки на доске.
    /// </summary>
    private (int Row, int Column) ChooseCoordinates()
    {
        _board.DrawEmptyBoard();
        while (true)
        {
            Console.Write("Введите правильные координаты фигуры, например e2:  ");
            var strCoord = Console.ReadLine();
            if (_board.GetCoord(strCoord, out var row, out var column))
            {
                return (row, column);
            }
        }
    }
    
    /// <summary>
    /// Выбор фигуры.
    /// </summary>
    private IChessFigure ChooseFigure(FigureColorEnum color, (int Row, int Column) coords)
    {
        while (true)
        {
            Console.WriteLine("Выберите фигуру:");
            for (var i = 0; i < AllChessFigures.Keys.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {AllChessFigures.Keys.ElementAt(i)}");
            }

            var key = Console.ReadKey();
            Console.WriteLine();
            if (!char.IsDigit(key.KeyChar))
                continue;
            
            var number = int.Parse(key.KeyChar.ToString());
            if (number < 1 && number > AllChessFigures.Count)
                continue;

            var figure = AllChessFigures.Values.ElementAt(number - 1)(color, coords);
            if (_board.CanFigureStandHere(figure))
                return figure;
            Console.WriteLine("Сюда нельзя поставить эту фигуру!");
        }
    }

    #endregion
}