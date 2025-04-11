using System.Drawing;
using System.Net;
using FFMpegCore;

namespace DiscordGifsDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GlobalFFOptions.Configure(options => options.BinaryFolder = "./bin");

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

            for (int i = 0; i < links.Length; i++)
            {
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

                    string downloadPath = $"{exportDir}/discord-gif_{Guid.NewGuid().ToString()}";
                    webClient.DownloadFile(links[i], downloadPath+ext);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[DOWNLOAD] [OK] " + url);

                    if (ext == ".mp4" || ext == ".bin")
                    {
                        bool convertStatus = FFMpeg.GifSnapshot(downloadPath+ext, $"{downloadPath}.gif");
                        if (!convertStatus)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"[CONVERT] [ERROR] {downloadPath}{ext} to {downloadPath}.gif");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"[CONVERT] [OK] {downloadPath}{ext} to {downloadPath}.gif");
                        File.Delete(downloadPath+ext);
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR]: {ex.Message}");
                }
            }
        }
    }
}
