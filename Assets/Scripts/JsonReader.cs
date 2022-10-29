using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{

    public string textJSON;

    [System.Serializable]
    public class Leaderboard
    {
        public string _id;
        public string wallet_address;
        public int coins;
        public int max_coins;
        public DateTime createdAt;
        public DateTime updatedAt;
    }

    [System.Serializable]
    public class LeaderboardList
    {
        public bool success;
        public List<Leaderboard> leaderboard = new List<Leaderboard>();
    }

    public LeaderboardList myLeaderboardList;

    void Start()
    {
        Debug.Log("..>\n" + textJSON);
        myLeaderboardList = JsonUtility.FromJson<LeaderboardList>(textJSON);
        // ClassObject  = jsonutility.fomjson<className>(ReceivedJson);
    }
}
