using ChessApp.Abstracts;

namespace ChessApp.Models;

/// <summary>
/// Шахматная доска.
/// </summary>
public class ChessBoard : IChessBoard
{
    #region Private Fields, Consts

    private const int BoardSize = 8;
    private static readonly char[] AllowedCoordX = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'];

    #endregion
    
    
    #region Public Methods

    /// <summary>
    /// Может ли фигура тут стоять изначально.
    /// </summary>
    public bool CanFigureStandHere(IChessFigure figure)
    {
        var coords = figure.GetCoords();
        if (!IsOnBoard(coords.Row, coords.Col))
            return false;

        if (figure.GetFigureType() != FiguresEnum.Pawn)
            return true;
        
        // пешка не должна быть на "своей" первой строке
        var mistake =
            (figure.GetFigureColor() == FigureColorEnum.White && coords.Row == 1) ||
            (figure.GetFigureColor() == FigureColorEnum.Black && coords.Row == BoardSize);
        return !mistake;
    }

    
    /// <summary>
    /// Нарисовать пустую доску.
    /// </summary>
    public void DrawEmptyBoard()
    {
        DrawHeader();
        for (var i = 0; i < BoardSize; i++)
        {
            Console.Write($"{8 - i} |");
            for (var j = 0; j < BoardSize; j++)
            {
                Console.Write(" _ ");
            }
            Console.WriteLine("|");
        }
        DrawFooter();
    }

    
    /// <summary>
    /// Нарисовать доску с фигурой и возможными ходами.
    /// </summary>
    public void DrawBoardWithFigure(IChessFigure figure, IReadOnlyDictionary<int, ISet<int>> moves)
    {
        var defConsoleColor = Console.ForegroundColor;
        DrawHeader();
        for (var i = 0; i < BoardSize; i++)
        {
            var row = 8 - i;
            Console.Write($"{row} |");
            for (var j = 0; j < BoardSize; j++)
            {
                var col = j + 1;
                if (row == figure.GetCoords().Row && col == figure.GetCoords().Col)
                {
                    Console.ForegroundColor = GetFigureConsoleColor(figure.GetFigureColor());
                    Console.Write(" " + figure.GetShortName() + " ");
                    Console.ForegroundColor = defConsoleColor;
                }
                else if (moves.ContainsKey(row) && moves[row].Contains(col))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" X ");
                    Console.ForegroundColor = defConsoleColor;
                }
                else
                {
                    Console.Write(" _ ");
                }
            }
            Console.WriteLine("|");
        }
        DrawFooter();
    }

    
    /// <summary>
    /// Получить координаты в виде чисел.
    /// </summary>
    /// <param name="coord">Координата в виде строки, например, a1.</param>
    /// <param name="row">Возвращается номер строки на доске.</param>
    /// <param name="col">Возвращается номер столбца на доске.</param>
    /// <returns>Возвращается true, если координаты успешно преобразованы.</returns>
    public bool GetCoord(string? coord, out int row, out int col)
    {
        row = col = -1;
        
        if (coord?.Length != 2)
            return false;

        col = Array.IndexOf(AllowedCoordX, coord[0]);
        if (col < 0)
            return false;
        col++;
        
        return int.TryParse(coord[1].ToString(), out row) && (row is >= 1 and <= BoardSize);
    }


    /// <summary>
    /// Получить размер доски.
    /// </summary>
    public int GetSize() => BoardSize;
    

    /// <summary>
    /// Находятся ли переданные координаты внутри доски.
    /// </summary>
    public bool IsOnBoard(int row, int col) =>
        row is >= 1 and <= BoardSize && col is >= 1 and <= BoardSize;
    
    #endregion
    
    
    #region Private Methods

    private static void DrawHeader()
    {
        Console.WriteLine("    a  b  c  d  e  f  g  h  ");
        Console.WriteLine("  +------------------------+");
    }

    private static void DrawFooter()
    {
        Console.WriteLine("  +------------------------+");
        Console.WriteLine("    a  b  c  d  e  f  g  h  ");
    }

    /// <summary>
    /// Получить цвет фигуры для вывода на консоль.
    /// </summary>
    private static ConsoleColor GetFigureConsoleColor(FigureColorEnum figureColor)
    {
        if (Console.BackgroundColor == ConsoleColor.Black)
        {
            return figureColor == FigureColorEnum.White
                ? ConsoleColor.White
                : ConsoleColor.DarkBlue;
        }

        return figureColor == FigureColorEnum.White
            ? ConsoleColor.Yellow
            : ConsoleColor.Black;
    }

    #endregion
}