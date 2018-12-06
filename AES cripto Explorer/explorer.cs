using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_cripto_Explorer
{
    class explorer
    {
        static public void Explorer(ListView list)
        {
            list.Items.Clear();
            //ListViewItem.ListViewSubItem columnN = new ListViewItem.ListViewSubItem();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach(DriveInfo temp in allDrives)
            {
                ListViewItem column1 = new ListViewItem();
                column1.Text =  temp.RootDirectory.Name;
                column1.BackColor = System.Drawing.Color.GreenYellow;
                list.Items.Add(column1);
            }

        }

        static public void Explorer(ListView list, string path)
        {
            list.Items.Clear();
            string pathnow = Directory.GetCurrentDirectory();
            try
            {
                //установим текущий каталог как рабочий
                Directory.SetCurrentDirectory(path);

                //вывод .. чтобы вернуться выше
                ListViewItem columnUP = new ListViewItem();
                columnUP.Text ="..";
                columnUP.BackColor = System.Drawing.Color.GreenYellow;
                list.Items.Add(columnUP);


                path = Directory.GetCurrentDirectory();
                //вывод папок
                string[] dir = Directory.GetDirectories(path);
                foreach (string temp in dir)
                {
                    ListViewItem column1 = new ListViewItem();
                    column1.Text = new DirectoryInfo(temp).Name;
                    column1.BackColor = System.Drawing.Color.Aqua;
                    list.Items.Add(column1);
                }
                //вывод файлов
                dir = Directory.GetFiles(path);
                foreach (string temp in dir)
                {
                    ListViewItem column1 = new ListViewItem();
                    ListViewItem.ListViewSubItem column2 = new ListViewItem.ListViewSubItem();
                    column1.UseItemStyleForSubItems = false;
                    column1.Text = Path.GetFileName(temp);
                    long fileSize = new FileInfo(column1.Text).Length;
                    int i = 0;
                    while (fileSize / Math.Pow(2, i * 10) > 1) i++;
                   
                    if(i>0)
                        column2.Text = Convert.ToString(Math.Round(fileSize/ Math.Pow(2, (i-1) * 10),2));
                    else
                        column2.Text = Convert.ToString(fileSize);
                    switch (i)
                    {
                        case 1:
                            column2.Text += " byte";
                            column2.BackColor = System.Drawing.Color.FromArgb(10, 105, 180);
                            break;
                        case 2:
                            column2.Text += " KB";
                            column2.BackColor = System.Drawing.Color.FromArgb(100, 105, 180);
                            break;
                        case 3:
                            column2.Text += " MB";
                            column2.BackColor = System.Drawing.Color.FromArgb(220, 105, 180);
                            break;
                        case 4:
                            column2.Text += " GB";
                            column2.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                            break;
                        case 5:
                            column2.Text += " TB";
                            column2.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                            break;
                        default:
                            column2.Text += " byte";
                            column2.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
                            break;
                    }
                    
                    string temp1 = temp.Remove(0, temp.Length - ".crypt".Length);
                    //System.Console.WriteLine(temp1);
                    if (temp1 == ".crypt")
                    {
                        column1.BackColor = System.Drawing.Color.Pink;
                    }
                    column1.SubItems.Add(column2);
                    list.Items.Add(column1);
                    //list.Items.Add(column2);
                }
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("Can't open folder ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Explorer(list, pathnow);
            }
            catch(System.NotSupportedException)
            {

            }
            catch(System.UnauthorizedAccessException)
            {
                MessageBox.Show("Can't open folder,Unauthorized Access ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Explorer(list, pathnow);
            }
        }

        static public void delete(string filename)
        {
            try
            {
                FileStream f1 = File.Open(filename, FileMode.Open);
                long lenghtFile = f1.Length;
                f1.Close();
                Random temp = new Random();
                FileStream f2 = File.OpenWrite(filename);
                byte[] tempbyte = new byte[1];
                for(long i = 0; i < lenghtFile; i++)
                {
                    temp.NextBytes(tempbyte);
                    f2.WriteByte(tempbyte[0]);
                }
                f2.Close();
                File.Delete(filename);
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("Can't delete file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

    }
}
