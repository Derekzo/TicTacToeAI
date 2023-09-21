using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace TicTacToe.Stats
{
    public class StatsFileSystemManager
    {
        public static string FILE_PATH = "C:\\MartinoMakesSoftware\\TicTacToe\\stats.json";
        public static GridStats[] Stats { get; set; }

        public static void Init()
        {
            if (AreStatsEmpty())
            {
                var gridGenerator = new GridGenerator();

                gridGenerator.Generate();
            }

            Read();
        }

        public static void Write(IEnumerable<GridStats> stats)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FILE_PATH));

            File.Create(FILE_PATH).Close();

            File.WriteAllText(FILE_PATH,
                JsonSerializer.Serialize(stats.ToArray()));
        }

        public static void Read()
        {
            string stats = File.ReadAllText(FILE_PATH);

            Stats = JsonSerializer.Deserialize<GridStats[]>(stats);
        }

        public static bool AreStatsEmpty()
        {
            return !File.Exists(FILE_PATH);
        }
    }
}
