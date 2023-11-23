using System.IO.Compression;

class WordLists
{
    private static readonly string WordListZipFile = "wordlists.zip";

    public static string[] Get(string language)
    {
        string filename = language.ToLower() + ".txt";
        var wordlist = new List<string>();

        try
        {
            // Ensure the zip file exists
            if (!File.Exists(WordListZipFile))
            {
                Console.WriteLine($"Zip file '{WordListZipFile}' not found");
                Environment.Exit(1);
            }

            // extract the zip file
            using (ZipArchive archive = ZipFile.OpenRead(WordListZipFile))
            {
                // get the specified wordlist (text file)
                ZipArchiveEntry? entry = archive.GetEntry(filename);

                if (entry != null)
                {
                    // read contents of text file
                    using (Stream stream = entry.Open())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // add each line to list
                        while (!reader.EndOfStream)
                        {
                            string? line = reader.ReadLine();
                            if (line != null) wordlist.Add(line);
                        }
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

        if (!wordlist.Any())
        {
            Console.WriteLine("Something unextepcted happened when loading the wordlist");
            Environment.Exit(1);
        }

        return wordlist.ToArray();
    }
}
