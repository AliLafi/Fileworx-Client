//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace Fileworx_Client
//{
//    internal class FileOp
//    {


//        public List<string> ReadOneFile (string path)
//        {
//            string strTemp = File.ReadAllText(path);
//            List<string> temp = new List<string>();
//            string[] elements = strTemp.Split('%');
//            foreach(string element in elements)
//            {
//                temp.Add(element);

//            }
//                temp.Add(Path.GetFileName(path).Replace(".txt", ""));

//            return temp;
//        }

//        public List<List<string>> ReadFromFile(string path)
//        {

//            string strTemp;
//            List<List<string>> temp = new List<List<string>>();

//            foreach (string fileName in Directory.GetFiles(path, "*txt"))
//            {
//                List<string> line = new List<string>();
//                strTemp = File.ReadAllText(fileName);

//                line.AddRange(strTemp.Split('%'));
//                line.Add(Path.GetFileName(fileName).Replace(".txt", ""));

//                temp.Add(line);

//            }

//            return temp;
//        }

//        // writing to file gets the object selects the path based on type of object 
//        public async void WriteToFile(Object o, string guid)
//        {
//         //   string path = (o is News) ? MainWindow.newsPath : ((o is Photo) ? MainWindow.photoPath : MainWindow.userPath);

//            try
//            {

//               // using (StreamWriter st = new StreamWriter(Path.Combine(path, guid + ".txt"), false))
//                {
//               //     await st.WriteLineAsync(o.ToString());
//                }

//            }

//            catch (Exception err)
//            {
//                MessageBox.Show("File Save Failed " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

//        }

//        // deleting file from a specific path
//        public void DeleteFile(string path)
//        {
//            try
//            {
//                File.Delete(path);
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show("Delete failed " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//    }

//}





