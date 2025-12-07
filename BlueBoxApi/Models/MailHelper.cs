using System;
using System.IO;
using MimeKit;

namespace NewLibre;

public static class MailHelper
{
    /// <summary>
    /// Saves a MimeMessage to disk with a timestamped filename.
    /// </summary>
    /// <param name="message">The MimeMessage to save.</param>
    /// <param name="directory">Target directory (defaults to current directory).</param>
    /// <returns>The full path of the saved file.</returns>
    public static string SaveMessage(MimeMessage message, string directory = null)
    {
        if (message == null)
            throw new ArgumentNullException(nameof(message));

        // Default to current directory if none provided
        if (string.IsNullOrEmpty(directory))
            directory = Directory.GetCurrentDirectory();

        // Ensure directory exists
        Directory.CreateDirectory(directory);

        // Build timestamped filename
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string subjectSafe = string.Join("_", message.Subject?.Split(Path.GetInvalidFileNameChars()) ?? new string[] { "NoSubject" });
        string fileName = $"{timestamp}_{subjectSafe}.eml";

        string fullPath = Path.Combine(directory, fileName);

        // Write raw RFC822 message
        using (var stream = File.Create(fullPath))
        {
            message.WriteTo(stream);
        }

        return fullPath;
    }
}

