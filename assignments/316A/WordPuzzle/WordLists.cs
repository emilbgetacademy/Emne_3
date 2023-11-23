using System.IO.Compression;

class WordLists
{
    private static readonly string WordListZipFile = "wordlists.zip"; 

    public static string Get(string language)
    {
        string wordlist_file = language.ToLower() + ".txt";
        string wordlist_content = "";

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
                ZipArchiveEntry? wordlist_content_file = archive.GetEntry(wordlist_file);

                if (wordlist_content_file != null)
                {
                    // open the content
                    using (Stream stream = wordlist_content_file.Open())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        wordlist_content = reader.ReadToEnd();
                    }
                }
                else
                {
                    Console.WriteLine($"File '{wordlist_file}' not found in the zip archive.");
                    Environment.Exit(1);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        if (wordlist_content == "")
        {
            Console.WriteLine("Something unextepcted happened when loading the wordlist");
            Environment.Exit(1);
        }

        return wordlist_content;
    }
}
