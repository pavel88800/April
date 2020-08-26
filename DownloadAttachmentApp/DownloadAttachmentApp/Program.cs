using System.Text;

namespace DownloadAttachmentApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var downloadAttachment = new DownloadAttachment();
            downloadAttachment.Init();
        }
    }
}