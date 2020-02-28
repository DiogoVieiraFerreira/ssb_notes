using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class FileReader
{
    public static async Task<string> Read(string filePath)
    {
        if (!File.Exists(filePath))
            return "Informations.txt not found";

        using (var reader = new StreamReader(filePath))
        {
            string line = await reader.ReadToEndAsync();

            return line;
        }
    }
    /// <summary>
    /// Write text in file
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="text">content to insert on file</param>
    /// <returns></returns>
    public static async Task Write(string filePath, string text)
    {
        if (!File.Exists(filePath))
            return;

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            await writer.WriteAsync(text);
        }
    }
}