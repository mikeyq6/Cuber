using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuber.Display
{
    public class ConsoleDisplay : ICubeDisplay
    {
        public Cube cube { get; set; }

        public ConsoleDisplay(Cube cube)
        {
            this.cube = cube;
            this.cube.CubeChanged += UpdateDisplay;
        }

        public void UpdateDisplay()
        {
            Console.WriteLine("Cube state:");

            CubeFace face = cube.GetFace(FaceType.Top);
            Console.WriteLine($"   {colourToLetter(face.GetBit(0))}{colourToLetter(face.GetBit(1))}{colourToLetter(face.GetBit(2))}   ");
            Console.WriteLine($"   {colourToLetter(face.GetBit(3))}{colourToLetter(face.GetBit(4))}{colourToLetter(face.GetBit(5))}   ");
            Console.WriteLine($"   {colourToLetter(face.GetBit(6))}{colourToLetter(face.GetBit(7))}{colourToLetter(face.GetBit(8))}   ");

            CubeFace facel = cube.GetFace(FaceType.Left);
            face = cube.GetFace(FaceType.Front);
            CubeFace facer = cube.GetFace(FaceType.Right);
            Console.WriteLine($"{colourToLetter(facel.GetBit(0))}{colourToLetter(facel.GetBit(1))}{colourToLetter(facel.GetBit(2))}{colourToLetter(face.GetBit(0))}{colourToLetter(face.GetBit(1))}{colourToLetter(face.GetBit(2))}{colourToLetter(facer.GetBit(0))}{colourToLetter(facer.GetBit(1))}{colourToLetter(facer.GetBit(2))}");
            Console.WriteLine($"{colourToLetter(facel.GetBit(3))}{colourToLetter(facel.GetBit(4))}{colourToLetter(facel.GetBit(5))}{colourToLetter(face.GetBit(3))}{colourToLetter(face.GetBit(4))}{colourToLetter(face.GetBit(5))}{colourToLetter(facer.GetBit(3))}{colourToLetter(facer.GetBit(4))}{colourToLetter(facer.GetBit(5))}");
            Console.WriteLine($"{colourToLetter(facel.GetBit(6))}{colourToLetter(facel.GetBit(7))}{colourToLetter(facel.GetBit(8))}{colourToLetter(face.GetBit(6))}{colourToLetter(face.GetBit(7))}{colourToLetter(face.GetBit(8))}{colourToLetter(facer.GetBit(6))}{colourToLetter(facer.GetBit(7))}{colourToLetter(facer.GetBit(8))}");

            face = cube.GetFace(FaceType.Bottom);
            Console.WriteLine($"   {colourToLetter(face.GetBit(0))}{colourToLetter(face.GetBit(1))}{colourToLetter(face.GetBit(2))}   ");
            Console.WriteLine($"   {colourToLetter(face.GetBit(3))}{colourToLetter(face.GetBit(4))}{colourToLetter(face.GetBit(5))}   ");
            Console.WriteLine($"   {colourToLetter(face.GetBit(6))}{colourToLetter(face.GetBit(7))}{colourToLetter(face.GetBit(8))}   ");

            face = cube.GetFace(FaceType.Back);
            Console.WriteLine($"   {colourToLetter(face.GetBit(0))}{colourToLetter(face.GetBit(1))}{colourToLetter(face.GetBit(2))}   ");
            Console.WriteLine($"   {colourToLetter(face.GetBit(3))}{colourToLetter(face.GetBit(4))}{colourToLetter(face.GetBit(5))}   ");
            Console.WriteLine($"   {colourToLetter(face.GetBit(6))}{colourToLetter(face.GetBit(7))}{colourToLetter(face.GetBit(8))}   ");
        }

        private char colourToLetter(BitColour colour)
        {
            switch (colour)
            {
                case BitColour.Blue:
                    return 'B';
                case BitColour.Green:
                    return 'G';
                case BitColour.Orange:
                    return 'O';
                case BitColour.Red:
                    return 'R';
                case BitColour.White:
                    return 'W';
                case BitColour.Yellow:
                    return 'Y';
            }
            return ' ';
        }
    }
}
