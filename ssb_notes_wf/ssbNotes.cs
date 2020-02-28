using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ssb_notes_wf
{
    public partial class ssbNotes : Form
    {
        List<Character> characters;
        List<PictureBox> charactersPictureBoxes;
        Point sizePictures = new Point(70, 70);
        Character actualCharacter;
        public ssbNotes()
        {
            InitializeComponent();
        }

        private void ssbNotes_Load(object sender, EventArgs e)
        {
            Reload_form();
        }
        private void Reload_form()
        {
            CreateCharacters();
            CreatePictureBoxes();
            foreach (PictureBox box in charactersPictureBoxes)
            {
                this.Controls.Add(box);
            }
            bgInformation.Size = this.Size;
        }
        private void ssbNotes_Resize(object sender, EventArgs e)
        {
            CalculateLocationPictureBoxes(this.Width);
            bgInformation.Size = this.Size;
            CalculateLocationInformationsBoxes(this.Width);
        }

        private void CreateCharacters()
        {
            characters = new List<Character>();
            string[] dirs = Directory.GetDirectories(Directory.GetCurrentDirectory());

            foreach (string dir in dirs)
            {
                if (new Regex(@"^ex[ea]mple$", RegexOptions.IgnoreCase).Match(new DirectoryInfo(dir).Name).Success)
                    continue;

                string[] files = Directory.GetFiles(dir);
                Character character = new Character(
                    name: new Regex(@"[0-9]+\.").Replace(new DirectoryInfo(dir).Name.Replace("_", " ").ToLower(), ""),
                    logoPath: Array.Find(files, x => new Regex("logo((.png)|(.jpeg)|(.jpg)|(.gif))").Match(x).Success),
                    picturePath: Array.Find(files, x => new Regex("details((.png)|(.jpeg)|(.jpg)|(.gif))").Match(x).Success),
                    informationsPath: Array.Find(files, x => new Regex("informations((.txt)|(.md))", RegexOptions.IgnoreCase).Match(x).Success)
                );
                characters.Add(character);
            }
        }
        private void CalculateLocationInformationsBoxes(int maxWidth)
        {
            int margin = 40;

            characterPicture.Width = this.Width / 2 - margin * 2;
            characterPicture.Height = this.Height - margin * 2;
            characterPicture.Location = new Point(margin, margin);

            characterInformations.Width = this.Width / 2 - margin * 2;
            characterInformations.Height = this.Height - margin * 3;
            characterInformations.Location = new Point(margin * 3 + characterInformations.Width, margin);

            cmdSend.Location = new Point(characterInformations.Location.X + characterInformations.Width - cmdSend.Width, 5 + characterInformations.Location.Y + characterInformations.Height);
        }
        private void CalculateLocationPictureBoxes(int maxWidth)
        {
            int margin = 10;

            maxWidth -= System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            int x = margin;
            int y = margin + 50; //50 is space for search bar

            foreach (PictureBox box in charactersPictureBoxes)
            {
                if (x + margin + box.Width > maxWidth)
                {
                    x = margin;
                    y += sizePictures.Y + margin;
                }
                box.Location = new Point(x, y);
                x += sizePictures.X + margin;
            }
        }
        private void CreatePictureBoxes()
        {
            charactersPictureBoxes = new List<PictureBox>();
            foreach (Character character in characters)
            {
                PictureBox box = new PictureBox();

                box.Name = character.Name;
                try
                {
                    box.Image = Image.FromFile(character.LogoPath);
                }
                catch
                {
                    MessageBox.Show($"1. Veuillez créer dans votre dossier un fichier logo.png (dimensions: {sizePictures.X} x {sizePictures.Y}).\n2. Attention au format, il se peut que ce ne soit pas du véritable PNG...");
                }
                box.Width = sizePictures.X;
                box.Height = sizePictures.Y;
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.BackColor = Color.Transparent;
                box.Click += Logo_Click;

                charactersPictureBoxes.Add(box);
            }
            CalculateLocationPictureBoxes(this.Width);
            CalculateLocationInformationsBoxes(this.Width);
        }

        private  void Show_Informations(Character character)
        {
            this.AutoScroll = false;
            bgInformation.Visible = true;
            try
            {
                characterPicture.Image = Image.FromFile(character.PicturePath);
            }
            catch
            {
                MessageBox.Show($"1. Veuillez créer dans votre dossier un fichier details.png, celui-ci correspond à votre personnage complet.\n2. Attention au format, il se peut que ce ne soit pas du véritable PNG...");
            }

            characterPicture.Visible = true;
            characterPicture.BringToFront();
            characterPicture.SizeMode = PictureBoxSizeMode.Zoom;

            LoadFile(character.InformationsPath);

            characterInformations.Visible = true;
            characterInformations.BringToFront();
            cmdSend.Visible = true;
            cmdSend.BringToFront();
            actualCharacter = character;
            cmdSend.Click += CmdSend_ClickAsync;
            characterInformations.Focus();
        }

        private async void CmdSend_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await FileReader.Write(actualCharacter.InformationsPath, characterInformations.Text);
            }
            catch
            {
                MessageBox.Show($"Fichier illisible ou inexistant, veuillez créer dans votre dossier un fichier informations.txt");
            }
            Close_Informations();
        }

        private async void LoadFile(string file)
        {
            characterInformations.Text = await FileReader.Read(file);
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            var logo = sender as PictureBox;
            Show_Informations(characters.Find(x => x.Name == logo.Name));
        }

        private void bgInformation_Click(object sender, System.EventArgs e)
        {
            Close_Informations();
        }
        private void Close_Informations()
        {

            cmdSend.Click -= CmdSend_ClickAsync;
            this.bgInformation.BringToFront();

            this.characterInformations.Visible = false;
            this.characterPicture.Visible = false;
            this.bgInformation.Visible = false;
            this.AutoScroll = true;
            this.cmdSend.Visible = false;
            this.Focus();
        }

        private void ssbNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (bgInformation.Visible == true)
                    Close_Informations();
                else
                    this.Close();
            else if (e.KeyCode == Keys.F5)
                Reload_form();
        }

        private void characterInformations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close_Informations();
            else if (e.Control && e.KeyCode == Keys.S)
                cmdSend.PerformClick();
        }
    }
}
