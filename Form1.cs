using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 坦克大战1._0版本.Properties;

namespace 坦克大战1._0版本
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();//初始化窗口
            InitialGame();//初始化游戏
        }

        //玩家设置
        private void InitialGame()
        {
            //设置玩家初始位置，属性
            //对应：X,Y,速度，生命，方向
            SingleObject.GetSingle().AddGameObject(new PlayerTank(720, 924, 6, 10, Direction.up));
            SetEnemyTanks();
            InitialMap();
        }
        Random r = new Random();//产生随机数

        //敌人设置
        public void SetEnemyTanks()
        {
            for (int i = 0; i < 12; i++)//设置敌人坦克初数量
            {
                SingleObject.GetSingle().AddGameObject(new EnemyTank(r.Next(0, this.Width), r.Next(0, this.Height), r.Next(0, 3), Direction.down));
            }
        }

        //初始化地图坐标
        public void InitialMap()
        {
            for (int i = 0; i < 10; i++)
            {
                SingleObject.GetSingle().AddGameObject(new Wall(i * 15 + 30, 100));
                SingleObject.GetSingle().AddGameObject(new Wall(95, 100 + 15 * i));

                SingleObject.GetSingle().AddGameObject(new Wall(245 - i * 7, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(245 + i * 7, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(215 + i * 15 / 2, 185));

                SingleObject.GetSingle().AddGameObject(new Wall(390 - i * 5, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(390 + i * 5, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(480 - i * 5, 100 + 15 * i));

                SingleObject.GetSingle().AddGameObject(new Wall(515, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(595 - i * 8, 100 + 15 * i / 2));
                SingleObject.GetSingle().AddGameObject(new Wall(530 + i * 8, 165 + 15 * i / 2));
            }

        }

        //程序加载
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            //消除画面闪烁
            SoundPlayer sp = new SoundPlayer(Resources.start);
            sp.Play();
        }

        // 初始化游戏，绘制游戏画面
        private void Form1_Paint(object sender, PaintEventArgs e)//sender:触发事件的条件；e：该事件需要的资源。
        {
            SingleObject.GetSingle().Draw(e.Graphics);
        }

        // 按下键盘触发
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().Player.KeyDown(e);
        }

        //窗体更新
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            SingleObject.GetSingle().PZJC();//碰撞检测
        }
    }
}
