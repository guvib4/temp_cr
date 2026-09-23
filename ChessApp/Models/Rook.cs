using ChessApp.Abstracts;

namespace ChessApp.Models;

/// <summary>
/// Ладья / Тура.
/// </summary>
public class Rook : AbstractChessFigure
{
    #region Private Members

    private const FiguresEnum FigureType = FiguresEnum.Rook;
    public const string LongName  = "Ладья / Тура";
    private const string ShortName = "Т";

    #endregion

    
    #region Constructors
    
    public Rook(FigureColorEnum figureColor, (int Row, int Col) coords) : base(figureColor, coords)
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