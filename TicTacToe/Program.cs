// See https://aka.ms/new-console-template for more information
using TicTacToe;
using TicTacToe.Stats;

StatsFileSystemManager.Init();

Console.WriteLine("Tic-Tac-Toe!");

Menu.Game();

Console.WriteLine("End");
Console.ReadLine();