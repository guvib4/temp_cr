using ChainResponsibilityProject.Abstracts;
using ChainResponsibilityProject.Models;

namespace ChainResponsibilityProject.Utils;

/// <summary>
/// Для демонстрации разных цепочек сделаем самую простую фабрику, которая выдает разные "машинки" для подсчета купюр.
/// </summary>
public static class BanknoteCounterFactory
{
    private static int _index = -1;

    private static readonly (string Name, IBanknoteCounter Counter)[] Counters =
        [
            ("1000, 500, 100, 50, 10", GetAllCounters()),
            ("1000, 100, 10", GetCounters_1000_100_10()),
            ("500, 50, 10", GetAllCounters_500_50_10())
        ];

    /// <summary>
    /// Получить "машинку" по кругу из списка уже предсозданных.
    /// </summary>
    public static IBanknoteCounter GetCounter()
    {
        _index = _index < 2
            ? _index + 1
            : 0;
        var counter = Counters[_index];
        Console.WriteLine("Выбрана машинка по выдачи купюр: " + counter.Name);
        return counter.Counter;
    }
    
    private static IBanknoteCounter GetAllCounters()
    {
        var result = new Banknote1000Counter();
        result
            .SetHandler(new Banknote500Counter())
            .SetHandler(new Banknote100Counter())
            .SetHandler(new Banknote50Counter())
            .SetHandler(new Banknote10Counter());
        return result;
    }

    private static IBanknoteCounter GetCounters_1000_100_10()
    {
        var result = new Banknote1000Counter();
        result
            .SetHandler(new Banknote100Counter())
            .SetHandler(new Banknote10Counter());
        return result;
    }

    private static IBanknoteCounter GetAllCounters_500_50_10()
    {
        var result = new Banknote500Counter();
        result
            .SetHandler(new Banknote50Counter())
            .SetHandler(new Banknote10Counter());
        return result;
    }
}