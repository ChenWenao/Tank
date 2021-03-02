using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 坦克大战1._0版本.Properties;
using System.Drawing;

namespace 坦克大战1._0版本
{
    class ZhuangB : GameObject
    {
        private static Image imgStar = Resources.star;
        private static Image imgBomb = Resources.bomb;
        private static Image imgTimer = Resources.timer;

        public int zhuangb//0:五角星；1：地雷；2：冻结。
        {
            get;
            set;
        }

        //装备构造函数
        public ZhuangB(int x,int y,int type):base(x,y,imgStar.Width,imgStar.Height)
        {
            this.zhuangb = type;
        }

        //绘制装备图片
        public override void Draw(Graphics g)
        {
            switch(zhuangb)
            {
                case 0:
                    g.DrawImage(imgStar, this.X, this.Y);
                    break;
                case 1:
                    g.DrawImage(imgBomb, this.X, this.Y);
                    break;
                case 2:
                    g.DrawImage(imgTimer, this.X, this.Y);
                    break;
            }
        }
    }
}
