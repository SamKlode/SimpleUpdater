using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Net;



var client = new System.Net.WebClient();
string Version = ("1.0"); //version, 
string url = "https://yourwebsite.com/Version.txt";
string content = client.DownloadString(url);
if (content != Version) //checks if the website up to date version is the same
{
    string message1 = "A New Version Is Avaliable, Would You Like To Download it?";
    MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
    DialogResult result1;
    result1 = MessageBox.Show(message1, "ProgramName", buttons1, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
    if (result1 == DialogResult.Yes)
    {
        try
        {
            string sourceFile = System.Reflection.Assembly.GetExecutingAssembly().Location;
              try
              {
                   File.Delete(sourceFile + ".sBackup");
              }
              catch (FileNotFoundException)
              {
              };
            System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
            fi.MoveTo(sourceFile + ".Backup"); //makes old exe a .backup so you can revert if required
            WebClient Download = new WebClient();
            Download.DownloadFile("https://yourwebsite.com/yourprogram.exe", sourceFile);
            string Final = (sourceFile);
            MessageBox.Show("Succesfully Updated!", "");
            Thread.Sleep(20); 
            Process.Start(sourceFile);
            System.Environment.Exit(1);
        }
        catch (WebException)
        {
            MessageBox.Show("Could not download Update.Try to download Manually From Github", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
else; //happens if the versions are the sam
