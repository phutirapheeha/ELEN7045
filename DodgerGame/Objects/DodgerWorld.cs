using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DodgerGame.Objects
{
    public class DodgerWorld
    {
        public PictureBox dodgerWorld;
        private const int _height = 600;
        private const int _width = 800;

        Bitmap buffer;
        Dictionary<string, Bitmap> _movableObjects;
        Bitmap playerImg;
        Bitmap[] dropImagse;

        List<VisualObject> _visualObjects;
        Background _background;
        List<RainDrop> rain;
        Player player;

        const float playerSpeed = 10;
        const int numOfRaindrops = 8;
        const int rainSpacing = 90;

        Point playerStartingPoint = new Point(300, 470);

        public DodgerWorld()
        {
            dodgerWorld = new PictureBox();
            dodgerWorld.Height = _height;
            dodgerWorld.Width = _width;


            rain = CreateRaindrops().ToList();
            player = CreatePlayer();

            buffer = new Bitmap(_width, _height);

            _visualObjects = new List<VisualObject>();

            _visualObjects.Add(new Background("farm.png"));
            _visualObjects.AddRange(rain);
            _visualObjects.Add(player);

        }

        private IEnumerable<RainDrop> CreateRaindrops()
        {
            var currSpace = 0;

            for (var r = 0; r < numOfRaindrops; r++)
            {
                var initialPosition = new Point(currSpace, 0);

                var rainDrop = new RainDrop(initialPosition, "rain2.png");

                yield return rainDrop;

                currSpace += rainSpacing;
            }
        }

        private Player CreatePlayer()
        {
            return new Player(playerStartingPoint, "small-jack-left1.png");
        }

        public bool MovePlayerLeft()
        {
            Point p;
            float currentX = player.GetCurrentPoint().X;

            if ((currentX - playerSpeed) >= 0)
            {
                player.Move(new Point((int)(currentX - playerSpeed), player.GetCurrentPoint().Y));
            }
            else
                return false;

            return true;
        }

        public bool MovePlayerRight()
        {
            Point p;
            float currentX = player.GetCurrentPoint().X;
            var nextX = (currentX + playerSpeed);


            if ((currentX + playerSpeed) <= _width)
            {
                player.Move(new Point((int)nextX, player.GetCurrentPoint().Y));
            }
            else
                return false;

            return true;
        }

        public void DropRain()
        {
            foreach (var r in rain)
            {
                var speed = GenerateObjectRandomSpeed();
                float currentY = r.GetCurrentPoint().Y;
                var nextPos = (currentY + speed);

                var p = nextPos <= dodgerWorld.Height
                        ? new Point(r.GetCurrentPoint().X, (int)(nextPos)) 
                        : new Point(r.GetCurrentPoint().X, 0);

                r.Move(p);
            }
        }

        public void RenderWorld()
        {
            buffer.Dispose();
            buffer = new Bitmap(_width, _height);

            var renderEngine = new GdiPlusRenderEngine(buffer);

            foreach (var visualObject in _visualObjects)
            {
                visualObject.Render(renderEngine);
            }

            dodgerWorld.Image = null;
            dodgerWorld.Image = buffer;
        }

        private int GenerateObjectRandomSpeed()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return rnd.Next(0, 20);
        }
    }
}
