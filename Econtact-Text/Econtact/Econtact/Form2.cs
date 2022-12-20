using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Econtact
{
    public partial class Form2 : Form
    {
        PlayFair pF = new PlayFair();
        public Form2()
        {
            InitializeComponent();
        }

        // Caesar Cipher
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
                return ch;

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }

        public static string caesarCipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        /// ///////////////////////////////////////////////////////////////

        // Polyalphabetic Cipher
        public static String generateKey(String str, String key)
        {
            int x = str.Length;

            for (int i = 0; ; i++)
            {
                if (x == i)
                    i = 0;
                if (key.Length == str.Length)
                    break;
                key += (key[i]);
            }
            return key;
        }

        public static String cipherText(String str, String key)
        {
            String cipher_text = "";

            for (int i = 0; i < str.Length; i++)
            {
                // converting in range 0-25
                int x = (str[i] + key[i]) % 26;

                // convert into alphabets(ASCII)
                x += 'A';

                cipher_text += (char)(x);
            }
            return cipher_text;
        }

        static String originalText(String cipher_text, String key)
        {
            String orig_text = "";

            for (int i = 0; i < cipher_text.Length &&
                                    i < key.Length; i++)
            {
                // converting in range 0-25
                int x = (cipher_text[i] -
                            key[i] + 26) % 26;

                // convert into alphabets(ASCII)
                x += 'A';
                orig_text += (char)(x);
            }
            return orig_text;
        }

        /// ///////////////////////////////////////////////////////////////

        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
            // Monoalphabetic Cipher
            string key1 = "zyxwvutsrqponmlkjihgfedcbaABCDEFGHIJKLMNOPQRSTUVWXYZ";
            key.Text = key1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = txt.Text;
            string k = key.Text;

            // Caesar Cipher
            if (rd1.Checked == true)
                result.Text = caesarCipher(text, int.Parse(k));

            // Monoalphabetic Cipher
            else if (rd2.Checked == true)
            {
                string key1 = key.Text;

                char[] chars = new char[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == ' ')
                    {
                        chars[i] = ' ';
                    }

                    else
                    {
                        int j = text[i] - 97;
                        chars[i] = key1[j];
                    }
                }

                result.Text = new string(chars);
            }

            // Polyalphabetic Cipher
            else if (rd3.Checked == true)
            {
                string key = generateKey(text, k);
                result.Text = cipherText(text, key);
            }

            // Playfair Cipher
            else if (rd4.Checked == true)
            {
                result.Text = pF.encrypt(text.ToCharArray().Select(c => c.ToString()).ToArray(), "abcdijf".ToCharArray().Select(c => c.ToString()).ToArray());
            }

            else
                result.Text = "Choose the type of encryption";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = txt.Text;
            string k = key.Text;

            // Caesar Cipher
            if (rd1.Checked == true)
                result.Text = caesarCipher(text, 26 - int.Parse(k));

            // Monoalphabetic Cipher
            else if (rd2.Checked == true)
            {
                char[] chars = new char[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == ' ')
                    {
                        chars[i] = ' ';
                    }
                    else
                    {
                        int j = k.IndexOf(text[i]) + 97;
                        chars[i] = (char)j;
                    }
                }
                result.Text = new string(chars);
            }

            // Polyalphabetic Cipher
            else if (rd3.Checked == true)
            {
                string key = generateKey(text, k);
                result.Text = originalText(text, key);
            }

            // Playfair Cipher
            else if (rd4.Checked == true)
            {
                result.Text = pF.decrypt(text.ToCharArray().Select(c => c.ToString()).ToArray(), "abcdf".ToCharArray().Select(c => c.ToString()).ToArray());
            }

            else
                result.Text = "Choose the type of encryption";
        }


    }
}
