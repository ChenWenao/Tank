using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 坦克大战1._0版本.Properties;

namespace 坦克大战1._0版本
{
    class Wall:GameObject
    {
        private static Image img = Resources.wall;
        public Wall(int x,int y):base(x,y,img.Width,img.Height)
        {

        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.X, this.Y);
        }
    }
}
