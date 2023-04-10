using FluentFTP;
using WorkerService1.Utilities;

namespace ContactService.Utilities
{
    public class FtpOperations
    {
        public static List<string> IsUpToDateFtp(FtpClient con, string path, DateTime lastReceptionDate)
        {
            if (con.DirectoryExists(path))
            {
                try
                {
                    List<string> result = new List<string>();
                    var items = con.GetListing(path);
                    foreach (FtpListItem item in items)
                    {
                        if (item.Modified > lastReceptionDate)
                        {
                            result.Add(item.Name);
                        }
                    }
                    return result;
                }
                catch
                {
                    return new List<string>();
                }
            }
            return new List<string>();
        }
        
        public static void WriteToFtp(FtpClient con,string path,string content)
        {
            if (con.DirectoryExists(path))
            {
                string tempPath = FileOperations.WriteToFile(Path.GetTempPath(), content);
                con.UploadFile(tempPath, Path.Combine(path, Path.GetFileName(tempPath)));
                File.Delete(tempPath);
            }            
        }
    }
}
