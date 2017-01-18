using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplaceArmText;
using System.IO;

namespace Program
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      Console.WriteLine("______Armenian Translit Of English Translator ______\n");
      Console.Write("Please enter the location path of the translated file.\nFile must be in UNICODE and has .txt format.\n(location path format: C:\\Users\\User\\Desktop\\translate.txt): ");
      string path = Console.ReadLine();
      if (!File.Exists(path))
      {
        Console.WriteLine("\nYou input wrong location path input. Correct it!!!");
        Console.ReadKey();
        return;
      }

      string s = "";
      string text = "";

      using (StreamReader sr = File.OpenText(path))
      {
        if (sr == null)
        {
          Console.WriteLine("The file is doesn't exist!!!");
          return;
        }

        while ((s = sr.ReadLine()) != null)
        {

          text += s;
          text += '\n';
        }
      }

      string ouput = text.ReplaceArmText();

      string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Translated.txt";
      using (var writer = new StreamWriter(DesktopPath))
      {
        writer.WriteLine(ouput);
      }

      Console.WriteLine("\n\nCongradulaions!!!\nYour file is transleted. You can find it on Your desktop.\nThe file name is translated.txt. ");

      Console.ReadKey();

    }
  }
}