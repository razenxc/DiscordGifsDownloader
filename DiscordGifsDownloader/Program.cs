using System.Net;

namespace DiscordGifsDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string exportDir = "./Discord Gifs Export";
            Directory.CreateDirectory(exportDir);

            Console.WriteLine("Enter path to the txt or move and drop the file to the terminal:");
            string? txtPath = Console.ReadLine().Trim('"');
            if (!File.Exists(txtPath))
            {
                Console.WriteLine("File doesn't exsist!");
                Console.ReadLine();
            }

            string[] links = File.ReadAllLines(txtPath);

            WebClient webClient = new WebClient();

            for (int i = 0; i < links.Length; i++) {
                try
                {
                    string url = links[i];
                    string ext = Path.GetExtension(links[i]);

                    int querySymbolIndex = ext.IndexOf("?");
                    ext = querySymbolIndex >= 0 ? ext.Substring(0, querySymbolIndex) : ext;

                    if (string.IsNullOrEmpty(ext))
                    {
                        ext = ".bin";
                    }

                    webClient.DownloadFile(links[i], $"{exportDir}/discord-gif_{Guid.NewGuid().ToString()}{ext}");
                    Console.WriteLine("[OK]" + url);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error]: {ex.Message}");
                }
            }
        }
    }
}
