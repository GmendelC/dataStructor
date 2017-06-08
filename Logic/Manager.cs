using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Manager
    {
        Dictionary<string, Document> documents;

        public Manager()
        {
            documents = new Dictionary<string, Document>();
        }

        public bool IsDuplicated(string sDoc)
        {
            Document doc = new Document(sDoc);
            Document tmp;

            if (documents.TryGetValue(doc.Key, out tmp)) // search if was this key/docoment
            {
                tmp.Upadate(doc);
                return true;
            }

            documents.Add(doc.Key, doc); // add was not this key/docoment
            return false;
        }

        public string ShowDetails(string sDoc)
        {
            // Search by key document: 
            // Return null if wasn't this key

            string key = Untiles.GetKey(sDoc);
            Document tmp;

            if (documents.TryGetValue(key, out tmp))
            {
                return tmp.ToString();
            }
            string msg = "Does not exist";

            return msg;
        }

        public string ShowDetails()
        {
            // show all basic data

            StringBuilder sb = new StringBuilder();

            foreach (var item in documents)
            {
                sb.AppendLine(item.Value.ToPrint());
            }
            return sb.ToString();
        }

        public bool Delete(string sDoc)
        {
            string key = Untiles.GetKey(sDoc);
            return documents.Remove(key);
        }

        public bool FindClosestAmount( string sDoc, out int count, out string form)
        {
            string key = Untiles.GetKey(sDoc);
            Document tmp;
            count = 0;
            form = null;

            if (!documents.TryGetValue(key, out tmp))
                return false;

            return tmp.FindClosestAmount(tmp, out count, out form);
        }
    }
}
