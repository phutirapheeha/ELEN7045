using DodgerGame.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Objects
{
    public class Player : MovableObject
    {
        public Player(Point position, string imageFilename)
            : base(position, imageFilename)
        { }
    }
}
