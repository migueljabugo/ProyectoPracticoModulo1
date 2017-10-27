using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticoModulo1_MiguelAngelGonzalez
{
    public class Ranking
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Score> scores;
        public List<Score> Scores
        {
            get { return scores; }
        }

        public Ranking(string name, List<Score> scores)
        {
            this.name = name;
            this.scores = scores;
        }

        public override string ToString()
        {
            string result = string.Format("Ranking: {0}\n", Name);
            for (int i = 0; i < Scores.Count; i++)
            {
                result += string.Format("{0}. {1} - {2}\n", i+1, Scores[i].Nickname, Scores[i].Points);
            }

            return result;
        }

    }
}
