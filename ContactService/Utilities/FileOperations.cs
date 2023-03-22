using FileworxObjects.DTOs;

namespace WorkerService1.Utilities
{
    public class FileOperations
    {

        public static List<string> IsUpToDate(string path, DateTime lastReceptionDate)
        {
            if(Directory.Exists(path))
            {
                List<string> result = new List<string>();   
                DirectoryInfo contactDirectory = new(path);
                foreach (var file in contactDirectory.EnumerateFiles())
                {
                    if (file.LastWriteTime > lastReceptionDate)
                    {
                        result.Add(file.Name);
                    }
                }
                return result;
            }

            return new List<string>();
        }

        public static void WriteToFile(string path, string content)
        {
            if (Directory.Exists(path))
            {
                string pathToSave = Path.Combine(path, Guid.NewGuid().ToString()+".txt");
                using (StreamWriter sw = new(pathToSave))
                {
                    sw.WriteLine(content);
                }
            }
        }

        public static string CopyPhoto(string path, string photoPath)
        {
            if (!Directory.Exists(path) || !File.Exists(photoPath))
            {
                return string.Empty;
            }
            string extension = Path.GetExtension(photoPath);
            string name = Guid.NewGuid().ToString() + extension;
            path = Path.Combine(path, name);
            File.Copy(photoPath, path, true);
            return name;

        }

        public static string ReadFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string temp = File.ReadAllText(path);
                    if (string.IsNullOrEmpty(temp))
                        return string.Empty;
                    else
                        return temp;

                }
                else return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
                return ex.Message;
            }

        }

    }
}
