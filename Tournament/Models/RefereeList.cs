namespace Tournament.Models
{
    using System.Collections.Generic;
    using System.IO;

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
            Count++;
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
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(path);

            foreach (var referee in RefereesList)
            {
                referee.SaveReferee(streamWriter);
            }
            streamWriter.WriteLine("EndReferees");
            streamWriter.Close();
        }
        public void SaveRefereeList(StreamWriter streamWriter)
        {
            foreach (var referee in RefereesList)
            {
                referee.SaveReferee(streamWriter);
            }
            streamWriter.WriteLine("EndReferees");
        }
        /// <summary>
        /// Loads RefereeList object from a specified streamWriter
        /// </summary>
        public void LoadRefereeList(string path)
        {
            System.IO.StreamReader streamWriter = new System.IO.StreamReader(path);
            
            int id = 0;
            string name = string.Empty;
            string surname = string.Empty;
            string text;
            while ((text = streamWriter.ReadLine()) != null && text != "EndReferees")
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
                streamWriter.Close();
            
        }
    }
}
