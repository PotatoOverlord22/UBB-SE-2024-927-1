﻿using GameWorldClassLibrary.Models;
using GameWorldClassLibrary.Utils;
using Newtonsoft.Json;

namespace GameWorldClassLibrary.Repositories
{
    public class GameStore
    {
        public static Dictionary<string, Games> Games { get; } = InitializeGamesFromDatabase();

        private static Dictionary<string, Games> InitializeGamesFromDatabase()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync($"{Apis.TWO_PLAYER_GAMES_BASE_URL}/GetGames").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var games = JsonConvert.DeserializeObject<List<Games>>(response.Content.ReadAsStringAsync().Result);
                        return games.ToDictionary(x => x.Name);
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve games from the database");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Failed to retrieve games from the database", e);
                }
            }
        }

        public static Games GetGameById(Guid id)
        {
            return Games.Values.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
