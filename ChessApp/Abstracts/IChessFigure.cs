using ChessApp.Models;

namespace ChessApp.Abstracts;

/// <summary>
/// Общий контракт шахматной фигуры.
/// </summary>
public interface IChessFigure
{
    /// <summary>
    /// Получить координаты фигуры на доске.
    /// </summary>
    (int Row, int Col) GetCoords();

    /// <summary>
    /// Получить цвет фигуры.
    /// </summary>
    FigureColorEnum GetFigureColor();

    /// <summary>
    /// Тип фигуры.
    /// </summary>
    FiguresEnum GetFigureType();

    /// <summary>
    /// Получить краткое имя фигуры.
    /// </summary>
    string GetShortName();

    /// <summary>
    /// Получить все возможные ходы фигуры.
    /// </summary>
    /// <param name="board">Шахматная доска.</param>
    /// <returns>Возвращается коллекция с координатами возможных ходов: key - строка, value - столбцы.</returns>
    IReadOnlyDictionary<int, ISet<int>> GetAllowedMoves(IChessBoard board);
}