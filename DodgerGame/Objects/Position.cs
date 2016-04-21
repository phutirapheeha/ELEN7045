using DodgerGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Objects
{
    public class Position
    {
        float _x;
        float _y;

        public Position(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public float X
        {
            get { return _x; }
        }

        public float Y
        {
            get { return _y; }
        }
        //public override bool Equals(Position position2)
        //{
        //    return (position2._x == _x && position2._y == _y);
        //}

    }
}
