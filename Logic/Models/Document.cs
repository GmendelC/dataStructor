using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace Logic.Models
{
    class Document
    {

        public string Key { get; set; }

        public int TotalCount { get; set; }

        BST<Form> Forms;
        public Document( string sDoc)
        {
            // all ctors is string
            sDoc = Untiles.clean(sDoc);
            TotalCount = 1;

            Forms = new BST<Form>();

            Forms.Add(new Form(sDoc));

            Key = Untiles.GetKey(sDoc);

        }
        
        public void Upadate(Document doc)
        {
            Form tmp;
            TotalCount++;

            if (Forms.Search(doc.Forms.Root, out tmp)) // search if was this format
                tmp.Count++;

            else
                Forms.Add(doc.Forms.Root); // if isnt add them
        }

        public override string ToString()
        {
            // all data
            return $"{ToPrint()} : {Forms.ToString()}";
        }

        public string ToPrint()
        {
            // basic data
            return $"Document key: {Key} = {TotalCount}";
        }

        private class Form : IComparable<Form>
        {
            // inner class : form is the form of one copy of documents
            public string MyForm { get; set; }
            public int Count { get; set; }

            public Form(string sForm)
            {
                MyForm = sForm;
                Count = 1;
            }
            public int CompareTo(Form other)
            {
                return MyForm.CompareTo(other.MyForm);
            }

            public override string ToString()
            {
                return $"{MyForm} = {Count}";
            }
        }

        internal bool FindClosestAmount(Document doc, out int count, out string form)
        {
            count = 0;
            form = null;

            Form tmp;
           if (Forms.FindClosestAmount(doc.Forms.Root, out tmp))
            {
                count = tmp.Count;
                form = tmp.MyForm;
                return true;
            }

            return false;
        }
    }
}
