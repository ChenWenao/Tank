using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 坦克大战1._0版本.Properties;

namespace 坦克大战1._0版本
{
    class CZiDan:ZiDan
    {
        private static Image img = Resources.enemymissile;

        public CZiDan(Tank tank, int speed, int life, int power) : base(tank, speed, life, power, img)
        {

        }
    }
}
