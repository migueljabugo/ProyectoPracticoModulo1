using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProyectoPracticoModulo1_MiguelAngelGonzalez
{
    public static class GameServices
    {
        private const string NAME_FILE = "../../data.txt";
        private const string SEPARADOR = "*+*+*+*";

        private static List<Player> players;
        public static List<Player> Players
        {
            get { return players; }
        }

        private static List<Game> games;
        public static List<Game> Games
        {
            get { return games; }
        }

        public static void TestData()
        {
            Player player1 = new Player("Jugador1", "jugador1@email.com", Countries.Spain);
            Player player2 = new Player("Jugador2", "jugador2@email.com", Countries.Japan);
            Player player3 = new Player("Jugador3", "jugador3@email.com", Countries.USA);
            Player player4 = new Player("Jugador4", "jugador4@email.com", Countries.Italy);
            Player player5 = new Player("Jugador5", "jugador5@email.com", Countries.Germany);
            Player player6 = new Player("Jugador6", "jugador6@email.com", Countries.Spain);

            List<Score> listScore1 = new List<Score>() { new Score(player1.Nickname, 5), new Score(player2.Nickname, 5), new Score(player3.Nickname, 5), new Score(player4.Nickname, 5) };
            List<Score> listScore2 = new List<Score>() { new Score(player5.Nickname, 5), new Score(player6.Nickname, 5), new Score(player1.Nickname, 5) };
            List<Score> listScore3 = new List<Score>() { new Score(player1.Nickname, 5), new Score(player4.Nickname, 5) };

            Ranking ranking1 = new Ranking("Ranking1", listScore1);
            Ranking ranking2 = new Ranking("Ranking2", listScore2);
            Ranking ranking3 = new Ranking("Ranking3", listScore3);

            Dictionary<Platforms, Ranking> rankings = new Dictionary<Platforms, Ranking>();
            rankings.Add(Platforms.PC, ranking1);
            rankings.Add(Platforms.PS4, ranking2);
            rankings.Add(Platforms.Linux, ranking3);

            GameServices.games = new List<Game>() {
                new Game("Juego1", new List<Platforms>(){ Platforms.PC, Platforms.PS4}, 2000, rankings, Genres.Action),
                new Game("Juego2", new List<Platforms>(){ Platforms.PS4}, 2005, rankings, Genres.Puzzles),
                new Game("Juego3", new List<Platforms>(){ Platforms.PC}, 2017, rankings, Genres.Simulation) };

            GameServices.players = new List<Player>() { player1, player2, player3, player4, player5, player6 };
        }

        public static void Export()
        {
            string stringData = "";
            stringData += PlayersToString();
            stringData += SEPARADOR + "\n";
            stringData += GamesToString();
            stringData += SEPARADOR + "\n";
            stringData += GameRankingsPlayerToString();

            try
            {
                StreamWriter file = File.CreateText(NAME_FILE);
                file.WriteLine(stringData);
                file.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error al escribir el fichero.\n" + e);
            }
        }

        private static string GameRankingsPlayerToString()
        {
            string result = "";
            foreach (Game game in Games)
            {
                foreach (Platforms platform in game.Rankings.Keys)
                {
                    result += string.Format("{0}-{1}-", game.Name, game.Rankings[platform].Name);
                    foreach (Score score in game.Rankings[platform].Scores)
                    {
                        result += string.Format("{0}={1},", score.Nickname, score.Points);
                    }
                    result += "\n";
                }
            }
            return result;
        }

        private static string GamesToString()
        {
            string result = "";
            foreach (Game game in Games)
            {
                result += string.Format("{0}-{1}-{2}-", game.Name, (int)game.Genre, game.ReleaseDate);
                foreach (Platforms platform in game.Platform)
                {
                    result += string.Format("{0},", (int)platform);
                }
                result += "\n";
            }
            return result;
        }

        private static string PlayersToString()
        {
            string result = "";
            foreach (Player player in Players)
            {
                result += string.Format("{0}-{1}-{2}\n", player.Nickname, player.Email, (int)player.Country);
            }
            return result;
        }

        private static List<string> ReadFile()
        {
            List<string> linesFile = null;
            try
            {
                linesFile = new List<string>();
                StreamReader file = File.OpenText(NAME_FILE);
                string line = "";
                while (line != null)
                {
                    line = file.ReadLine();
                    if (line != null)
                    {
                        linesFile.Add(line);
                    }
                }
                file.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error al leer el fichero.\n" + e);
            }
            return linesFile;
        }


        public static void Import()
        {
            List<string> linesFile = ReadFile();
            List<Player> listPlayers = new List<Player>();
            List<Game> listGames = new List<Game>();
            int paso = 0;

            foreach (string line in linesFile)
            {
                if (line == SEPARADOR)
                {
                    paso++;
                }
                else
                {
                    switch (paso)
                    {
                        case 0:
                            listPlayers.Add(new Player(line));
                            break;
                        case 1:
                            listGames.Add(new Game(line));
                            break;
                        case 2:

                            break;
                        default:
                            break;
                    }
                }
            }
        }

        //Funciones
        /**
         * Funcion 1
         */
        public static Game OldestGame()
        {
            Game result = null;
            foreach (Game game in Games)
            {
                if (result == null || game.ReleaseDate < result.ReleaseDate)
                {
                    result = game;
                }
            }
            return result;
        }

        /**
         * Funcion 2
         */
        public static int ScoresOfRankingOfGame(string rankingName, string name)
        {
            int result = 0;
            foreach (Game game in Games)
            {
                if (game.Name == name)
                {
                    foreach (Platforms platform in game.Rankings.Keys)
                    {
                        if (rankingName == game.Rankings[platform].Name)
                        {
                            result++;
                        }

                    }
                }
            }
            return result;
        }

        /**
         * Funcion 3
         */
        public static int NumberOfGamesForGenre(string stringGenre)
        {
            int result = 0;
            foreach (Game game in Games)
            {
                if (game.Genre == (Genres)Enum.Parse(typeof(Genres), stringGenre))
                {
                    result++;
                }
            }
            return result;
        }

        /**
         * Funcion 4
         */
        public static Game GameWithMoreScores()
        {
            Game result = null;
            int moreScore = 0;
            foreach (Game game in Games)
            {
                foreach (Platforms platform in game.Rankings.Keys)
                {
                    if (result == null || game.Rankings[platform].Scores.Count > moreScore)
                    {
                        result = game;
                        moreScore = game.Rankings[platform].Scores.Count;
                    }
                }
            }
            return result;
        }

        /**
         * Funcion 5
         */
        public static bool existsOneGameWhitCall()
        {
            bool result = false;
            foreach (Game game in Games)
            {
                if (game.Name.Contains("Call"))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /**
         * Funcion 6
         */
        public static List<Game> ListOfGamesOfPlayer(Player player)
        {
            List<Game> gamesOfPlayer = new List<Game>();
            foreach (Game game in Games)
            {
                foreach (Platforms platform in game.Rankings.Keys)
                {
                    foreach (Score score in game.Rankings[platform].Scores)
                    {
                        if (score.Nickname == player.Nickname)
                        {
                            gamesOfPlayer.Add(game);
                        }
                    }
                }
            }
            return gamesOfPlayer;
        }

        /**
         * Funcion 7
         */
        public static Dictionary<Player, List<Game>> ListOfGamesOfPlayer()
        {
            Dictionary<Player, List<Game>> result = new Dictionary<Player, List<Game>>();
            foreach (Player player in Players)
            {
                foreach (Game game in Games)
                {
                    foreach (Platforms platform in game.Rankings.Keys)
                    {
                        foreach (Score score in game.Rankings[platform].Scores)
                        {
                            if (score.Nickname == player.Nickname)
                            {
                                if (result.ContainsKey(player))
                                {
                                    result[player].Add(game);
                                }
                                else
                                {
                                    result.Add(player, new List<Game>() { game });
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static void Console()
        {
            string line = "";
            while (line != "exit")
            {
                line = System.Console.ReadLine();
                line.ToLower();
                string[] comand = line.Split(' ');


                switch (comand[0])
                {
                    case "import":
                        Import();
                        break;
                    case "export":
                        Export();
                        break;
                    case "oldest":
                        System.Console.WriteLine(OldestGame());
                        break;
                    case "scorecount":
                        System.Console.WriteLine(ScoresOfRankingOfGame(comand[2], comand[1]));
                        break;
                    case "gamesCountbygenre":
                        System.Console.WriteLine(NumberOfGamesForGenre(comand[1]));
                        break;
                    case "gamesbyplayer":
                        string result = "";
                        Dictionary<Player, List<Game>> gamesByPlayer = ListOfGamesOfPlayer();
                        foreach (Player player in gamesByPlayer.Keys)
                        {
                            result += string.Format("->{0}:\n========> ", player.Nickname);
                            foreach (Game game in gamesByPlayer[player])
                            {
                                result += game.Name;
                            }
                            result += "\n";
                        }
                        break;
                    case "exit":
                        line = "exit";
                        break;
                    default:
                        break;
                }



            }
        }

    }
}
