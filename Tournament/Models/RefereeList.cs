namespace Tournament.Models
{
    using System.Collections.Generic;

    public class RefereeList
    {
        public List<Referee> RefereesList { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// Initializes a new istance of RefereesList
        /// </summary>
        public RefereeList()
        {
            RefereesList = new List<Referee>();
        }

        public RefereeList(List<Referee> listreferee)
        {
            RefereesList = new List<Referee>();
            RefereesList = listreferee;
        }

        /// <summary>
        /// Adds Referee to RefereesList
        /// </summary>

        /// <summary>
        /// Retruns a instance of Referee that has given ID
        /// </summary>
        public Referee FindRefereeByID(int id)
        {
            foreach (var referee in RefereesList)
            {
                if (referee.ID == id)
                    return referee;
            }
            return null;
        }

        public void AddReferee(Referee referee)
        {
            RefereesList.Add(referee);
        }

        

        /// <summary>
        /// Retruns a instance of Player that has given ID
        /// </summary>
        public Referee FindRefeereByID(int id)
        {
            foreach (var referee in RefereesList)
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
            if (RefereesList.Contains(FindRefeereByID(id)))
            {
                RefereesList.Remove(FindRefeereByID(id));
            }
        }

        public void SaveRefereeList(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);

            foreach (var referee in RefereesList)
            {
                file.WriteLine("RefereeID: " + referee.ID);
                file.WriteLine("RefereeName: " + referee.Name);
                file.WriteLine("RefereeSurname: " + referee.Surname);
                file.WriteLine("EndReferee");
            }
            file.Close();

        }
        /// <summary>
        /// Loads RefereeList object from a specified file
        /// </summary>
        public void LoadRefereeList(string path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            
            int id = 0;
            string name = string.Empty;
            string surname = string.Empty;
            string text;
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
                                    Referee referee = new Referee(name, surname, null)
                                    {
                                        ID = id
                                    };
                                    RefereesList.Add(referee);
                                    Count++;
                                }
                                break;
                            }
                    }
                }
                file.Close();
            
        }
    }
}
