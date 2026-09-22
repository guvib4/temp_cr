using ChainResponsibilityProject.Utils;

// для простоты тут будем хранить, какие купюры и какого номинала выбраны
// Key - номинал, Value - число купюр.
var banknotes = new Dictionary<int, int>();

var sum = 0;
do
{
    if (!GetSum(out sum))
        break;
    banknotes.Clear();
    BanknoteCounterFactory
        .GetCounter()
        .ChooseBanknotes(sum, banknotes);
    WriteToConsole(sum);
} while (true);

Console.WriteLine("Конец работы программы");
return;


// Ввод суммы, как числа.
// Возвращается true, если введено число.
bool GetSum(out int prmSum)
{
    do
    {
        Console.WriteLine("Введите сумму (не число завершает работу): ");
        var strSum = Console.ReadLine();
        if (!int.TryParse(strSum, out prmSum))
            return false;
        if (sum > 0)
            return true;
        Console.WriteLine("Введите положительное число!");
    } while (true);
}

// Вывод в консоль результата.
void WriteToConsole(int prmSum)
{
    var outList = new List<string>();
    var resultSum = 0;
    foreach (var item in banknotes)
    {
        resultSum += item.Key * item.Value;
        outList.Add($"{item.Key}руб. X {item.Value}шт.");
    }
    Console.WriteLine(sum != resultSum
        ? $"Начальная сумма {prmSum} рублей. Не удалось подобрать точное число купюр.\n"
        : $"Начальная сумма {prmSum} рублей. Купюры: [{string.Join(", ", outList)}].\n");
}