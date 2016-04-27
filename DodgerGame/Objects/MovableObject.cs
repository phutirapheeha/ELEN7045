using DodgerGame.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Objects
{
    public abstract class MovableObject : VisualObject
    {
        private Guid _id;
        private Point _position;

        protected MovableObject(Point position, string imageFilename) 
            : base(imageFilename)
        {
            _id = Guid.NewGuid();
            _position = position;
        }

        public string ID
        {
            get { return _id.ToString(); }
        }

        ///<summary>
        ///Updates position to simulate moving.
        ///</summary>
        ///<remarks></remarks>
        public virtual void Move(Point newPosition)
        {
            _position = newPosition;
        }

        ///<summary>
        ///Returns updated position.
        ///</summary>
        ///<remarks></remarks>
        public override Point GetPosition()
        {
            return _position;
        }
    }
}
