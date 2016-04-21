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

        public virtual Point GetCurrentPoint()
        {
            return _position;
        }

        public virtual void Move(Point newPosition)
        {
            _position = newPosition;
        }

        protected override Point GetPosition()
        {
            return _position;
        }
    }

    public abstract class VisualObject
    {
        private readonly string _imageFilename;

        protected VisualObject(string imageFilename)
        {
            _imageFilename = imageFilename;
        }

        public void Render(IRenderEngine renderEngine)
        {
            var position = GetPosition();
            renderEngine.Render(position, _imageFilename);
        }

        protected abstract Point GetPosition();
    }

    public interface IRenderEngine
    {
        void Render(Point position, string imageFilename);
    }

    public class GdiPlusRenderEngine : IRenderEngine
    {
        private readonly Graphics _bufferSurface;

        public GdiPlusRenderEngine(Image buffer)
        {
            _bufferSurface = Graphics.FromImage(buffer);
        }
        public void Render(Point position, string imageFilename)
        {
            var image = new Bitmap(imageFilename);

            _bufferSurface.DrawImage(image, position);
        }
    }
}
