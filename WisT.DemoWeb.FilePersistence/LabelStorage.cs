using System;
using System.Collections.Generic;
using System.IO;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.FilePersistence
{
    public class LabelStorage : ILabelStorage
    {
        private string _projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        private string _clientsPath;
        private const string _labelPath = @"\WisT.DemoWeb.FilePersistence\Repo\Labels";
        private const string _repoPath = @"\WisT.DemoWeb.FilePersistence\Repo";
        public static ILabel CurrentClient;

        public LabelStorage()
        {
            _clientsPath = _projectPath + _labelPath;
            ConfigureRepo();
        }

        public void Add(ILabel addObj)
        {
            CurrentClient = addObj;
            CurrentClient.Id = new Identifier(CreateId(addObj.Name));
            string filePath = _clientsPath + @"\$" + CreateId(addObj.Name) + @".txt";
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

        public static int CreateId(string name)
        {
            int hash = 0;
            int radix = 1;
            foreach (char c in name)
            {
                hash += radix * c;
                radix *= 10;
            }
            return hash;
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

        private void ConfigureRepo()
        {
            Directory.CreateDirectory(_repoPath);
            Directory.CreateDirectory(_clientsPath);
        }
    }
}
