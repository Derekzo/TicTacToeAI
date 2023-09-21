// See https://aka.ms/new-console-template for more information
using TicTacToe;
using TicTacToe.Stats;

if (StatsFileSystemManager.AreStatsEmpty()) { 

    Console.WriteLine("Generating the stats one and only time. About 5 minutes needed");

    StatsFileSystemManager.Init();

    Console.WriteLine();
}

Console.WriteLine("Tic-Tac-Toe!");

Menu.Game();

Console.WriteLine("End");
Console.ReadLine();