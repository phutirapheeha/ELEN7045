using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DodgerGame.Objects
{
    public class DodgerWorld : PictureBox
    {
        Bitmap buffer;

        List<VisualObject> _visualObjects;
        List<RainDrop> rain;
        Player player;

        const float playerSpeed = 10;
        const int numOfRaindrops = 8;
        const int rainSpacing = 100;

        Point playerStartingPoint = new Point(300, 390);

        const string _BackgrounImageName = @"Images\lanscape_2.png";  // Image drawn by Amani Reneilwe Masego Rapheeha (my daughter)

        const string _PlayerImageName = @"Images\dodger1.png";   // Image drawn by Amani Reneilwe Masego Rapheeha (my daughter)       
        const int _PlayerImageWidth = 102;
        const int _PlayerImageHeight = 148;

        const string _RainDropImageName = @"Images\rain2.png";  // Image drawn by Amani Reneilwe Masego Rapheeha (my daughter)
        const int _RainDropImageWidth = 30;
        const int _RainDropImageHeight = 42;
        Dictionary<string, int> _RainDropSpeedDictionary = new Dictionary<string,int>();

        public DodgerWorld(int width, int height)
            :base()
        {
            this.Width = width;
            this.Height = height;

            buffer = new Bitmap(width, height);

            rain = CreateRaindrops().ToList();
            player = CreatePlayer();

            _visualObjects = new List<VisualObject>();

            _visualObjects.Add(new Background(_BackgrounImageName));
            _visualObjects.AddRange(rain);
            _visualObjects.Add(player);

        }

        ///<summary>
        ///Creates RainDrops, and assigns each instance a random speed value into RainDropSpeedDictionary
        ///</summary>
        ///<remarks></remarks>
        private IEnumerable<RainDrop> CreateRaindrops()
        {
            var currSpace = 0;

            for (var r = 0; r < numOfRaindrops; r++)
            {
                var initialPosition = new Point(currSpace, 0);

                var rainDrop = new RainDrop(initialPosition, _RainDropImageName);
                _RainDropSpeedDictionary.Add(rainDrop.ID, GenerateObjectRandomSpeed());
                yield return rainDrop;

                currSpace += rainSpacing;
            }
        }

        private Player CreatePlayer()
        {
            return new Player(playerStartingPoint, _PlayerImageName);
        }

        ///<summary>
        ///Moves Player horizontally to the left by incrementing the X value of the Player position
        ///</summary>
        ///<remarks>Player position is incremented by a preset value playerSpeed.</remarks>
        public bool MovePlayerLeft()
        {
            float currentX = player.GetPosition().X;

            if ((currentX - playerSpeed) >= 0)
            {
                player.Move(new Point((int)(currentX - playerSpeed), player.GetPosition().Y));
            }
            else
                return false;

            return true;
        }

        ///<summary>
        ///Moves Player horizontally to the right by incrementing the X value of the Player position
        ///</summary>
        ///<remarks>Player position is incremented by a preset value playerSpeed.</remarks>
        public bool MovePlayerRight()
        {
            float currentX = player.GetPosition().X;
            var nextX = (currentX + playerSpeed);

            if ((currentX + playerSpeed) <= this.Width)
            {
                player.Move(new Point((int)nextX, player.GetPosition().Y));
            }
            else
                return false;

            return true;
        }

        ///<summary>
        ///Moves RainDrops vertically down by incrementing the Y value of the RainDrop position
        ///</summary>
        ///<remarks>Each RainDrops is incremented by a random value from  GenerateObjectRandomSpeed</remarks>
        public void DropRain()
        {
            foreach (var r in rain)
            {
                float currentY = r.GetPosition().Y;
                var nextYPosition = (currentY + _RainDropSpeedDictionary[r.ID]);

                bool dropReachedGround = !(nextYPosition <= this.Height);
                var p = !dropReachedGround
                        ? new Point(r.GetPosition().X, (int)(nextYPosition))
                        : new Point(r.GetPosition().X, 0);

                //Change rain drop speed when it restarts from the top
                if (dropReachedGround)
                    _RainDropSpeedDictionary[r.ID] = GenerateObjectRandomSpeed();

                r.Move(p);
            }
        }

        ///<summary>
        ///Uses IRenderEngine (GdiPlusRenderEngine) to draw all VisualObjects specified in the DodgerWorld
        ///</summary>
        ///<remarks></remarks>
        public void RenderWorld()
        {
            buffer.Dispose();
            buffer = new Bitmap(this.Width, this.Height);

            var renderEngine = new GdiPlusRenderEngine(buffer);

            foreach (var visualObject in _visualObjects)
            {
                visualObject.Render(renderEngine);
            }

            this.Image = buffer;
        }

        public override void Refresh()
        {
            base.Refresh();
            this.Image = null;
            RenderWorld();
        }

        ///<summary>
        ///Collision is determined by whether any of the RainDrop's image boundaries intersect with those of the player's image
        ///</summary>
        ///<remarks></remarks>
        public bool DetectCollision()
        {
            var playerPosition = player.GetPosition();
            int playerLowerBoundX = playerPosition.X;
            int playerUpperBoundX = playerLowerBoundX + _PlayerImageWidth;

            int playerLowerBoundY = playerPosition.Y;
            int playerUpperBoundY = playerLowerBoundY + _PlayerImageHeight;

            return rain.Any(r => (IsBetween(r.GetPosition().X, playerLowerBoundX, playerUpperBoundX)
                 && IsBetween(r.GetRightEndPosition(_RainDropImageWidth), playerLowerBoundX, playerUpperBoundX))
                 && IsBetween(r.GetPosition().Y, playerLowerBoundY, playerUpperBoundY)
                 && IsBetween(r.GetBottomEndPosition(_RainDropImageHeight), playerLowerBoundY, playerUpperBoundY));
        }


        ///<summary>
        ///Checks if a given value is within the given lower and higher bounds in int
        ///</summary>
        ///<remarks></remarks>
        private bool IsBetween(int value, int lowerBound, int upperBound)
        {
            return (value >= lowerBound) && (value <= upperBound);
        }

        ///<summary>
        ///Generates a random number between 5 and 15 which is than used as the RainDrop speed.
        ///</summary>
        ///<remarks>Ideally, this basically is the incremental value of a vertical RainDrop position</remarks>
        private int GenerateObjectRandomSpeed()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return rnd.Next(5, 15);
        }
    }
}
