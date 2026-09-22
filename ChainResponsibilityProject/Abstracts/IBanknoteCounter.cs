namespace ChainResponsibilityProject.Abstracts;

/// <summary>
/// Интерфейс для реализаци Chain Responsibility.
/// </summary>
public interface IBanknoteCounter
{
    /// <summary>
    /// Установить следующий обработчик.
    /// </summary>
    /// <param name="nextHandler">Следующий обработчик.</param>
    /// <returns>Возвращается <paramref name="nextHandler"/>.</returns>
    IBanknoteCounter SetHandler(IBanknoteCounter nextHandler);
    
    /// <summary>
    /// Подобрать купюры.
    /// </summary>
    /// <param name="sum">Сумма, под которую нужно подобрать число купюр.</param>
    /// <param name="banknotes">Словарь, какие купюры выбраны: Key - номинал купюры, Value - число купюр.</param>
    void ChooseBanknotes(int sum, IDictionary<int, int> banknotes);
}