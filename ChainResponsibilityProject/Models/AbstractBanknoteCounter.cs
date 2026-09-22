using ChainResponsibilityProject.Abstracts;

namespace ChainResponsibilityProject.Models;

/// <summary>
/// Абстрактный класс для подбора купюр.
/// </summary>
public abstract class AbstractBanknoteCounter : IBanknoteCounter
{
    /// <summary>
    /// Следующий обработчик.
    /// </summary>
    private IBanknoteCounter? _nextHandler;

    
    /// <summary>
    /// Установить следующий обработчик.
    /// </summary>
    /// <param name="nextHandler">Следующий обработчик.</param>
    /// <returns>Возвращается <paramref name="nextHandler"/>.</returns>
    public IBanknoteCounter SetHandler(IBanknoteCounter nextHandler)
    {
        _nextHandler = nextHandler;
        return nextHandler;
    }


    /// <summary>
    /// Подобрать купюры определенного номинала.
    /// </summary>
    /// <param name="sum">Сумма, под которую нужно подобрать число купюр определенного номинала.</param>
    /// <param name="banknotes">Словарь, какие купюры выбраны: Key - номинал купюры, Value - число купюр.</param>
    public void ChooseBanknotes(int sum, IDictionary<int, int> banknotes) =>
        ChooseBanknotesHandler(sum, GetBanknoteValue(), banknotes);


    /// <summary>
    /// Получить текущий номинал банкноты.
    /// </summary>
    /// <returns>Возвращается текущий номинал банкноты.</returns>
    protected abstract int GetBanknoteValue();
    
    
    /// <summary>
    /// Функция для подбора купюр.
    /// </summary>
    /// <param name="sum">Сумма, под которую нужно подобрать число купюр по 10 рублей.</param>
    /// <param name="banknoteValue">Номинал купюры, которую нужно выдать.</param>
    /// <param name="banknotes">Словарь, какие купюры выбраны: Key - номинал купюры, Value - число купюр.</param>
    private void ChooseBanknotesHandler(int sum, int banknoteValue, IDictionary<int, int> banknotes)
    {
        if (sum < banknoteValue)
        {
            _nextHandler?.ChooseBanknotes(sum, banknotes);
            return;
        }
        
        var count = sum / banknoteValue;
        banknotes[banknoteValue] = count;
        _nextHandler?.ChooseBanknotes(sum - count * banknoteValue, banknotes);
    }
}