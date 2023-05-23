using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Mirror;
using UnityEngine;

namespace MirrorBasics
{

    [System.Serializable]
    public class Match
    {
        public string matchID;
        public bool publicMatch;
        public bool inMatch;
        public bool matchFull;
        public List<Player> players = new List<Player>();
        public bool isNetworkObjectsSpawn = false;

        public Match(string matchID, Player player, bool publicMatch)
        {
            matchFull = false;
            inMatch = false;
            this.matchID = matchID;
            this.publicMatch = publicMatch;
            players.Add(player);
        }

        public Match() { }
    }

    public class MatchMaker : NetworkBehaviour
    {

        public static MatchMaker Instance;

        private readonly SyncList<Match> _matches = new ();
        private readonly SyncList<String> _matchIDs = new ();

        [SerializeField] int maxMatchPlayers = 2;

        void Start()
        {
            Instance = this;
        }

        public bool HostGame(string _matchID, Player _player, bool publicMatch, out int playerIndex)
        {
            playerIndex = -1;

            if (!_matchIDs.Contains(_matchID))
            {
                _matchIDs.Add(_matchID);
                Match match = new Match(_matchID, _player, publicMatch);
                _matches.Add(match);
                Debug.Log($"Match generated");
                _player.currentMatch = match;
                playerIndex = 1;
                return true;
            }
            else
            {
                Debug.Log($"Match ID already exists");
                return false;
            }
        }

        public bool JoinGame(string _matchID, Player _player, out int playerIndex)
        {
            playerIndex = -1;

            if (_matchIDs.Contains(_matchID))
            {

                for (int i = 0; i < _matches.Count; i++)
                {
                    if (_matches[i].matchID == _matchID)
                    {
                        if (!_matches[i].inMatch && !_matches[i].matchFull)
                        {
                            _matches[i].players.Add(_player);
                            _player.currentMatch = _matches[i];
                            playerIndex = _matches[i].players.Count;

                            _matches[i].players[0].PlayerCountUpdated(_matches[i].players.Count);

                            if (_matches[i].players.Count == maxMatchPlayers)
                            {
                                _matches[i].matchFull = true;
                            }

                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                Debug.Log($"Match joined");
                return true;
            }
            else
            {
                Debug.Log($"Match ID does not exist");
                return false;
            }
        }

        public bool SearchGame(Player _player, out int playerIndex, out string matchID)
        {
            playerIndex = -1;
            matchID = "";

            foreach (var match in _matches)
            {
                Debug.Log($"Checking match {match.matchID} | inMatch {match.inMatch} | matchFull {match.matchFull} | publicMatch {match.publicMatch}");
                if (!match.inMatch && !match.matchFull && match.publicMatch)
                {
                    if (JoinGame(match.matchID, _player, out playerIndex))
                    {
                        matchID = match.matchID;
                        return true;
                    }
                }
            }

            return false;
        }

        public void BeginGame(string _matchID)
        {
            for (int i = 0; i < _matches.Count; i++)
            {
                if (_matches[i].matchID == _matchID)
                {
                    _matches[i].inMatch = true;
                    foreach (var player in _matches[i].players)
                    {
                        player.StartGame();
                    }
                    break;
                }
            }
        }

        public static string GetRandomMatchID()
        {
            string _id = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                int random = UnityEngine.Random.Range(0, 36);
                if (random < 26)
                {
                    _id += (char)(random + 65);
                }
                else
                {
                    _id += (random - 26).ToString();
                }
            }
            Debug.Log($"Random Match ID: {_id}");
            return _id;
        }

        public void PlayerDisconnected(Player player, string _matchID)
        {
            for (int i = 0; i < _matches.Count; i++)
            {
                if (_matches[i].matchID == _matchID)
                {
                    int playerIndex = _matches[i].players.IndexOf(player);
                    if (_matches[i].players.Count > playerIndex) _matches[i].players.RemoveAt(playerIndex);
                    Debug.Log($"Player disconnected from match {_matchID} | {_matches[i].players.Count} players remaining");

                    if (_matches[i].players.Count == 0)
                    {
                        Debug.Log($"No more players in Match. Terminating {_matchID}");
                        _matches.RemoveAt(i);
                        _matchIDs.Remove(_matchID);
                    }
                    else
                    {
                        _matches[i].players[0].PlayerCountUpdated(_matches[i].players.Count);
                    }
                    break;
                }
            }
        }

    }

    public static class MatchExtensions
    {
        public static Guid ToGuid(this string id)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] inputBytes = Encoding.Default.GetBytes(id);
            byte[] hashBytes = provider.ComputeHash(inputBytes);

            return new Guid(hashBytes);
        }
    }

}