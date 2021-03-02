using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 坦克大战1._0版本.Properties;

namespace 坦克大战1._0版本
{
    class PZiDan:ZiDan
    {
        private static Image img = Resources.tankmissile;

        public PZiDan(Tank tank, int speed, int life,  int power) : base(tank, speed, life, power, img)
        {
            this.Power = power;
        }
    }
}
是