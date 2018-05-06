using System;
using System.Collections.Generic;
using System.IO;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.FilePersistence
{
    public class LabelStorage : ILabelStorage
    {
        private string _projectPath;
        private string _clientsPath;

        public LabelStorage()
        {
            _projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            _clientsPath = _projectPath + @"\WisT.DemoWeb.FilePersistence\Repo\Labels";
        }

        public void Add(ILabel addObj)
        {
            string filePath = _clientsPath + @"\$" + addObj.Id.IdentifingCode.ToString() + @".txt";
            File.Create(filePath).Dispose(); ;
            using (TextWriter tw = new StreamWriter(filePath))
            {
                tw.Write(addObj.Name);
                tw.Close();
            }
        }

        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }

        public ILabel Get(IIdentifier id)
        {
            string filePath = _clientsPath + @"\$" + id.IdentifingCode.ToString() + @".txt";
            string name;
            using (TextReader tr = new StreamReader(filePath))
            {
                 name = tr.ReadLine();
            }
            return new Label(name, id);
        }

        public IEnumerable<ILabel> GetAll()
        {
            string[] labelFiles = Directory.GetFiles(_clientsPath);
            List<Label> allLabels = new List<Label>();

            foreach(var labelFile in labelFiles)
            {
                int currentId = IdParser(labelFile);
          
                string currentName;

                using (TextReader tr = new StreamReader(labelFile))
                {
                    currentName = tr.ReadLine();
                }
                allLabels.Add(new Label(currentName, new Identifier(currentId)));
            }

            return allLabels;
        }

        private int IdParser(string path)
        {
            int tale = ".txt".Length + 1;
            int count = path.Length - tale;
            string answ = "";

            while (path[count] != '$')
            {
                answ = answ + path[count--];
            };

            char[] charArray = answ.ToCharArray();
            Array.Reverse(charArray);
            return int.Parse(new string(charArray));
        }
    }
}
