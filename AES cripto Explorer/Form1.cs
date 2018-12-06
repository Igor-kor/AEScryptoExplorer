using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_cripto_Explorer
{
    public partial class Form1 : Form
    {
       /* private void FocusAndSelectItem(int itemIndex)
        {
            Dispatcher.BeginInvoke(
                new FocusAndSelectItemDelegate(TryFocusAndSelectItem),
                DispatcherPriority.ApplicationIdle,
                itemIndex);
        }

        // Убеждаемся, что айтем находится в видимой области, выделяем его и устанавливаем фокус.
        private void TryFocusAndSelectItem(ListView myListView,int itemIndex)
        {
            ListViewItem lvi = myListView.Items.GetItemAt(itemIndex) as ListViewItem;
            if (lvi != null)
            {
                myListView.ScrollIntoView(lvi);
                lvi.IsSelected = true;
                Keyboard.Focus(lvi);
            }
        }*/
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            //listView1.Sorting = SortOrder.Ascending;

            listView1.Columns.Add("Name",listView1.Width/4*3);
            listView1.Columns.Add("Size", listView1.Width/4);

            explorer.Explorer(listView1);
            textBox2.Text = Directory.GetCurrentDirectory();

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectitem = listView1.SelectedItems;
            foreach(ListViewItem item in selectitem)
            {
                if(item.SubItems[0].BackColor == Color.Aqua || item.SubItems[0].BackColor == Color.GreenYellow)
                {
                    //здесь передаем путь чтобы перейти в другой каталог
                   explorer.Explorer(listView1, item.SubItems[0].Text);
                }
                else
                {
                    //здесь нужно передавать файл дальше на обработку
                    System.Diagnostics.Process.Start(item.SubItems[0].Text);
                }
            }
            textBox2.Text = Directory.GetCurrentDirectory();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectitem = listView1.SelectedItems;
            foreach (ListViewItem item in selectitem)
            {
                if (item.SubItems[0].BackColor == Color.Aqua || item.SubItems[0].BackColor == Color.GreenYellow)
                {
                    //здесь передаем путь чтобы перейти в другой каталог
                    explorer.Explorer(listView1, item.SubItems[0].Text);
                }
                else
                {
                    //здесь нужно передавать файл дальше на обработку
                    System.Diagnostics.Process.Start(item.SubItems[0].Text);
                }
            }
            textBox2.Text = Directory.GetCurrentDirectory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            explorer.Explorer(listView1);
            textBox2.Text = Directory.GetCurrentDirectory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            explorer.Explorer(listView1, listView1.Items[0].Text);
            textBox2.Text = Directory.GetCurrentDirectory();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectitem = listView1.SelectedItems;
            foreach (ListViewItem item in selectitem)
            {
                if (!(item.SubItems[0].BackColor == Color.Aqua || item.SubItems[0].BackColor == Color.GreenYellow ))
                {
                    //если стоит галочка шифровать имена файлов
                    //чтото не очень хорошо получается
                    if(checkBox2.Checked && (item.SubItems[0].Text.Length * 4) < (200 - ".crypt".Length))
                    {
                        FileEncDec.Encrypt(item.SubItems[0].Text, FileEncDec.EncryptToArrayInt( item.SubItems[0].Text, textBox1.Text) + ".crypt", textBox1.Text);
                    }
                    else
                    {
                        FileEncDec.Encrypt(item.SubItems[0].Text, item.SubItems[0].Text + ".crypt", textBox1.Text);
                    }    
                    if(checkBox1.Checked) explorer.delete(item.SubItems[0].Text);
                }
            }
            //перезагрузим текущую дирректорию            
            explorer.Explorer(listView1, Directory.GetCurrentDirectory());
            textBox2.Text = Directory.GetCurrentDirectory();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectitem = listView1.SelectedItems;
            foreach (ListViewItem item in selectitem)
            {
                if (!(item.SubItems[0].BackColor == Color.Aqua && item.SubItems[0].BackColor == Color.GreenYellow && !(item.SubItems[0].BackColor == Color.Red)))
                {
                    bool error = false;
                    //если стоит галочка шифровать имена файлов
                    if (checkBox2.Checked )
                    {
                        error = FileEncDec.Decrypt(item.SubItems[0].Text, FileEncDec.DecryptArrayInt(item.SubItems[0].Text.Remove(item.SubItems[0].Text.Length - ".crypt".Length), textBox1.Text), textBox1.Text);
                    }
                    else
                    {
                        error = FileEncDec.Decrypt(item.SubItems[0].Text, item.SubItems[0].Text.Remove(item.SubItems[0].Text.Length - ".crypt".Length), textBox1.Text);
                    }                   
                    if (checkBox1.Checked && !error) explorer.delete(item.SubItems[0].Text);
                }
            }
            //перезагрузим текущую дирректорию
            explorer.Explorer(listView1, Directory.GetCurrentDirectory());
            textBox2.Text = Directory.GetCurrentDirectory();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //перезагрузим текущую дирректорию
            explorer.Explorer(listView1, Directory.GetCurrentDirectory());
            textBox2.Text = Directory.GetCurrentDirectory();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("you really want to delete files ? ", "Delete file", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if(result == DialogResult.OK)
            {
                ListView.SelectedListViewItemCollection selectitem = listView1.SelectedItems;
                foreach (ListViewItem item in selectitem)
                {
                    if (!(item.SubItems[0].BackColor == Color.Aqua || item.SubItems[0].BackColor == Color.GreenYellow))
                    {
                        explorer.delete(item.SubItems[0].Text);
                    }
                }
                //перезагрузим текущую дирректорию
               // var temp = listView1.AutoScrollOffset;
                explorer.Explorer(listView1, Directory.GetCurrentDirectory());
                textBox2.Text = Directory.GetCurrentDirectory();
               // listView1.AutoScrollOffset = temp;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            explorer.Explorer(listView1,textBox2.Text);
            textBox2.Text = Directory.GetCurrentDirectory();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            explorer.Explorer(listView1, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            textBox2.Text = Directory.GetCurrentDirectory();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = false;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
        }
    }
}
