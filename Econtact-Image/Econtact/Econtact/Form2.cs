using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


// package to get techninque to get convert image
using System.Security.Cryptography;
using System.IO;

namespace Econtact
{
    public partial class Form2 : Form
    {
        string key;
        public Form2()
        {
            InitializeComponent();
            key = generateKey();
        }

        public string generateKey()
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            txtLocalEncFile.Text = open.FileName;

            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();

            txtNewEncFile.Text = save.FileName;

            encrypt(txtLocalEncFile.Text, txtNewEncFile.Text, key);
        }

        private void encrypt(string input, string output, string strHash)
        {
            FileStream inStream, outStream;
            CryptoStream CryStream;
            TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteTexto;

            inStream = new FileStream(input, FileMode.Open, FileAccess.Read);
            outStream = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);

            byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strHash));
            byteTexto = File.ReadAllBytes(input);

            md5.Clear();

            TDC.Key = byteHash;
            TDC.Mode = CipherMode.ECB;

            CryStream = new CryptoStream(outStream, TDC.CreateEncryptor(), CryptoStreamMode.Write);

            int bytesRead;
            long length, postion = 0;
            length = inStream.Length;

            while(postion < length)
            {
                bytesRead = inStream.Read(byteTexto, 0, byteTexto.Length);
                postion += bytesRead;

                CryStream.Write(byteTexto, 0, bytesRead);
            }

            inStream.Close();
            outStream.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            txtLocalDecFile.Text = open.FileName;

            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();

            txtNewDecFile.Text = save.FileName;

            decrypt(txtLocalDecFile.Text, txtNewDecFile.Text, key);
        }

        private void decrypt(string input, string output, string strHash)
        {
            FileStream inStream, outStream;
            CryptoStream CryStream;
            TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteTexto;

            inStream = new FileStream(input, FileMode.Open, FileAccess.Read);
            outStream = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);

            byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strHash));
            byteTexto = File.ReadAllBytes(input);

            md5.Clear();

            TDC.Key = byteHash;
            TDC.Mode = CipherMode.ECB;

            CryStream = new CryptoStream(outStream, TDC.CreateDecryptor(), CryptoStreamMode.Write);

            int bytesRead;
            long length, postion = 0;
            length = inStream.Length;

            while (postion < length)
            {
                bytesRead = inStream.Read(byteTexto, 0, byteTexto.Length);
                postion += bytesRead;

                CryStream.Write(byteTexto, 0, bytesRead);
            }

            inStream.Close();
            outStream.Close();
        }

    }
}
