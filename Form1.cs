using Pfim;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;

namespace MTFRTexFix
{
    public partial class Form1 : Form
    {

        private List<string> FileNameList = new();
        private List<string> WidthList = new();
        private List<string> HeightList = new();
        private List<string> MipsList = new();
        private List<string> FullPathList = new();
        private int ScanErrors = 0;
        private int Warnings = 0;
        private int Errors = 0;

        public Form1()
        {
            InitializeComponent();
            InitLogBox();
            button3.Enabled = false;
        }

        private void InitLogBox()
        {
            LogBox.AppendText("1 - Click \"Select Folder\" and navigate to the folder containing default .txt files and modified .dds files. (You can optionally check all subfolders as well.)\n");
            LogBox.AppendText("2 - Click \"Scan Files\" to let the tool check the validity of all .txt & .dds files.\n");
            LogBox.AppendText("3 - Click \"Fix it!\" to have the tool automatically update all valid .txt files with parameters from your corresponding .dds files.\n\n");
        }

        private void FolderButton_Click(object sender, EventArgs e)
        {
            FolderDialog.ShowDialog();
            PathBox.Text = FolderDialog.SelectedPath;
            LogBox.AppendText("New path selected: \"" + PathBox.Text + "\"\n");
        }

        private void PathBox_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }


        private void CheckImage(string path)
        {
            try
            {
                using (var image = Pfimage.FromFile(path))
                {
                    PixelFormat format;

                    switch (image.Format)
                    {
                        case Pfim.ImageFormat.Rgba32:
                            format = PixelFormat.Format32bppArgb;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    if (TextFileExists(path))
                    {
                        var width = image.Width;
                        var height = image.Height;
                        var mips = image.MipMaps.Length + 1;
                        string textpath = path.Substring(0, path.LastIndexOf("."));
                        textpath = textpath + ".txt";
                        FileNameList.Add(textpath);
                        WidthList.Add(width.ToString());
                        HeightList.Add(height.ToString());
                        MipsList.Add(mips.ToString());
                        LogBox.AppendText("Reading DDS parameters for \"" + path + "\" as follows: Width=" + width + ", Height=" + height + ", Mips=" + mips + "\n");
                    }
                    else
                    {
                        ScanErrors++;
                    }
                }
            }
            catch (Exception ex)
            {
                ScanErrors++;
                LogBox.SelectionColor = Color.Red;
                LogBox.AppendText("Invalid File at: \"" + path + "\". Exception message: \"" + ex.Message + "\"\n");
                LogBox.SelectionColor = Color.Black;
            }
        }

        private void EditTextFiles()
        {
            if (FileNameList.Count > 0)
            {
                for (int i = 0; i < FileNameList.Count; i++)
                {
                    string width = "";
                    string height = "";
                    string mips = "";
                    string[] lines = File.ReadAllLines(FileNameList[i]);
                    string[] newlines = lines;
                    for (int j = 0; j < lines.Length; j++)
                    {

                        if (lines[j].Contains("Width"))
                        {
                            newlines[j] = "Width=" + WidthList[i];
                            width = WidthList[i];
                        }
                        else if (lines[j].Contains("Height"))
                        {
                            newlines[j] = "Height=" + HeightList[i];
                            height = HeightList[i];
                        }
                        else if (lines[j].Contains("Mips"))
                        {
                            newlines[j] = "Mips=" + MipsList[i];
                            mips = MipsList[i];
                        }
                        else
                        {
                            newlines[j] = lines[j];
                        }
                    }
                    if (width.Length >= 1 || height.Length >= 1 || mips.Length >= 1)
                    {
                        LogBox.AppendText("Edited properties of \"" + FileNameList[i] + "\". New Value(s): ");
                        if (width.Length >= 1)
                        {
                            LogBox.AppendText("Width=" + width + ". ");
                        }
                        if (height.Length >= 1)
                        {
                            LogBox.AppendText("Height=" + height + ". ");
                        }
                        if (mips.Length >= 1)
                        {
                            LogBox.AppendText("Mips=" + mips + ". ");
                        }
                        if (width.Length == 0)
                        {
                            LogBox.SelectionColor = Color.DarkOrange;
                            LogBox.AppendText("Width not present in text file. ");
                            LogBox.SelectionColor = Color.Black;
                            Warnings++;
                        }
                        if (height.Length == 0)
                        {
                            LogBox.SelectionColor = Color.DarkOrange;
                            LogBox.AppendText("Height not present in text file. ");
                            LogBox.SelectionColor = Color.Black;
                            Warnings++;
                        }
                        if (mips.Length == 0)
                        {
                            LogBox.SelectionColor = Color.DarkOrange;
                            LogBox.AppendText("Mips not present in text file.");
                            LogBox.SelectionColor = Color.Black;
                            Warnings++;
                        }
                        LogBox.AppendText("\n");
                    }
                    else
                    {
                        LogBox.SelectionColor = Color.Red;
                        LogBox.AppendText("\"" + FileNameList[i] + "\" is missing all parameters. Could not make any edits!\n");
                        LogBox.SelectionColor = Color.Black;
                        Errors++;
                        continue;
                    }

                    using (StreamWriter writer = new StreamWriter(FileNameList[i]))
                    {
                        {
                            foreach (string line in newlines)
                            {
                                writer.WriteLine(line);
                            }
                        }
                        writer.Close();
                    }
                }
                LogBox.SelectionColor = Color.DarkGreen;
                LogBox.AppendText("Finished editing! ");
                if (Warnings == 0 && Errors == 0)
                {
                    LogBox.AppendText("(0 Warning(s)!) (0 Error(s)!)");
                }
                if (Warnings > 0)
                {
                    LogBox.SelectionColor = Color.DarkOrange;
                    LogBox.AppendText("(" + Warnings.ToString() + " Warning(s)!) ");
                }
                if (Errors > 0)
                {
                    LogBox.SelectionColor = Color.Red;
                    LogBox.AppendText("(" + Errors.ToString() + " Error(s)!)");
                }
                LogBox.SelectionColor = Color.Black;
                LogBox.AppendText("\nhttps://github.com/neatodev\nhttps://www.nexusmods.com/users/81089053\nhttps://www.nexusmods.com/residentevilbiohazardhdremaster/mods/103\n");
                LogBox.AppendText("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            }
            else
            {
                LogBox.SelectionColor = Color.DarkOrange;
                LogBox.AppendText("No text files found. Aborting process.\n");
                LogBox.SelectionColor = Color.Black;
            }
        }

        private bool TextFileExists(string path)
        {
            string textpath = path.Substring(0, path.LastIndexOf("."));
            textpath = textpath + ".txt";
            if (File.Exists(@textpath))
            {
                LogBox.AppendText("Found a text file for \"" + path + "\".\n");
                return true;
            }
            LogBox.SelectionColor = Color.Red;
            LogBox.AppendText("Could not find a text file for \"" + path + "\". Skipping file.\n");
            LogBox.SelectionColor = Color.Black;
            return false;
        }

        private bool FilesFound()
        {
            if (FileNameList.Count >= 1)
            {
                return true;
            }
            return false;
        }

        private void ClearLists()
        {
            FileNameList.Clear();
            WidthList.Clear();
            HeightList.Clear();
            MipsList.Clear();
            FullPathList.Clear();
        }

        private void CheckRecursive(string mainDir)
        {
            var Files = Directory.GetFiles(mainDir, "*.dds", new EnumerationOptions { IgnoreInaccessible = true, RecurseSubdirectories = true });
            
            foreach (string f in Files)
            {
                CheckImage(f);
            }

            if (FilesFound())
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void CheckNormal(string mainDir)
        {
            foreach (string f in Directory.EnumerateFiles(mainDir, "*.dds", SearchOption.TopDirectoryOnly))
            {
                CheckImage(f);
            }

            if (FilesFound())
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Warnings = 0;
            Errors = 0;
            EditTextFiles();
        }

        private void LogBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = e.LinkText, UseShellExecute = true });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearLists();
            ScanErrors = 0;
            DialogResult Recursive = MessageBox.Show("Check subfolder(s)?", "Recursion Check", MessageBoxButtons.YesNo);
            if (Recursive == DialogResult.Yes)
            {
                CheckRecursive(PathBox.Text);
            }
            else
            {
                CheckNormal(PathBox.Text);
            }
            LogBox.SelectionColor = Color.DarkGreen;
            LogBox.AppendText("Finished scanning!");
            if (ScanErrors == 0)
            {
                LogBox.AppendText(" (0 Error(s)!)\n");

                if (!button2.Enabled)
                {
                    LogBox.SelectionColor = Color.DarkOrange;
                    LogBox.AppendText("No applicable files found!\n");
                    LogBox.SelectionColor = Color.Black;
                }

            }
            else
            {
                LogBox.SelectionColor = Color.Red;
                LogBox.AppendText(" (" + ScanErrors.ToString() + " Error(s)!)\n");
            }
            LogBox.SelectionColor = Color.Black;
        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.ScrollToCaret();
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogBox.Clear();
            InitLogBox();
            button3.Enabled = false;
        }
    }
}