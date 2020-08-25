using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ExceptionCatching.Handlers
{
    internal class ScreenshotHandler
    {
        /// <summary>
        ///     Создаем скриншот.
        /// </summary>
        internal static void CreateScheenshot()
        {
            var printscreen = new Bitmap(1000, 500);
            var graphics = Graphics.FromImage(printscreen);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            var path = CreateDirectory();
            printscreen.Save($"{path}\\error_screenshot.jpg", ImageFormat.Jpeg);
        }

        /// <summary>
        ///     Создаем новую дирректорию.
        /// </summary>
        /// <returns>DirectoryInfo</returns>
        private static DirectoryInfo CreateDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return Directory.CreateDirectory($"{currentDirectory}\\Screenshots");
        }
    }
}