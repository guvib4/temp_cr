using ChessApp.Abstracts;

namespace ChessApp.Models;

/// <summary>
/// Слон / Офицер.
/// </summary>
public class Bishop : AbstractChessFigure
{
    #region Private Members

    private const FiguresEnum FigureType = FiguresEnum.Bishop;
    public const string LongName  = "Слон / Офицер";
    private const string ShortName = "С";

    #endregion

    
    #region Constructors
    
    public Bishop(FigureColorEnum figureColor, (int Row, int Col) coords) : base(figureColor, coords)
    {
    }
    
    #endregion
    
    
    #region Public Methods

    public override FiguresEnum GetFigureType() => FigureType;

    public override string GetShortName() => ShortName;

    public override IReadOnlyDictionary<int, ISet<int>> GetAllowedMoves(IChessBoard board)
    {
        var rows = new List<(int Row, int Col)>();
        for (var i = 1; i < board.GetSize(); i++)
        {
            if ((Coords.Row - i) >= 1 && (Coords.Col - i) >= 1)
                rows.Add((Coords.Row - i, Coords.Col - i));
            
            if ((Coords.Row - i) >= 1 && (Coords.Col + i) <= board.GetSize())
                rows.Add((Coords.Row - i, Coords.Col + i));
            
            if ((Coords.Row + i) <= board.GetSize() && (Coords.Col - i) >= 1)
                rows.Add((Coords.Row + i, Coords.Col - i));
            
            if ((Coords.Row + i) <= board.GetSize() && (Coords.Col + i) <= board.GetSize())
                rows.Add((Coords.Row + i, Coords.Col + i));
        }
        
        var result = GetAllowedMoves(board, rows);
        return result;
    }
    
    #endregion
}