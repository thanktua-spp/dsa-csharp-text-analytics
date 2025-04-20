
public static class FileHelper
{
    public static bool IsFileExist(string filePathName)
    {
        if (File.Exists(filePathName))
        {
            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine($"Reading from file {Path.GetFileName(filePathName)}");
            Console.WriteLine("**********************************");
            Console.WriteLine();
            return true;
        }
        else
        {
            Console.WriteLine($" File {filePathName} Not Found");
            return false;
        }
    }
}
