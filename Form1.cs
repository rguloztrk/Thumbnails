using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }        

        int LenLocal;    

       

        private void MenuAddImages_Click(object sender, EventArgs e)
        {
            Images();                      
        }

        private void Images()
        {           

            FolderBrowserDialog folder = new FolderBrowserDialog();
            
            if (folder.ShowDialog() == DialogResult.OK)
            {
                
                LenLocal = folder.SelectedPath.Length;
                #region KlasörSeçimi
                /*String[] LogImg = new String[500];
                LogImg = Directory.GetFiles(folder.SelectedPath, "*.jpg", SearchOption.TopDirectoryOnly);
                for (int count = 0; count < LogImg.Length; count++)
                {
                    PictureBox pcb = new PictureBox();


                    pcb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pcb.ImageLocation = LogImg[count];


                    pcb.Height = 100;
                    pcb.Width = 120;

                    pcb.MouseMove += new MouseEventHandler(move);
                    pcb.MouseLeave += new EventHandler(leave);
                    pcb.Click += new EventHandler(clique);
                    //fPanel.Controls.Add(pcb);


                }*/
                #endregion

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images (*.BMP;*.JMP;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
                ofd.Multiselect = true;//ctrl den coklu seçim için
                DialogResult result = ofd.ShowDialog(); 
                if (result == DialogResult.OK) 
                {
                                      
                        foreach (string item in ofd.FileNames)
                        {

                            PictureBox pcb = new PictureBox();

                            pcb.SizeMode = PictureBoxSizeMode.StretchImage;
                            pcb.ImageLocation = item;

                            pcb.Image = Image.FromFile(item);
                            pcb.Height = 100;
                            pcb.Width = 120;

                            pcb.MouseMove += new MouseEventHandler(move);
                            pcb.MouseLeave += new EventHandler(leave);
                            pcb.Click += new EventHandler(clique);
                            fPanel.Controls.Add(pcb);
                            
                        }
                   
                }
                                                        
                                
            }

           
        }

        private void move(object sender, EventArgs e)//resimlerin üzerine mause geldiğinde büyüten kod kısmı
        {
            PictureBox pcb = (PictureBox)sender;
           
            string Nome = pcb.ImageLocation.Remove(0, LenLocal + 1);

            pcb.Width = 200;
            pcb.Height = 200;
           
        }

        private void leave(object sender, EventArgs e)
        {
            PictureBox pcb = (PictureBox)sender;

            pcb.Height = 100;
            pcb.Width = 120;
            pcb.Refresh();
        }

        private void clique(object sender, EventArgs e)//resmin orjinal halini gösterdiğimiz yer
        {
            PictureBox pcb = (PictureBox)sender;
            string Nome = pcb.ImageLocation.Remove(0, LenLocal + 1);

            Form frm = new Form();
            frm.Width = pcb.Image.Width + 15;
            frm.Height = pcb.Image.Height + 30;
            frm.BackgroundImage = pcb.Image;
            frm.BackgroundImageLayout = ImageLayout.Stretch;
            frm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
           
            frm.Text = Nome;

            frm.ShowDialog();
        }

           
        

       
    }
}
