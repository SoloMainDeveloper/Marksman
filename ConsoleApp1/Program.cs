Solver.Solve();

public class Solver
{
    public static void Solve()
    {
        for (var i = 0; i < 7; i++)
            for (var j = 0; j < 7; j++)
            {
                var x = ((2 * i) % 5 + (3 * j) % 5) % 5;
                var y = ((3 * i) % 5 + (4 * j) % 5) % 5;
                if (x == 2 && y == 2)
                    Console.WriteLine($"{i}, {j}");
            }
    }
}
