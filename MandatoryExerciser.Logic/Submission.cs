using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Logic
{
    public class Submission
    {
        private FileAccessor accessor = new FileAccessor();

        public int SerialNumber { get; set; }
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string EmailAddress { get; set; }

        public string Phonenumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        

        public List<Submission> RetrieveSubmissionsFromFile()
        {
            //read the whole file
            //return the substrings array where the entries aren't parseable 
            List<Submission> subs = new List<Submission>();

            string dataFromFile = accessor.ReadFromFile();

            string[] entries = dataFromFile.Split(",");

            foreach (var entry in entries)
            {
                string[] submission = entry.Split("-");
                if (submission.Length > 1)
                {
                    

                    string[] date = submission[5].Split("/");

                    var dateOfBirth = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
                    Submission temp = new Submission();

                    temp.SerialNumber = int.Parse(submission[0]);
                    temp.FirstName = submission[1];
                    temp.SurName = submission[2];
                    temp.EmailAddress = submission[3];
                    temp.Phonenumber = submission[4];
                    temp.DateOfBirth = dateOfBirth;

                    subs.Add(temp);
                }
            }

            return subs;
        }

        public void AddSubmission(Submission model)
        {
            // Read the whole file
            // Get the index to where the submission is attempted
            // If not parseable send error
            // If parseable add the model to the string and overwrite the file

            string dataFromFile = accessor.ReadFromFile();

            string[] entries = dataFromFile.Split(",");
            bool accessable = false;

            StringBuilder sb = new StringBuilder();

            foreach (var entry in entries)
            {
                if (model.SerialNumber.ToString().Equals(entry))
                {
                    sb.Append(entry + "-" + model.FirstName + "-" + model.SurName + "-" + model.EmailAddress + "-" + model.Phonenumber + "-" + model.DateOfBirth.Year + "/" + model.DateOfBirth.Month + "/" + model.DateOfBirth.Date + ",");
                    accessable = true;
                    continue;
                }
                sb.Append(entry + ",");
            }
            sb.Remove(sb.Length - 1, 1);

            if (accessable)
            {
                accessor.WriteToFile(sb.ToString());
               
            }
            
        }


        private string AssessData(string data, out int serial)
        {
            //tryParse, if false return the string
            if (!int.TryParse(data.Trim(), out serial)) return data;
            return "Serial Found";
        }

    }
}
