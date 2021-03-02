using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 坦克大战1._0版本.Properties;
using System.Media;

namespace 坦克大战1._0版本
{
    class EnemyTank : Tank
    {
        #region 属性声明
        private static Image[] imgs1 =
        {
            Resources.enemy1U,
            Resources.enemy1D,
            Resources.enemy1L,
            Resources.enemy1R
        };
        //轻坦图片
        private static Image[] imgs2 =
        {
            Resources.enemy2U,
            Resources.enemy2D,
            Resources.enemy2L,
            Resources.enemy2R
        };
        //中坦图片
        private static Image[] imgs3 =
        {
            Resources.enemy3U,
            Resources.enemy3D,
            Resources.enemy3L,
            Resources.enemy3R
        };
        //重坦图片
        private static int _speed;
        private static int _life;
        public int TankType
        {
            get;
            set;
        }
        #endregion
        //设置敌人速度方法
        public static int SetSpeed(int type)
        {
            switch (type)
            {
                case 0:
                    _speed = 3;
                    break;
                case 1:
                    _speed = 2;
                    break;
                case 2:
                    _speed = 1;
                    break;
            }
            return _speed;
        }
        //设置敌人生命方法
        public static int SetLife(int type)
        {
            switch (type)
            {
                case 0:
                    _life = 2;
                    break;
                case 1:
                    _life = 3;
                    break;
                case 2:
                    _life = 5;
                    break;
            }
            return _life;
        }

        //敌人坦克构造方法
        public EnemyTank(int x, int y, int type, Direction dir): base(x, y, imgs1, SetSpeed(type), SetLife(type), dir)
        {
            this.TankType = type;
            Born();
        }

        //敌人移动
        static Random r = new Random();
        public override void Move()
        {
            base.Move();
            if (r.Next(0, 200) < 5)
            {
                switch (r.Next(0, 4))
                {
                    case 0:
                        this.Dir = Direction.up;
                        break;
                    case 1:
                        this.Dir = Direction.down;
                        break;
                    case 2:
                        this.Dir = Direction.left;
                        break;
                    case 3:
                        this.Dir = Direction.right;
                        break;
                }
            }
        }

        //敌人开火
        public override void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new CZiDan(this, 4, 10, 1));//敌人子弹属性：速度，生命，伤害
        }

        //判断敌人是否死亡
        public override void IsOver()
        {
            if (this.Life == 0)//敌人死亡
            {
                //调用爆炸方法
                SingleObject.GetSingle().AddGameObject(new Boom(this.X - 25, this.Y - 25));
                
                //清除此坦克
                SingleObject.GetSingle().RemoveGameObject(this);
                
                //播放爆炸声音
                SoundPlayer sp = new SoundPlayer(Resources.fire);
                sp.Play();

                //几率刷出新的敌人坦克
                if(r.Next(0,100)>=40)//刷新敌人概率：100-60
                {
                    SingleObject.GetSingle().AddGameObject(new EnemyTank(r.Next(0, 1360), r.Next(0, 924), r.Next(0, 3), Direction.down));
                }
                
                //几率刷出装备
                if(r.Next(0,100)>=95)//刷出装备概率：100-75
                {
                    SingleObject.GetSingle().AddGameObject(new ZhuangB(this.X, this.Y, 0));
                }
                if (r.Next(0, 100) >= 98)//刷出装备概率：100-75
                {
                    SingleObject.GetSingle().AddGameObject(new ZhuangB(this.X, this.Y, 1));
                }
                if (r.Next(0, 100) >= 85)//刷出装备概率：100-75
                {
                    SingleObject.GetSingle().AddGameObject(new ZhuangB(this.X, this.Y, 2));
                }
            }
            else//敌人未死亡
            {
                SoundPlayer sp = new SoundPlayer(Resources.hit);
                sp.Play();
            }
        }

        //敌人坦克出生
        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X, this.Y));
        }

        //绘制敌人坦克
        public bool IsStop = false;
        public int StopTime = 0;
        public override void Draw(Graphics g)
        {
            BornTime++;
            if (BornTime%20==0)
            {
                IsMove = true;
            }
            if (IsMove == true)
            {
                if (IsStop == false)
                {
                    Move();
                }
                else
                {
                    StopTime++;
                    if(StopTime==350)//冻结技能冻结的时间：200
                    {
                        IsStop = false;
                    }
                }
                switch (TankType)
                {
                    case 0:
                        switch (this.Dir)
                        {
                            case Direction.up:
                                g.DrawImage(imgs1[0], this.X, this.Y);
                                break;
                            case Direction.down:
                                g.DrawImage(imgs1[1], this.X, this.Y);
                                break;
                            case Direction.left:
                                g.DrawImage(imgs1[2], this.X, this.Y);
                                break;
                            case Direction.right:
                                g.DrawImage(imgs1[3], this.X, this.Y);
                                break;
                        }
                        break;
                    case 1:
                        switch (this.Dir)
                        {
                            case Direction.up:
                                g.DrawImage(imgs2[0], this.X, this.Y);
                                break;
                            case Direction.down:
                                g.DrawImage(imgs2[1], this.X, this.Y);
                                break;
                            case Direction.left:
                                g.DrawImage(imgs2[2], this.X, this.Y);
                                break;
                            case Direction.right:
                                g.DrawImage(imgs2[3], this.X, this.Y);
                                break;
                        }
                        break;
                    case 2:
                        switch (this.Dir)
                        {
                            case Direction.up:
                                g.DrawImage(imgs3[0], this.X, this.Y);
                                break;
                            case Direction.down:
                                g.DrawImage(imgs3[1], this.X, this.Y);
                                break;
                            case Direction.left:
                                g.DrawImage(imgs3[2], this.X, this.Y);
                                break;
                            case Direction.right:
                                g.DrawImage(imgs3[3], this.X, this.Y);
                                break;
                        }
                        break;
                }
                if (r.Next(0, 100) <1)//设置敌人子弹发射频率
                {
                    if (IsStop ==false)
                    {
                        Fire();
                    }
                }
            }
        }
    }
}
