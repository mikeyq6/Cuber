using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuber.Display;

namespace Cuber
{
    class Program
    {
        static void Main(string[] args)
        {
            Cube cube = new Cube();
            ICubeDisplay display = new ConsoleDisplay(cube);

            //cube.DoMove(MoveType.Back, MoveDirection.Forward);
            //cube.DoMove(MoveType.Left, MoveDirection.Reverse);
            //cube.DoMove(MoveType.Left, MoveDirection.Forward);
            cube.DoMove(MoveType.Right, MoveDirection.Reverse);
            cube.DoMove(MoveType.Upper, MoveDirection.Forward);
            cube.DoMove(MoveType.Right, MoveDirection.Forward);
            cube.DoMove(MoveType.Lower, MoveDirection.Forward);
            cube.DoMove(MoveType.Lower, MoveDirection.Reverse);
            cube.DoMove(MoveType.Right, MoveDirection.Reverse);
            cube.DoMove(MoveType.Upper, MoveDirection.Reverse);
            cube.DoMove(MoveType.Right, MoveDirection.Forward);

            ConsoleKeyInfo c = Console.ReadKey();
        }
    }
}
