using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 坦克大战1._0版本.Properties;

namespace 坦克大战1._0版本
{
    class ZiDan:GameObject
    {
        private Image img;

        public Image Img
        {
            get => img;
            set => img = value;
        }
        public int Power
        {
            get;
            set;
        }

        public ZiDan(Tank tank,int speed,int life,int power,Image img ):base(tank.X+tank.Width/2-6,tank.Y+tank.Height/2-6,img.Width,img.Height,speed,life,tank.Dir)
        {
            this.img = img;
        }
        public override void Draw(Graphics g)
        {
            switch (this.Dir)
            {
                case Direction.up:
                    this.Y -= this.Speed;
                    break;
                case Direction.down:
                    this.Y += this.Speed;
                    break;
                case Direction.left:
                    this.X -= this.Speed;
                    break;
                case Direction.right:
                    this.X += this.Speed;
                    break;
            }
            if (this.X <= -10)
            {
                this.X = -100;
            }
            if (this.Y <= -10)
            {
                this.Y = -100;
            }
            if (this.X >= 1440)
            {
                this.X = 1500;
            }
            if (this.Y >= 1024)
            {
                this.Y = 1200;
            }
            g.DrawImage(img, this.X, this.Y);
        }

    }
}
