using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssb_notes_wf
{
    public class Character
    {
        /// <summary>
        /// create a charater with its logo, full picture and information file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logoPath"></param>
        /// <param name="picturePath"></param>
        /// <param name="informationsPath"></param>
        public Character(string name, string logoPath, string picturePath, string informationsPath)
        {
            this.Name = name;
            this.Path = logoPath.Substring(0, logoPath.LastIndexOf(@"\"));
            this.LogoPath = logoPath;
            this.PicturePath = picturePath;
            this.InformationsPath = informationsPath;
        }
        
        public string Path { get; private set; }
        public string Name { get; private set; }
        public string LogoPath { get; private set; }
        public string PicturePath { get; private set; }
        public string InformationsPath { get; private set; }
    }
}
