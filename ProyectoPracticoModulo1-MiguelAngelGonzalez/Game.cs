using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticoModulo1_MiguelAngelGonzalez
{
    public class Game
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private Genres genre;
        public Genres Genre
        {
            get { return genre; }
        }

        private List<Platforms> platform;
        public List<Platforms> Platform
        {
            get { return platform; }
        }

        private int releaseDate;
        public int ReleaseDate
        {
            get { return releaseDate; }
        }

        private Dictionary<Platforms, Ranking> rankings;
        public Dictionary<Platforms, Ranking> Rankings
        {
            get { return rankings; }
        }

        public Game(string name, List<Platforms> platforms, int releaseDate, Dictionary<Platforms, Ranking> rankings, Genres genre)
        {
            this.name = name;
            this.genre = genre;
            this.platform = platforms;
            this.releaseDate = (releaseDate >= 1980 && releaseDate <= 2018) ? releaseDate : -1;
            this.rankings = rankings;
        }

        public Game(string data)
        {
            string[] splittedData = data.Split('-');
            this.name = splittedData[0];
            this.genre = (Genres)int.Parse(splittedData[1]);
            this.releaseDate = int.Parse(splittedData[2]);

            string[] splittedPlatforms = splittedData[3].Split(',');
            this.platform = new List<Platforms>();
            foreach (string platformString in splittedPlatforms)
            {
                if (platformString != "")
                    this.platform.Add((Platforms)int.Parse(platformString));
            }
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Game)
            {
                Game aux = (Game)obj;
                if (this.Name == aux.Name)
                {
                    result = true;
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = string.Format("--- {0} ({1}) - ", Name, ReleaseDate);
            foreach (Platforms platform in Platform)
            {
                result += platform + ", ";
            }
            result += string.Format(" - {0} ---\n   Rankings:\n", Genre);
            foreach (Platforms platform in Rankings.Keys)
            {
                result += string.Format("       - {0} ({1})\n", Rankings[platform].Name, Rankings[platform].Scores);

            }
            return result;
        }

    }
}
