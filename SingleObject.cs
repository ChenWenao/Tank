using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using 坦克大战1._0版本.Properties;

namespace 坦克大战1._0版本
{
    class SingleObject
    {
        #region 产生一个全局唯一的对象SingleObject
        private SingleObject()//封装全局唯一对象
        { }
        public static SingleObject _singleObject = null;
        public static SingleObject GetSingle()
        {
            if(_singleObject==null)
            {
                _singleObject = new SingleObject();
            }
            return _singleObject;
        }
        #endregion

        #region 产生唯一一个玩家对象
        public PlayerTank Player
        {
            get;
            set;
        }
        #endregion

        #region 游戏对象数组
        List<EnemyTank> listEnemyTank = new List<EnemyTank>();
        List<PZiDan> listPZiDan = new List<PZiDan>();
        List<CZiDan> listCZiDan = new List<CZiDan>();
        List<Boom> listBoom = new List<Boom>();
        List<TankBorn> listTankBorn = new List<TankBorn>();
        List<ZhuangB> listZhuangB = new List<ZhuangB>();
        List<Wall> listWall = new List<Wall>();
        #endregion

        #region 添加游戏对象
        public void AddGameObject(GameObject go)
        {
            //判断添加玩家对象
            if(go is PlayerTank)
            {
                Player = go as PlayerTank;
            }
            //判断添加敌人对象
            else if(go is EnemyTank)
            {
                listEnemyTank.Add(go as EnemyTank);
            }
            //判断添加玩家子弹对象
            else if(go is PZiDan)
            {
                listPZiDan.Add(go as PZiDan);
            }
            //判断添加敌人子弹对象
            else if (go is CZiDan)
            {
                listCZiDan.Add(go as CZiDan);
            }
            //判断添加爆炸效果对象
            else if (go is Boom)
            {
                listBoom.Add(go as Boom);
            }
            //判断添加坦克出生对象
            else if(go is TankBorn)
            {
                listTankBorn.Add(go as TankBorn);
            }
            //判断添加装备对象
            else if(go is ZhuangB)
            {
                listZhuangB.Add(go as ZhuangB);
            }
            //判断添加墙对象
            else if(go is Wall)
            {
                listWall.Add(go as Wall);
            }
        }
        #endregion

        #region 销毁游戏对象
        public void RemoveGameObject(GameObject go)
        {
            //判断销毁敌人坦克对象
            if(go is EnemyTank)
            {
                listEnemyTank.Remove(go as EnemyTank);
            }
            //判断销毁玩家子弹对象
            else if(go is PZiDan)
            {
                listPZiDan.Remove(go as PZiDan);
            }
            //判断销毁敌人子弹对象
            else if(go is CZiDan)
            {
                listCZiDan.Remove(go as CZiDan);
            }
            //判断销毁爆炸效果对象
            else if (go is Boom)
            {
                listBoom.Remove(go as Boom);
            }
            //判断销毁坦克出生对象
            else if(go is TankBorn)
            {
                listTankBorn.Remove(go as TankBorn);
            }
            //判断销毁装备对象
            else if (go is ZhuangB)
            {
                listZhuangB.Remove(go as ZhuangB);
            }
            //判断销毁墙对象
            else if (go is Wall)
            {
                listWall.Remove(go as Wall);
            }
        }
        #endregion

        #region 绘制对象
        public void Draw(Graphics g)
        {
            //绘制敌人坦克
            for (int i = 0; i < listEnemyTank.Count; i++)
            {
                listEnemyTank[i].Draw(g);
            }
            //绘制玩家子弹
            if (Player.Life != 0)
            {
                Player.Draw(g);
                for (int i = 0; i < listPZiDan.Count; i++)
                {
                    listPZiDan[i].Draw(g);
                }
            }
            //绘制敌人子弹
            for (int i = 0; i < listCZiDan.Count; i++)
            {
                listCZiDan[i].Draw(g);
            }
            //绘制爆炸效果
            for (int i = 0; i < listBoom.Count; i++)
            {
                listBoom[i].Draw(g);
            }
            //绘制坦克出生效果
            for (int i=0;i<listTankBorn.Count;i++)
            {
                listTankBorn[i].Draw(g);
            }
            //绘制装备
            for (int i = 0; i < listZhuangB.Count; i++)
            {
                listZhuangB[i].Draw(g);
            }
            //绘制墙
            for (int i = 0; i < listWall.Count; i++)
            {
                listWall[i].Draw(g);
            }
        }
        #endregion

        #region 碰撞检测
        public void PZJC()
        {
            //GetRectangle()方法：获得当前对象的矩形空间
            //IntersectsWith()方法：判断当前对象与参数对象的矩形空间是否重叠
            #region 判断玩家是否打中
            for (int i = 0; i < listPZiDan.Count; i++)
            {
                for (int j = 0; j < listEnemyTank.Count; j++)
                {

                    if (listPZiDan[i].GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle()))
                    {
                        listEnemyTank[j].Life -= listPZiDan[i].Power;
                        listEnemyTank[j].IsOver();
                        listPZiDan.Remove(listPZiDan[i]);//移除子弹
                        break;
                    }
                }
            }
            #endregion

            #region 判断玩家是否被打中
            for (int i = 0; i < listCZiDan.Count; i++)
            {
                if (listCZiDan[i].GetRectangle().IntersectsWith(Player.GetRectangle()))
                {
                    Player.Life--;
                    Player.IsOver();
                    //移除敌人子弹
                    listCZiDan.Remove(listCZiDan[i]);
                    break;
                }
            }
            #endregion

            #region 判断玩家是否吃到装备
            for(int i=0;i<listZhuangB.Count;i++)
            {
                //玩家吃到装备时
                if (listZhuangB[i].GetRectangle().IntersectsWith(Player.GetRectangle()))
                {
                    //判断吃到的装备类型并生效
                    JudgeZB(listZhuangB[i].zhuangb);

                    //移除当前装备
                    listZhuangB.Remove(listZhuangB[i]);

                    //给与装备反馈
                    SoundPlayer sp = new SoundPlayer(Resources.add);
                    sp.Play();
                }
            }
            #endregion

            #region 判断敌人是否撞到墙体
            Random r = new Random();
            for (int i = 0; i < listWall.Count; i++)
            {
                for (int j = 0; j < listEnemyTank.Count; j++)
                {
                    if (Player.GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle()))
                    {
                        //判断敌人从哪个方向撞过来的
                        switch (listEnemyTank[j].Dir)
                        {
                            case Direction.up:
                                listEnemyTank[j].Y += 1;
                                switch (r.Next(0, 3))
                                {
                                    case 0:
                                        listEnemyTank[j].Dir = Direction.left;
                                        break;
                                    case 1:
                                        listEnemyTank[j].Dir = Direction.down;
                                        break;
                                    case 2:
                                        listEnemyTank[j].Dir = Direction.right;
                                        break;
                                }
                                break;
                            case Direction.down:
                                listEnemyTank[j].Y -= 1;
                                switch (r.Next(0, 3))
                                {
                                    case 0:
                                        listEnemyTank[j].Dir = Direction.left;
                                        break;
                                    case 1:
                                        listEnemyTank[j].Dir = Direction.up;
                                        break;
                                    case 2:
                                        listEnemyTank[j].Dir = Direction.right;
                                        break;
                                }
                                break;
                            case Direction.left:
                                listEnemyTank[j].X += 1;
                                switch (r.Next(0, 3))
                                {
                                    case 0:
                                        listEnemyTank[j].Dir = Direction.up;
                                        break;
                                    case 1:
                                        listEnemyTank[j].Dir = Direction.down;
                                        break;
                                    case 2:
                                        listEnemyTank[j].Dir = Direction.right;
                                        break;
                                }
                                break;
                            case Direction.right:
                                listEnemyTank[j].X -= 1;
                                switch (r.Next(0, 3))
                                {
                                    case 0:
                                        listEnemyTank[j].Dir = Direction.left;
                                        break;
                                    case 1:
                                        listEnemyTank[j].Dir = Direction.down;
                                        break;
                                    case 2:
                                        listEnemyTank[j].Dir = Direction.up;
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
            #endregion

            #region 判断玩家是否打到了墙体
            for (int i = 0; i < listPZiDan.Count; i++)
            {
                for (int j = 0; j < listWall.Count; j++)
                {
                    if (listPZiDan[i].GetRectangle().IntersectsWith(listWall[j].GetRectangle()))
                    {
                        //移除子弹和墙体
                        listPZiDan.Remove(listPZiDan[i]);
                        listWall.Remove(listWall[j]);
                        SoundPlayer sp =new SoundPlayer(Resources.hit);
                        sp.Play();
                        break;
                    }
                }
            }
            #endregion

            #region 判断敌人是否打中了墙体
            for (int i = 0; i < listCZiDan.Count; i++)
            {
                for (int j = 0; j < listWall.Count; j++)
                {
                    if (listCZiDan[i].GetRectangle().IntersectsWith(listWall[j].GetRectangle()))
                    {
                        //移除子弹和墙体
                        listCZiDan.Remove(listCZiDan[i]);
                        listWall.Remove(listWall[j]);
                        SoundPlayer sp = new SoundPlayer(Resources.hit);
                        sp.Play();
                        break;
                    }
                }
            }
            #endregion

            #region 判断玩家敌人子弹是否相撞
            for (int i = 0; i < listPZiDan.Count; i++)
            {
                for (int j = 0; j < listCZiDan.Count; j++)
                {
                    if (listPZiDan[i].GetRectangle().IntersectsWith(listCZiDan[j].GetRectangle()))
                    {
                        listPZiDan.Remove(listPZiDan[i]);
                        listCZiDan.Remove(listCZiDan[j]);
                        break;
                    }
                }
            }
            #endregion

            #region 判断敌人是否和玩家发生相撞
            for (int j = 0; j < listEnemyTank.Count; j++)
            {
                if (Player.GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle()))
                {
                    //当敌人和墙体发生碰撞的时候 我们应该让敌人的坐标固定到
                    //碰撞的位置，不允许穿过墙体
                    //需要判断 敌人是从哪个方向过来发生碰撞的
                    switch (listEnemyTank[j].Dir)
                    {
                        case Direction.up:
                            listEnemyTank[j].Y += 5;
                            listEnemyTank[j].Y = Player.Y + Player.Height;
                            break;
                        case Direction.down:
                            listEnemyTank[j].Y -= 5;
                            listEnemyTank[j].Y = Player.Y - Player.Height;
                            break;
                        case Direction.left:
                            listEnemyTank[j].X += 5;
                            listEnemyTank[j].X = Player.X + Player.Width;
                            break;
                        case Direction.right:
                            listEnemyTank[j].X -= 5;
                            listEnemyTank[j].X = Player.X - Player.Width;
                            break;
                    }
                }
            }
            #endregion

            #region 判断玩家是否和敌人发生相撞
            for (int j = 0; j < listEnemyTank.Count; j++)
            {
                if (Player.GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle()))
                {
                    //当敌人和墙体发生碰撞的时候 我们应该让敌人的坐标固定到
                    //碰撞的位置，不允许穿过墙体
                    //需要判断 敌人是从哪个方向过来发生碰撞的
                    switch (Player.Dir)
                    {
                        case Direction.up:
                            Player.Y = listEnemyTank[j].Y + listEnemyTank[j].Height;
                            break;
                        case Direction.down:
                            Player.Y = listEnemyTank[j].Y - listEnemyTank[j].Height;
                            break;
                        case Direction.left:
                            Player.X = listEnemyTank[j].X + listEnemyTank[j].Width;
                            break;
                        case Direction.right:
                            Player.X = listEnemyTank[j].X - listEnemyTank[j].Width;
                            break;
                    }
                }
            }

            #endregion
        }

        //判断吃到的装备类型
        public void JudgeZB(int type)
        {
            switch(type)
            {
                //吃到的五角星
                case 0:
                    if(Player.ZDlev < 4)
                    {
                        Player.ZDlev++;
                    }
                    break;
                //吃到地雷
                case 1:
                    for (int i = 0; i < listEnemyTank.Count; i++)
                    {
                        listEnemyTank[i].Life = 0;
                        listEnemyTank[i].IsOver();
                    }
                    break;
                case 2:
                    for (int i = 0; i < listEnemyTank.Count; i++)
                    {
                        //让敌人暂停标记改为成立
                        listEnemyTank[i].IsStop = true;
                    }
                    break;
            }
        }
        #endregion
    }
}
