using ChessApp.Abstracts;

namespace ChessApp.Models;

/// <summary>
/// Ферзь / Королева.
/// </summary>
public class Queen : AbstractChessFigure
{
    #region Private Members

    private const FiguresEnum FigureType = FiguresEnum.Queen;
    public const string LongName  = "Ферзь / Королева";
    private const string ShortName = "Ф";

    #endregion

    
    #region Constructors
    
    public Queen(FigureColorEnum figureColor, (int Row, int Col) coords) : base(figureColor, coords)
    {
    }
    
    #endregion
    
    
    #region Public Methods

    public override FiguresEnum GetFigureType() => FigureType;

    public override string GetShortName() => ShortName;

    public override IReadOnlyDictionary<int, ISet<int>> GetAllowedMoves(IChessBoard board)
    {
        var rows = new List<(int Row, int Col)>();
        for (var i = 1; i <= board.GetSize(); i++)
        {
            if ((Coords.Row - i) >= 1 && (Coords.Col - i) >= 1)
                rows.Add((Coords.Row - i, Coords.Col - i));
            
            if ((Coords.Row - i) >= 1 && (Coords.Col + i) <= board.GetSize())
                rows.Add((Coords.Row - i, Coords.Col + i));
            
            if ((Coords.Row + i) <= board.GetSize() && (Coords.Col - i) >= 1)
                rows.Add((Coords.Row + i, Coords.Col - i));
            
            if ((Coords.Row + i) <= board.GetSize() && (Coords.Col + i) <= board.GetSize())
                rows.Add((Coords.Row + i, Coords.Col + i));
            
            if (Coords.Col != i)
                rows.Add((Coords.Row, i));
            
            if (Coords.Row != i)
                rows.Add((i, Coords.Col));
        }
        
        var result = GetAllowedMoves(board, rows);
        return result;
    }
    
    #endregion
}