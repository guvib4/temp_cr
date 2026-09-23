using ChessApp.Abstracts;

namespace ChessApp.Models;

/// <summary>
/// Абстрактный класс "Шахматная фигура".
/// </summary>
public abstract class AbstractChessFigure : IChessFigure
{
    #region Private Members

    /// <summary>
    /// Координаты фигуры на шахматной доске.
    /// </summary>
    protected readonly (int Row, int Col) Coords;
    
    /// <summary>
    /// Цвет фигуры.
    /// </summary>
    protected readonly FigureColorEnum FigureColor;

    #endregion

    
    #region Constructors
    
    protected AbstractChessFigure(FigureColorEnum figureColor, (int Row, int Col) coords)
    {
        FigureColor = figureColor;
        Coords = coords;
    }
    
    #endregion

    
    #region Public Methods

    public (int Row, int Col) GetCoords() => Coords;

    public FigureColorEnum GetFigureColor() => FigureColor;

    public abstract FiguresEnum GetFigureType();

    public abstract string GetShortName();

    public abstract IReadOnlyDictionary<int, ISet<int>> GetAllowedMoves(IChessBoard board);
    
    #endregion
    
    
    #region Protected Methods

    /// <summary>
    /// Проверка на правильность ходов.
    /// </summary>
    /// <param name="board">Доска</param>
    /// <param name="moves">Всевозможные ходы.</param>
    /// <returns>Возвращается словарь с правильными ходами: Key - строка, Value - столбцы.</returns>
    protected static IReadOnlyDictionary<int, ISet<int>> GetAllowedMoves(
        IChessBoard board, IReadOnlyCollection<(int Row, int Col)> moves)
    {
        var result = new Dictionary<int, ISet<int>>();
        foreach (var item in moves.Where(o => board.IsOnBoard(o.Row, o.Col)))
        {
            if (!result.TryGetValue(item.Row, out var value))
                result[item.Row] = new HashSet<int>{ item.Col };
            else
                value.Add(item.Col);
        }
        return result;
    }
    
    #endregion
}