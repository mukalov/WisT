using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.FilePersistence
{
    public class LabelStorage : ILabelStorage
    {
        private string _rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        private string _clientsPath;
        private string _imagesPath;
        private const string _labelPath = @"\Repo\Labels";
        private const string _repoPath = @"\Repo";
        private const string _photoesPath = @"\Repo\Images";
        private static int _numOfPhotoes = 1;

        public static ILabel CurrentClient;

        public LabelStorage()
        {
            _clientsPath = _rootPath + _labelPath;
            _imagesPath = _rootPath + _photoesPath;
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

            int photoCounter = 0;
            foreach (var obj in addObj.Images)
            {
                string pathToCurrent = _imagesPath + @"\" + (photoCounter++).ToString() + "$" + CurrentClient.Id.IdentifingCode.ToString() + ".bmp";
                var currentImg = new FaceImage(obj.ImageOfFace);
                currentImg.ImageOfFace.Save(pathToCurrent);
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
            Label response = new Label(name, id);
            for (int photoCounter = 0; photoCounter < _numOfPhotoes; photoCounter++)
            {
                string currrentPath = _imagesPath + @"\" + photoCounter.ToString() + "$" + id.IdentifingCode.ToString() + ".bmp";
                FaceImage currentImage = new FaceImage(new Bitmap(currrentPath)) { Id = id };
                response.AddImage(currentImage);
            }
            return response;
        }

        public IEnumerable<ILabel> GetAll()
        {
            string[] labelFiles = Directory.GetFiles(_clientsPath);
            List<ILabel> allLabels = new List<ILabel>();

            foreach(var labelFile in labelFiles)
            {
                int currentId = IdParser(labelFile);

                var currentLabel = Get(new Identifier(currentId));

                allLabels.Add(currentLabel);
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
            Directory.CreateDirectory(_imagesPath);
        }
    }
}
