namespace ChainResponsibilityProject.Models;

/// <summary>
/// Выбор банкнот по 100 рублей.
/// </summary>
public class Banknote100Counter : AbstractBanknoteCounter
{
    protected override int GetBanknoteValue() => 100;
}