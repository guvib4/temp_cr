namespace ChessApp.Abstracts;

/// <summary>
/// Контракт для реализации доски.
/// </summary>
public interface IChessBoard
{
    /// <summary>
    /// Нарисовать пустую доску.
    /// </summary>
    void DrawEmptyBoard();

    /// <summary>
    /// Нарисовать доску с фигурой и возможными ходами.
    /// </summary>
    /// <param name="figure">Текущая фигура.</param>
    /// <param name="moves">Возможные ходы на доске.</param>
    void DrawBoardWithFigure(IChessFigure figure, IReadOnlyDictionary<int, ISet<int>> moves);

    /// <summary>
    /// Получить координаты в виде чисел.
    /// </summary>
    /// <param name="coord">Координата в виде строки, например, a1.</param>
    /// <param name="row">Возвращается номер строки на доске.</param>
    /// <param name="col">Возвращается номер столбца на доске.</param>
    /// <returns>Возвращается true, если координаты успешно преобразованы.</returns>
    bool GetCoord(string? coord, out int row, out int col);

    /// <summary>
    /// Получить размер доски.
    /// </summary>
    int GetSize();

    /// <summary>
    /// Может ли фигура тут стоять изначально.
    /// </summary>
    bool CanFigureStandHere(IChessFigure figure); 
    
    /// <summary>
    /// Находятся ли переданные координаты внутри доски.
    /// </summary>
    bool IsOnBoard(int row, int col);
}