using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战1._0版本
{
    enum Direction
    {
        up,
        down,
        left,
        right
    }

    abstract class GameObject
    {
        #region 对象属性的声明
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set; 
        }
        public int Width
        {
            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public int Life
        {
            get;
            set;
        }
        public Direction Dir
        {
            get;
            set;
        }
        #endregion
        #region 对象的构造函数
        public GameObject(int x,int y):this(x,y,0,0,0,0,0)
        {

        }
        public GameObject(int x,int y,int width,int height):this(x,y,width,height,0,0,0)
        {

        }
        public GameObject(int x,int y,int width,int height,int speed,int life,Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Life = life;
            this.Dir = dir;
        }
        #endregion
        public abstract void Draw(Graphics g);
        public virtual void Move()
        {
            switch(this.Dir)
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
            if(this.X<=0)
            {
                this.X = 0;
            }
            if (this.Y <= 0)
            {
                this.Y = 0;
            }
            if(this.X >= 1360)
            {
                this.X = 1360;
            }
            if(this.Y>=924)
            {
                this.Y = 924;
            }
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
    }
}
