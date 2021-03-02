using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 坦克大战1._0版本.Properties;

namespace 坦克大战1._0版本
{
    class Boom:GameObject
    {
        private Image[] imgs =
        {
            Resources.blast1,
            Resources.blast2,
            Resources.blast3,
            Resources.blast4,
            Resources.blast5,
            Resources.blast6,
            Resources.blast7,
            Resources.blast8,
            Resources.blast7,
            Resources.blast6,
            Resources.blast5,
            Resources.blast4,
            Resources.blast3,
            Resources.blast2,
            Resources.blast1,
        };
        public Boom(int x,int y):base(x,y)
        {
            
        }

        #region 爆炸效果绘制
        int time = 0;
        public override void Draw(Graphics g)
        {
            time++;
            switch(time%15)
            {
                case 1:
                    g.DrawImage(imgs[0], this.X, this.Y);
                    break;
                case 3:
                    g.DrawImage(imgs[1], this.X, this.Y);
                    break;
                case 5:
                    g.DrawImage(imgs[2], this.X, this.Y);
                    break;
                case 7:
                    g.DrawImage(imgs[3], this.X, this.Y);
                    break;
                case 9:
                    g.DrawImage(imgs[4], this.X, this.Y);
                    break;
                case 11:
                    g.DrawImage(imgs[5], this.X, this.Y);
                    break;
                case 13:
                    g.DrawImage(imgs[6], this.X, this.Y);
                    break;
                case 15:
                    g.DrawImage(imgs[7], this.X, this.Y);
                    break;
                case 17:
                    g.DrawImage(imgs[6], this.X, this.Y);
                    break;
                case 19:
                    g.DrawImage(imgs[5], this.X, this.Y);
                    break;
                case 21:
                    g.DrawImage(imgs[4], this.X, this.Y);
                    break;
                case 23:
                    g.DrawImage(imgs[3], this.X, this.Y);
                    break;
                case 25:
                    g.DrawImage(imgs[2], this.X, this.Y);
                    break;
                case 27:
                    g.DrawImage(imgs[1], this.X, this.Y);
                    break;
                case 29:
                    g.DrawImage(imgs[0], this.X, this.Y);
                    break;
            }
            if (time % 40 == 0)
            {
                SingleObject.GetSingle().RemoveGameObject(this);
            }
        }
        #endregion
    }
}
