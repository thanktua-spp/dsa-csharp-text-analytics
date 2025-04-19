class DictDocumentReader()
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

    public string[] ReadFromDocument(string filePathName)
    {
        if (IsFileExist(filePathName))
        {   
            return File.ReadAllLines(filePathName);
        }
        return [];
    }
}
