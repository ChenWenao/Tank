using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战1._0版本
{
    abstract class Tank : GameObject
    {
        private Image[] imgs = new Image[] {};
        public Tank(int x,int y,Image[] imgs,int speed,int life,Direction dir):base(x,y,imgs[0].Width,imgs[0].Height,speed,life,dir)
        {
            this.imgs = imgs;
        }

        //开火方法
        public abstract void Fire();

        //判断死亡方法
        public abstract void IsOver();

        //出生方法
        public abstract void Born();

        //绘制方法
        public int BornTime = 0;
        public bool IsMove = false;
        public override void Draw(Graphics g)
        {
            BornTime++;
            if (BornTime % 20 == 0)
            {
                IsMove = true;
            }
            if (IsMove==true)
            {
                switch (this.Dir)
                {
                    case Direction.up:
                        g.DrawImage(imgs[0], this.X, this.Y);
                        break;
                    case Direction.down:
                        g.DrawImage(imgs[1], this.X, this.Y);
                        break;
                    case Direction.left:
                        g.DrawImage(imgs[2], this.X, this.Y);
                        break;
                    case Direction.right:
                        g.DrawImage(imgs[3], this.X, this.Y);
                        break;
                }
            }
        }
    }
}
