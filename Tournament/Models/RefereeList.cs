using System.Windows.Documents;

namespace Tournament.Models
{
    using System.Collections.Generic;
    using System.Threading;

    public class RefereeList
    {

        private List<Referee> referees;
        private int count;

        /// <summary>
        /// Initializes a new istance of RefereesList
        /// </summary>
        public RefereeList()
        {
            referees = new List<Referee>();
        }
        /// <summary>
        /// Gets Refrees List value
        /// </summary>
        public List<Referee> RefereesList { get => referees; }

        /// <summary>
        /// Adds Referee to RefereesList
        /// </summary>

        public void AddReferee(Referee referee)
        {
            RefereesList.Add(referee);
        }

        /// <summary>
        /// Initializes a Count
        /// </summary>
        private int Count { get => count; set => count = value; }

        /// <summary>
        /// Retruns a instance of Player that has given ID
        /// </summary>
        public Referee FindRefeereByID(int id)
        {
            foreach (var referee in referees)
            {
                if (referee.ID == id)
                    return referee;
            }
            return null;
        }

        /// <summary>
        /// Removes Referee from RefereesList by ID
        /// </summary>
        public void RemoveReferee(int id)
        {
            foreach (var referee in referees)
            {
                if (referee.ID == id)
                {
                    RefereesList.Remove(referee);
                }
            }
        }

        /// <summary>
        /// Removes Referee from RefereesList by Surname and Name
        /// </summary>
        public void RemoveReferee(string surName, string name)
        {
            foreach (var referee in referees)
            {
                if (referee.Surname == surName && referee.Name == name)
                {
                    RefereesList.Remove(referee);
                }
            }
        }

        public void SaveRefereeList(string path)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach (var referee in RefereesList)
                {
                    file.WriteLine("RefereeID: " + referee.ID);
                    file.WriteLine("RefereeName: " + referee.Name);
                    file.WriteLine("RefereeSurname: " + referee.Surname);
                    file.WriteLine("EndReferee");
                }
                file.Close();
            }
        }
        /// <summary>
        /// Loads RefereeList object from a specified file
        /// </summary>
        public RefereeList LoadRefereeList(string path)
        {
            RefereeList refereeList = new RefereeList();
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                int id = 0;
                string name = string.Empty;
                string surname = string.Empty;
                string text = string.Empty;
                while ((text = file.ReadLine()) != null && text != "EndReferees")
                {
                    string[] words = text.Split(" ");
                    switch (words[0])
                    {
                        case "RefereeID:":
                            {
                                id = int.Parse(words[1]);
                                break;
                            }
                        case "RefereeName:":
                            {
                                name = words[1];
                                break;
                            }
                        case "RefereeSurname:":
                            {
                                surname = words[1];
                                break;
                            }
                        case "EndReferee":
                            {
                                if (id != 0 && name != string.Empty && surname != string.Empty)
                                {
                                    Referee referee = new Referee(name, surname, null);
                                    referee.ID = id;
                                    refereeList.AddReferee(referee);
                                }
                                break;
                            }
                    }
                }
                file.Close();
            }
            return refereeList;
        }
    }
}
