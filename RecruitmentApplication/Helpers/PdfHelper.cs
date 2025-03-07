using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace RecruitmentApplication.Helpers
{
    public static class PdfHelper
    {
        public static void OpenPdfFromResources(string resourceName)
        {
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
                using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resourceStream == null)
                    {
                        throw new Exception($"Resource '{resourceName}' not found.");
                    }

                    using (FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                }

                Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while opening the PDF: {ex.Message}", ex);
            }
        }
    }
}
