using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticoModulo1_MiguelAngelGonzalez
{
    public class Score
    {
        private string nickname;
        public string Nickname
        {
            get { return nickname; }
        }

        private int points;
        public int Points
        {
            get { return points; }
            set { points = (value>=0)? value: 0; }
        }

        public Score(string nickname, int points)
        {
            this.nickname = nickname;
            Points = points;
        }


    }
}
