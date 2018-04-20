using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuber
{
    public delegate void CubeChangedHandler();

    public class Cube
    {

        private Dictionary<FaceType, CubeFace> _faces = new Dictionary<FaceType, CubeFace>();

        //private bool HasChanged { get; set; } = false;

        public event CubeChangedHandler CubeChanged;

        public Cube()
        {
            _faces[FaceType.Front] = new CubeFace(BitColour.White);
            _faces[FaceType.Left] = new CubeFace(BitColour.Green);
            _faces[FaceType.Right] = new CubeFace(BitColour.Blue);
            _faces[FaceType.Back] = new CubeFace(BitColour.Yellow);
            _faces[FaceType.Top] = new CubeFace(BitColour.Orange);
            _faces[FaceType.Bottom] = new CubeFace(BitColour.Red);

            _faces[FaceType.Front].SetAdjacent(FaceType.Top, _faces[FaceType.Top]);
            _faces[FaceType.Front].SetAdjacent(FaceType.Bottom, _faces[FaceType.Bottom]);
            _faces[FaceType.Front].SetAdjacent(FaceType.Left, _faces[FaceType.Left]);
            _faces[FaceType.Front].SetAdjacent(FaceType.Right, _faces[FaceType.Right]);

            _faces[FaceType.Left].SetAdjacent(FaceType.Top, _faces[FaceType.Top]);
            _faces[FaceType.Left].SetAdjacent(FaceType.Bottom, _faces[FaceType.Bottom]);
            _faces[FaceType.Left].SetAdjacent(FaceType.Left, _faces[FaceType.Back]);
            _faces[FaceType.Left].SetAdjacent(FaceType.Right, _faces[FaceType.Front]);

            _faces[FaceType.Back].SetAdjacent(FaceType.Top, _faces[FaceType.Top]);
            _faces[FaceType.Back].SetAdjacent(FaceType.Bottom, _faces[FaceType.Bottom]);
            _faces[FaceType.Back].SetAdjacent(FaceType.Left, _faces[FaceType.Right]);
            _faces[FaceType.Back].SetAdjacent(FaceType.Right, _faces[FaceType.Left]);

            _faces[FaceType.Right].SetAdjacent(FaceType.Top, _faces[FaceType.Top]);
            _faces[FaceType.Right].SetAdjacent(FaceType.Bottom, _faces[FaceType.Bottom]);
            _faces[FaceType.Right].SetAdjacent(FaceType.Left, _faces[FaceType.Front]);
            _faces[FaceType.Right].SetAdjacent(FaceType.Right, _faces[FaceType.Back]);
            
            _faces[FaceType.Top].SetAdjacent(FaceType.Top, _faces[FaceType.Back]);
            _faces[FaceType.Top].SetAdjacent(FaceType.Bottom, _faces[FaceType.Front]);
            _faces[FaceType.Top].SetAdjacent(FaceType.Left, _faces[FaceType.Left]);
            _faces[FaceType.Top].SetAdjacent(FaceType.Right, _faces[FaceType.Right]);

            _faces[FaceType.Bottom].SetAdjacent(FaceType.Top, _faces[FaceType.Front]);
            _faces[FaceType.Bottom].SetAdjacent(FaceType.Bottom, _faces[FaceType.Back]);
            _faces[FaceType.Bottom].SetAdjacent(FaceType.Left, _faces[FaceType.Left]);
            _faces[FaceType.Bottom].SetAdjacent(FaceType.Right, _faces[FaceType.Right]);
        }

        public void DoMove(MoveType type, MoveDirection direction)
        {
            //HasChanged = true;
            switch(type)
            {
                case MoveType.Left:
                    if (direction == MoveDirection.Reverse)
                        LeftReverse();
                    else
                        LeftForward();
                    break;
                case MoveType.Right:
                    if (direction == MoveDirection.Reverse)
                        RightReverse();
                    else
                        RightForward();
                    break;
                case MoveType.Upper:
                    if (direction == MoveDirection.Reverse)
                        UpperReverse();
                    else
                        UpperForward();
                    break;
            }

            CubeChanged();
            //HasChanged = false;
        }

        private void LeftReverse()
        {
            BitColour l0 = _faces[FaceType.Front].GetBit(0);
            BitColour l1 = _faces[FaceType.Front].GetBit(3);
            BitColour l2 = _faces[FaceType.Front].GetBit(6);

            _faces[FaceType.Front].SetBit(0, _faces[FaceType.Bottom].GetBit(0));
            _faces[FaceType.Front].SetBit(3, _faces[FaceType.Bottom].GetBit(3));
            _faces[FaceType.Front].SetBit(6, _faces[FaceType.Bottom].GetBit(6));

            _faces[FaceType.Bottom].SetBit(0, _faces[FaceType.Back].GetBit(0));
            _faces[FaceType.Bottom].SetBit(3, _faces[FaceType.Back].GetBit(3));
            _faces[FaceType.Bottom].SetBit(6, _faces[FaceType.Back].GetBit(6));

            _faces[FaceType.Back].SetBit(0, _faces[FaceType.Top].GetBit(0));
            _faces[FaceType.Back].SetBit(3, _faces[FaceType.Top].GetBit(3));
            _faces[FaceType.Back].SetBit(6, _faces[FaceType.Top].GetBit(6));

            _faces[FaceType.Top].SetBit(0, l0);
            _faces[FaceType.Top].SetBit(3, l1);
            _faces[FaceType.Top].SetBit(6, l2);

            _faces[FaceType.Left].RotateLeft();
        }

        private void LeftForward()
        {
            BitColour l0 = _faces[FaceType.Front].GetBit(0);
            BitColour l1 = _faces[FaceType.Front].GetBit(3);
            BitColour l2 = _faces[FaceType.Front].GetBit(6);

            _faces[FaceType.Front].SetBit(0, _faces[FaceType.Top].GetBit(0));
            _faces[FaceType.Front].SetBit(3, _faces[FaceType.Top].GetBit(3));
            _faces[FaceType.Front].SetBit(6, _faces[FaceType.Top].GetBit(6));

            _faces[FaceType.Top].SetBit(0, _faces[FaceType.Back].GetBit(0));
            _faces[FaceType.Top].SetBit(3, _faces[FaceType.Back].GetBit(3));
            _faces[FaceType.Top].SetBit(6, _faces[FaceType.Back].GetBit(6));

            _faces[FaceType.Back].SetBit(0, _faces[FaceType.Bottom].GetBit(0));
            _faces[FaceType.Back].SetBit(3, _faces[FaceType.Bottom].GetBit(3));
            _faces[FaceType.Back].SetBit(6, _faces[FaceType.Bottom].GetBit(6));

            _faces[FaceType.Bottom].SetBit(0, l0);
            _faces[FaceType.Bottom].SetBit(3, l1);
            _faces[FaceType.Bottom].SetBit(6, l2);

            _faces[FaceType.Left].RotateRight();
        }
        private void RightForward()
        {
            BitColour l0 = _faces[FaceType.Front].GetBit(2);
            BitColour l1 = _faces[FaceType.Front].GetBit(5);
            BitColour l2 = _faces[FaceType.Front].GetBit(8);

            _faces[FaceType.Front].SetBit(2, _faces[FaceType.Bottom].GetBit(2));
            _faces[FaceType.Front].SetBit(5, _faces[FaceType.Bottom].GetBit(5));
            _faces[FaceType.Front].SetBit(8, _faces[FaceType.Bottom].GetBit(8));

            _faces[FaceType.Bottom].SetBit(2, _faces[FaceType.Back].GetBit(2));
            _faces[FaceType.Bottom].SetBit(5, _faces[FaceType.Back].GetBit(5));
            _faces[FaceType.Bottom].SetBit(8, _faces[FaceType.Back].GetBit(8));

            _faces[FaceType.Back].SetBit(2, _faces[FaceType.Top].GetBit(2));
            _faces[FaceType.Back].SetBit(5, _faces[FaceType.Top].GetBit(5));
            _faces[FaceType.Back].SetBit(8, _faces[FaceType.Top].GetBit(8));

            _faces[FaceType.Top].SetBit(2, l0);
            _faces[FaceType.Top].SetBit(5, l1);
            _faces[FaceType.Top].SetBit(8, l2);

            _faces[FaceType.Right].RotateRight();
        }
        private void RightReverse()
        {
            BitColour l0 = _faces[FaceType.Front].GetBit(2);
            BitColour l1 = _faces[FaceType.Front].GetBit(5);
            BitColour l2 = _faces[FaceType.Front].GetBit(8);

            _faces[FaceType.Front].SetBit(2, _faces[FaceType.Top].GetBit(2));
            _faces[FaceType.Front].SetBit(5, _faces[FaceType.Top].GetBit(5));
            _faces[FaceType.Front].SetBit(8, _faces[FaceType.Top].GetBit(8));

            _faces[FaceType.Top].SetBit(2, _faces[FaceType.Back].GetBit(2));
            _faces[FaceType.Top].SetBit(5, _faces[FaceType.Back].GetBit(5));
            _faces[FaceType.Top].SetBit(8, _faces[FaceType.Back].GetBit(8));

            _faces[FaceType.Back].SetBit(2, _faces[FaceType.Bottom].GetBit(2));
            _faces[FaceType.Back].SetBit(5, _faces[FaceType.Bottom].GetBit(5));
            _faces[FaceType.Back].SetBit(8, _faces[FaceType.Bottom].GetBit(8));

            _faces[FaceType.Bottom].SetBit(2, l0);
            _faces[FaceType.Bottom].SetBit(5, l1);
            _faces[FaceType.Bottom].SetBit(8, l2);

            _faces[FaceType.Right].RotateLeft();
        }
        private void UpperForward()
        {
            BitColour l0 = _faces[FaceType.Front].GetBit(0);
            BitColour l1 = _faces[FaceType.Front].GetBit(1);
            BitColour l2 = _faces[FaceType.Front].GetBit(2);

            _faces[FaceType.Front].SetBit(0, _faces[FaceType.Right].GetBit(0));
            _faces[FaceType.Front].SetBit(1, _faces[FaceType.Right].GetBit(1));
            _faces[FaceType.Front].SetBit(2, _faces[FaceType.Right].GetBit(2));

            _faces[FaceType.Right].SetBit(0, _faces[FaceType.Back].GetBit(8));
            _faces[FaceType.Right].SetBit(1, _faces[FaceType.Back].GetBit(7));
            _faces[FaceType.Right].SetBit(2, _faces[FaceType.Back].GetBit(6));

            _faces[FaceType.Back].SetBit(8, _faces[FaceType.Left].GetBit(0));
            _faces[FaceType.Back].SetBit(7, _faces[FaceType.Left].GetBit(1));
            _faces[FaceType.Back].SetBit(6, _faces[FaceType.Left].GetBit(2));

            _faces[FaceType.Left].SetBit(0, l0);
            _faces[FaceType.Left].SetBit(1, l1);
            _faces[FaceType.Left].SetBit(2, l2);

            _faces[FaceType.Top].RotateRight();
        }
        private void UpperReverse()
        {
            BitColour l0 = _faces[FaceType.Front].GetBit(0);
            BitColour l1 = _faces[FaceType.Front].GetBit(1);
            BitColour l2 = _faces[FaceType.Front].GetBit(2);

            _faces[FaceType.Front].SetBit(0, _faces[FaceType.Left].GetBit(0));
            _faces[FaceType.Front].SetBit(1, _faces[FaceType.Left].GetBit(1));
            _faces[FaceType.Front].SetBit(2, _faces[FaceType.Left].GetBit(2));

            _faces[FaceType.Left].SetBit(0, _faces[FaceType.Back].GetBit(8));
            _faces[FaceType.Left].SetBit(1, _faces[FaceType.Back].GetBit(7));
            _faces[FaceType.Left].SetBit(2, _faces[FaceType.Back].GetBit(6));

            _faces[FaceType.Back].SetBit(8, _faces[FaceType.Right].GetBit(0));
            _faces[FaceType.Back].SetBit(7, _faces[FaceType.Right].GetBit(1));
            _faces[FaceType.Back].SetBit(6, _faces[FaceType.Right].GetBit(2));

            _faces[FaceType.Right].SetBit(0, l0);
            _faces[FaceType.Right].SetBit(1, l1);
            _faces[FaceType.Right].SetBit(2, l2);

            _faces[FaceType.Top].RotateLeft();
        }

        public CubeFace GetFace(FaceType face)
        {
            return _faces[face];
        }
    }

    public class CubeFace
    {
        private BitColour[] _facebits = new BitColour[9];

        private Dictionary<FaceType, CubeFace> _adjacents = new Dictionary<FaceType, CubeFace>();

        public CubeFace(BitColour colour)
        {
            for(int i=0; i<9; i++)
            {
                SetBit(i, colour);
            }
        }

        public void SetAdjacent(FaceType faceType, CubeFace cubeFace)
        {
            if(_adjacents.ContainsKey(faceType))
            {
                _adjacents[faceType] = cubeFace;
            }
            else
            {
                _adjacents.Add(faceType, cubeFace);
            }
        }

        public void SetBit(int index, BitColour colour)
        {
            _facebits[index] = colour;
        }
        public BitColour GetBit(int index)
        {
            return _facebits[index];
        }

        public void RotateLeft()
        {
            BitColour[] newbits = new BitColour[9];

            newbits[0] = _facebits[2];
            newbits[1] = _facebits[5];
            newbits[2] = _facebits[8];
            newbits[3] = _facebits[1];
            newbits[4] = _facebits[4];
            newbits[5] = _facebits[7];
            newbits[6] = _facebits[0];
            newbits[7] = _facebits[3];
            newbits[8] = _facebits[6];

            _facebits = newbits;
        }
        public void RotateRight()
        {
            BitColour[] newbits = new BitColour[9];

            newbits[0] = _facebits[6];
            newbits[1] = _facebits[3];
            newbits[2] = _facebits[0];
            newbits[3] = _facebits[7];
            newbits[4] = _facebits[4];
            newbits[5] = _facebits[1];
            newbits[6] = _facebits[8];
            newbits[7] = _facebits[5];
            newbits[8] = _facebits[2];

            _facebits = newbits;
        }
    }

    public enum BitColour
    {
        Red, Orange, Blue, Green, White, Yellow
    }

    public enum FaceType
    {
        Top, Bottom, Left, Right, Back, Front
    }

    public enum MoveType
    {
        Left, Right, Upper, Lower, Front, Back
    }

    public enum  MoveDirection
    {
        Forward, Reverse
    }
}
