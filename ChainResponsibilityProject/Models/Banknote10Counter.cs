namespace ChainResponsibilityProject.Models;

/// <summary>
/// Выбор банкнот по 10 рублей.
/// </summary>
public class Banknote10Counter : AbstractBanknoteCounter
{
    protected override int GetBanknoteValue() => 10;
}