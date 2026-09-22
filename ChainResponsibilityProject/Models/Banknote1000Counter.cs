namespace ChainResponsibilityProject.Models;

/// <summary>
/// Выбор банкнот по 1000 рублей.
/// </summary>
public class Banknote1000Counter : AbstractBanknoteCounter
{
    protected override int GetBanknoteValue() => 1000;
}