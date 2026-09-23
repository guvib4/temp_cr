using ChessApp.Abstracts;

namespace ChessApp.Models;

/// <summary>
/// Король.
/// </summary>
public class King : AbstractChessFigure
{
    #region Private Members

    private const FiguresEnum FigureType = FiguresEnum.King;
    public const string LongName  = "Король";
    private const string ShortName = "К";

    #endregion

    
    #region Constructors
    
    public King(FigureColorEnum figureColor, (int Row, int Col) coords) : base(figureColor, coords)
    {
    }
    
    #endregion
    
    
    #region Public Methods

    public override FiguresEnum GetFigureType() => FigureType;

    public override string GetShortName() => ShortName;

    public override IReadOnlyDictionary<int, ISet<int>> GetAllowedMoves(IChessBoard board)
    {
        var rows = new List<(int Row, int Col)>();
        if ((Coords.Row - 1) >= 1)
            rows.Add((Coords.Row - 1, Coords.Col));
            
        if ((Coords.Row + 1) <= board.GetSize())
            rows.Add((Coords.Row + 1, Coords.Col));
            
        if ((Coords.Col - 1) >= 1)
            rows.Add((Coords.Row, Coords.Col - 1));
            
        if ((Coords.Col + 1) <= board.GetSize())
            rows.Add((Coords.Row, Coords.Col + 1));
        
        var result = GetAllowedMoves(board, rows);
        return result;
    }
    
    #endregion
}