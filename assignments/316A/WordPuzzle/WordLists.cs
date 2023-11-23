using System.IO.Compression;

class WordLists
{
    private static readonly string WordListZipFile = "wordlists.zip"; 

    public static string Get(string language)
    {
        string filename = language.ToLower() + ".txt";
        string wordlist = "";

        try
        {
            // Ensure the zip file exists
            if (!File.Exists(WordListZipFile))
            {
                Console.WriteLine($"Zip file '{WordListZipFile}' not found");
                Environment.Exit(1);
            }

            // extract zip file
            using (ZipArchive archive = ZipFile.OpenRead(WordListZipFile))
            {
                // get the specified wordlist inside
                ZipArchiveEntry? entry = archive.GetEntry(filename);

                if (entry != null)
                {
                    // open the content
                    using (Stream stream = entry.Open())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        wordlist = reader.ReadToEnd();
                    }
                }
                else
                {
                    Console.WriteLine($"File '{filename}' not found in the zip archive.");
                    Environment.Exit(1);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        if (wordlist == "")
        {
            Console.WriteLine("Something unextepcted happened when loading the wordlist");
            Environment.Exit(1);
        }

        return wordlist;
    }
}