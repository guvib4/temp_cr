namespace ChainResponsibilityProject.Models;

/// <summary>
/// Выбор банкнот по 50 рублей.
/// </summary>
public class Banknote50Counter : AbstractBanknoteCounter
{
    protected override int GetBanknoteValue() => 50;
}