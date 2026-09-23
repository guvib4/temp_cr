using ChessApp.Common;

/*
 * Считаем, что снизу доски белые фигуры, сверху черные !!!
 */

var game = new Game();
do
{
    game.Play();
    Console.WriteLine("Нажмите Enter, чтобы выйти, или другую клавишу, чтобы продолжить");
} while (Console.ReadKey(true).Key != ConsoleKey.Enter);

Console.WriteLine("Конец работы программы");
