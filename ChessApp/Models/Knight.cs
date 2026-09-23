using ChessApp.Abstracts;

namespace ChessApp.Models;

/// <summary>
/// Лошадь.
/// </summary>
public class Knight : AbstractChessFigure
{
    #region Private Members

    private const FiguresEnum FigureType = FiguresEnum.Knight;
    public const string LongName  = "Лошадь / Конь"; 
    private const string ShortName = "Л";

    #endregion

    
    #region Constructors
    
    public Knight(FigureColorEnum figureColor, (int Row, int Col) coords) : base(figureColor, coords)
    {
    }
    
    #endregion
    
    
    #region Public Methods

    public override FiguresEnum GetFigureType() => FigureType;

    public override string GetShortName() => ShortName;

    public override IReadOnlyDictionary<int, ISet<int>> GetAllowedMoves(IChessBoard board)
    {
        var rows = new List<(int Row, int Col)>
        {
            (Coords.Row - 2, Coords.Col - 1),
            (Coords.Row - 2, Coords.Col + 1),
            (Coords.Row - 1, Coords.Col - 2),
            (Coords.Row - 1, Coords.Col + 2),
            (Coords.Row + 1, Coords.Col - 2),
            (Coords.Row + 1, Coords.Col + 2),
            (Coords.Row + 2, Coords.Col - 1),
            (Coords.Row + 2, Coords.Col + 1)
        };
        var result = GetAllowedMoves(board, rows);
        return result;
    }
    
    #endregion
}