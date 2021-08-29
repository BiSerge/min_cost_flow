using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace min_cost_flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;  
            int minn = 99999;

            do
            {
                Console.Write("Write a sequence of values separated by a space, <Enter> - is completed: ");
                int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int n = k = a.Length;
                int[] b = new int[n + 1];

                Array.Sort(a);

                b[0] = 0;
                for (int i = 0; i < n; i++)
                {
                    b[i + 1] = b[i] + a[i];
                }

                for (int i = 0, j = 0; i < n; i = j) { 
                    for (; j < n && a[i] == a[j]; j++) ;

                    int col = j - i, x = a[i], cl = 1 * i * (x - 1) - b[i], cr = b[n] - b[j] - (n - j) * (x + 1);

                    if (col >= k)
                    {
                        minn = 0;
                        break;
                    }

                    if (col + i >= k)
                        minn = Math.Min(minn, cl + k - col);

                    if (col + n - j >= k)
                        minn = Math.Min(minn, cr + k - col);

                    minn = Math.Min(minn, cl + cr + k - col - 1);
                }

                Console.WriteLine($"The minimum number of chip moves: {minn}");
                Console.Write("Press <Escape> to exit or Press <Enter> to continue... ");
                Console.WriteLine();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
