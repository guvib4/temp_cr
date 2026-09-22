namespace ChainResponsibilityProject.Models;

/// <summary>
/// Выбор банкнот по 500 рублей.
/// </summary>
public class Banknote500Counter : AbstractBanknoteCounter
{
    protected override int GetBanknoteValue() => 500;
}