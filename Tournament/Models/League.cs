using System.Windows.Documents;
using System.Collections.Generic;

namespace Tournament.Models
{
    class League {


        private MatchList matchesPlanned;
        /// <summary>
        /// Initializes a League instance
        /// </summary>
        public League(TeamList teams, RefereeList referees, GameType gameType, MatchRank matchRank)
        {
            if (teams.TeamsList.Count >= 2)
            {
                MatchesPlanned = new MatchList();
                int i = 0;
                int j;
                Match match;
                foreach (var teamA in teams.TeamsList)
                {
                    j = 0;
                    foreach (var teamB in teams.TeamsList)
                    {
                        if (j > i)
                        {
                            match = new Match(
                                teamA, teamB, referees,
                                matchRank, teamA.IdTeam, teamB.IdTeam, gameType,
                                MatchesPlanned.GetMatchList);
                            MatchesPlanned.AddMatch(match);
                        }
                        j++;
                    }
                    i++;

                }
            }
        }

        internal MatchList MatchesPlanned { get => matchesPlanned; set => matchesPlanned = value; }

        /// <summary>
        /// Return IEnumerable<Match> value of symulated matches
        /// </summary>
        public IEnumerable<Match> SymulateLeague()
        {
            foreach (var match in MatchesPlanned.GetMatchList)
            {
                match.SymulateGame();
                Match copy = new Match(match);
                MatchesPlanned.RemoveMatch(match);
                yield return copy;
            }
        }




    }
}
