using DodgerGame.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Objects
{
    public abstract class VisualObject
    {
        private readonly string _imageFilename;

        ///<summary>
        ///Requires path to a drawable artifact
        ///</summary>
        ///<remarks></remarks>
        protected VisualObject(string imageFilename)
        {
            _imageFilename = imageFilename;
        }

        ///<summary>
        ///This method takes a type of IRenderEngine which then handles the drawing of images onto the screen.
        ///</summary>
        ///<remarks></remarks>
        public void Render(IRenderEngine renderEngine)
        {
            var position = GetPosition();
            renderEngine.Render(position, _imageFilename);
        }

        ///<summary>
        ///Each visual object should know it's position
        ///</summary>
        ///<remarks>Tightly coupled to type Point. This abstraction will constrict 3D rendering.</remarks>
        public abstract Point GetPosition();
    }
}
