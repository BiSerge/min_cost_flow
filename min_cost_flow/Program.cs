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
            int _equalChips = 0;  
            int _minMoves = 99999;

            do
            {
                Console.Write("Write _chips sequence of values separated by _chips space, <Enter> - is completed: ");
                int[] _chips = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int _numberChips = _equalChips = _chips.Length;
                int[] b = new int[_numberChips + 1];

                Array.Sort(_chips);

                b[0] = 0;
                for (int i = 0; i < _numberChips; i++)
                {
                    b[i + 1] = b[i] + _chips[i];
                }

                for (int i = 0, j = 0; i < _numberChips; i = j) { 
                    for (; j < _numberChips && _chips[i] == _chips[j]; j++) ;

                    int _equalElements = j - i, x = _chips[i], _minActions = 1 * i * (x - 1) - b[i], _maxActions = b[_numberChips] - b[j] - (_numberChips - j) * (x + 1);

                    if (_equalElements >= _equalChips)
                    {
                        _minMoves = 0;
                        break;
                    }

                    if (_equalElements + i >= _equalChips)
                        _minMoves = Math.Min(_minMoves, _minActions + _equalChips - _equalElements);

                    if (_equalElements + _numberChips - j >= _equalChips)
                        _minMoves = Math.Min(_minMoves, _maxActions + _equalChips - _equalElements);

                    _minMoves = Math.Min(_minMoves, _minActions + _maxActions + _equalChips - _equalElements - 1);
                }

                Console.WriteLine($"The minimum number of chip moves: {_minMoves}");
                Console.Write("Press <Escape> to exit or Press <Enter> to continue... ");
                Console.WriteLine();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
