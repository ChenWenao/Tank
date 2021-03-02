using System.Drawing;
using System.Media;
using System.Windows.Forms;
using 坦克大战1._0版本.Properties;

namespace 坦克大战1._0版本
{
    class PlayerTank:Tank
    {
        private static Image[] imgs = {
            Resources.p1tankU,
            Resources.p1tankD,
            Resources.p1tankL,
            Resources.p1tankR
        };
        public PlayerTank(int x,int y,int speed,int life,Direction dir):base(x,y,imgs,speed,life,dir)
        {
            Born();
        }

        //声明玩家的子弹等级
        public int ZDlev
        {
            get;
            set;
        }

        //玩家按键操作
        public void KeyDown(KeyEventArgs e)
        {
            if (this.Life > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        this.Dir = Direction.up;
                        base.Move();
                        break;
                    case Keys.S:
                        this.Dir = Direction.down;
                        base.Move();
                        break;
                    case Keys.A:
                        this.Dir = Direction.left;
                        base.Move();
                        break;
                    case Keys.D:
                        this.Dir = Direction.right;
                        base.Move();
                        break;
                    case Keys.Space:
                        Fire();
                        break;
                }
            }
        }

        //玩家开火
        public override void Fire()
        {
            if (this.Life > 0)
            {
                switch (ZDlev)
                {
                    case 0:
                        SingleObject.GetSingle().AddGameObject(new PZiDan(this, 7, 10, 1));//一级玩家子弹的属性：速度，生命，伤害
                        break;
                    case 1:
                        SingleObject.GetSingle().AddGameObject(new PZiDan(this, 9, 10, 2));//二级玩家子弹的属性：速度，生命，伤害
                        break;
                    case 2:
                        SingleObject.GetSingle().AddGameObject(new PZiDan(this, 11, 10, 3));//三级玩家子弹的属性：速度，生命，伤害
                        break;
                    case 3:
                        SingleObject.GetSingle().AddGameObject(new PZiDan(this, 13, 10, 4));//四级玩家子弹的属性：速度，生命，伤害
                        break;
                    case 4:
                        SingleObject.GetSingle().AddGameObject(new PZiDan(this, 15, 10, 5));//五级玩家子弹的属性：速度，生命，伤害
                        break;
                }
            }
        }

        //判断玩家是否死亡
        public override void IsOver()
        {
            if (this.Life <= 0)
            {
                SingleObject.GetSingle().AddGameObject(new Boom(this.X - 25, this.Y - 25));
            }
            else
            {
                SoundPlayer sp = new SoundPlayer(Resources.hit);
                sp.Play();
            }
        }

        //玩家坦克出生
        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X, this.Y));
        }
    }
}
