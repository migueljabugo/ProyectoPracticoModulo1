using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticoModulo1_MiguelAngelGonzalez
{
    public class Player
    {
        private string nickname;
        public string Nickname
        {
            get { return nickname; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private Countries country;
        public Countries Country
        {
            get { return country; }
            set { country = value; }
        }

        public Player(string nickname, string email, Countries country)
        {
            this.nickname = nickname;
            Email = email;
            Country = country;
        }

        public Player(string data)
        {
            string[] splitterData = data.Split('-');
            this.nickname = splitterData[0];
            this.email = splitterData[1];
            this.Country = (Countries)int.Parse(splitterData[2]);
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Player)
            {
                Player aux = (Player)obj;
                if (this.nickname == aux.Nickname)
                {
                    result= true;
                }
            }
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Nickname, Email, Country);
        }



    }
}
