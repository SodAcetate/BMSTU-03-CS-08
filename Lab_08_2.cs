using System.IO.Compression;

namespace Lab_08_02{
    class Program{

        static void Main(){
            Console.WriteLine("Enter starting path");
            string path = Console.ReadLine();
            Console.WriteLine("Enter target file name");
            string name = Console.ReadLine();

            string fullPath = "";
            
            //проводим поиск в выбранном каталоге и во всех его подкаталогах
            foreach (string file in Directory.EnumerateFiles(path, name, SearchOption.AllDirectories))
            {
                FileInfo fInfo = new FileInfo(file);
                    Console.WriteLine($"Found: {fInfo.FullName}");
                    fullPath = fInfo.FullName;
            }

            if (fullPath!=null){
                using (FileStream fStream = File.Open(fullPath, FileMode.Open)){
                    StreamReader sReader = new StreamReader(fStream);
                    Console.Write($"=== FILE CONTENTS ===\n{sReader.ReadToEnd()}\n==== END OF FILE ====");
                }
            }
            

            File.Delete("archive.zip");
            using (var archive = ZipFile.Open("archive.zip", ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(fullPath, Path.GetFileName(fullPath));
            }

        }
    }
}