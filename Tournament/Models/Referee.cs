using System;
using System.Collections.Generic;
using System.IO;

namespace Tournament.Models
{
    public class Referee : Person
    {
        /// <summary>
        /// Initializes a new instance of Referee
        /// </summary>
        public Referee(string name, string surname, List<Referee> refereeList) : base(name, surname, 0)
        {
            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                if (refereeList != null)
                {
                    foreach (var referee in refereeList)
                        if (randID == referee.ID)
                            FreeID = false;
                }
                else
                {
                    ID = randID;
                    FreeID = false;
                    break;
                }
            } while (FreeID == false);
            if (FreeID)
                ID = randID;
        }
        public void SaveReferee(StreamWriter file)
        {

                file.WriteLine("RefereeID: " + ID);
                file.WriteLine("RefereeName: " + Name);
                file.WriteLine("RefereeSurname: " + Surname);
                file.WriteLine("EndReferee");
        }
        public Referee LoadReferee(StreamReader file)
        {
            int id = 0;
            string name = string.Empty;
            string surname = string.Empty;
            string text;
            while ((text = file.ReadLine()) != null && text != "EndReferee")
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

                                Referee referee = new Referee(name, surname, null)
                                {
                                    ID = id
                                };
                                return referee;
                        }
                }
            }
            return null;
        }
    }
}
