using ChessApp.Abstracts;

namespace ChessApp.Models;

/// <summary>
/// Пешка.
/// </summary>
public class Pawn : AbstractChessFigure
{
    #region Private Members

    private const FiguresEnum FigureType = FiguresEnum.Pawn;
    public const string LongName  = "Пешка";
    private const string ShortName = "П";

    #endregion

    
    #region Constructors
    
    public Pawn(FigureColorEnum figureColor, (int Row, int Col) coords) : base(figureColor, coords)
    {
    }
    
    #endregion
    
    
    #region Public Methods

    public override FiguresEnum GetFigureType() => FigureType;

    public override string GetShortName() => ShortName;

    public override IReadOnlyDictionary<int, ISet<int>> GetAllowedMoves(IChessBoard board)
    {
        var rows = new List<(int Row, int Col)>();
        if (GetFigureColor() == FigureColorEnum.White)
        {
            rows.Add((Coords.Row + 1, Coords.Col));
            if (Coords.Row == 2)
                rows.Add((Coords.Row + 2, Coords.Col));
        }
        else
        {
            rows.Add((Coords.Row - 1, Coords.Col));
            if (Coords.Row == 2)
                rows.Add((Coords.Row - 2, Coords.Col));
        }
        
        var result = GetAllowedMoves(board, rows);
        return result;
    }
    
    #endregion
}