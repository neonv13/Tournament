using System.Collections.Generic;

namespace Tournament.Models
{
    public class TournamentList
    {
        public List<Tournaments> TournamentsList { get; set; }
        public int Count { get; set; }


        public TournamentList()
        {
            TournamentsList = new List<Tournaments>();
        }
        public void AddTournament(Tournaments tour)
        {
            if (FindTournamentByID(tour.ID) == null)
            {
                TournamentsList.Add(tour);
                Count++;
            }
        }
     
        public void RemoveTournament(int id)
        {
            if (FindTournamentByID(id) != null)
            {
                TournamentsList.Remove(FindTournamentByID(id));
                Count--;
            }
        }

        public Tournaments FindTournamentByID(int id)
        {
            foreach (var tour in TournamentsList)
            {
                if (tour.ID == id)
                    return tour;
            }
            return null;
        }
        public void SaveTournaments(string path)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(path);

            foreach (Tournaments tour in TournamentsList)
            {
                tour.SaveTournament(streamWriter);
            }
        }



    }
}


