using Microsoft.Maui.Storage;
using System.Diagnostics;
using System.Reflection;

namespace Erp_MAUI;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private async void ChooseFilePath(object sender, EventArgs e)
	{
      var result = await  FilePicker.PickAsync(new PickOptions
      {
           PickerTitle = "Pick File",
		   FileTypes = FilePickerFileType.Images
      });

	  if(result == null)
	  {
			return;
	  }

		var stream = await result.OpenReadAsync();
  
        string libreOfficePath = getLibreOfficePath();
        string path = "";
        ProcessStartInfo procStartInfo = new ProcessStartInfo(libreOfficePath,
        string.Format("--convert-to pdf C:\\Users\\dudekpob\\Desktop\\Projekty\\kolos_poprawkowy\\test.docx")); //test.docx => input path
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        procStartInfo.CreateNoWindow = true;
        procStartInfo.WorkingDirectory = path;

        Process process = new Process() { StartInfo = procStartInfo, };
        process.Start();
        process.WaitForExit();



    }
    static string getLibreOfficePath()
    {
        switch (Environment.OSVersion.Platform)
        {
            case PlatformID.Unix:
                return "/usr/bin/soffice";
            case PlatformID.Win32NT:
                string binaryDirectory =
          System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return @"C:\Program Files\LibreOffice\program\soffice.exe";
            default:
                throw new PlatformNotSupportedException("Your OS is not supported");
        }
    }


   



}

