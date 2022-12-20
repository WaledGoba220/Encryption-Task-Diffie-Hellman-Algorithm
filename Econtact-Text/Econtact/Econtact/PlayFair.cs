using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact
{
    public class PlayFair
    {
        string alphapit = "abcdefghijklmnopqrstuvwxyz";
        String[,] play = new String[5, 5];
        public String encrypt(String[] input, String[] key)
        {
            String[] output = new String[input.Length * 2];
            fill(key);
            //output array flag
            int mindex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i == (input.Length - 1))
                {
                    int[] index = getIndexOf(input[i], "x");
                    if (index[0] == index[2])
                    {
                        output[mindex] = play[index[2], (index[1] + 1) % 5];
                        output[mindex + 1] = play[index[0], (index[3] + 1) % 5];
                    }
                    else if (index[1] == index[3])
                    {
                        output[mindex + 1] = play[(index[2] + 1) % 5, index[1]];
                        output[mindex] = play[(index[0] + 1) % 5, index[3]];
                    }
                    else
                    {
                        output[mindex] = play[index[0], index[3]];
                        output[mindex + 1] = play[index[2], index[1]];
                    }

                }
                else if (i + 1 < input.Length)
                {
                    if (alphapit.IndexOf(input[i]) != -1 && alphapit.IndexOf(input[i + 1]) != -1)
                    {

                        if (input[i] == input[i + 1])
                        {
                            int[] index = getIndexOf(input[i], "x");
                            if (index[0] == index[2])
                            {
                                output[mindex] = play[index[2], (index[1] + 1) % 5];
                                output[mindex + 1] = play[index[0], (index[3] + 1) % 5];
                            }
                            else if (index[1] == index[3])
                            {
                                output[mindex + 1] = play[(index[2] + 1) % 5, index[1]];
                                output[mindex] = play[(index[0] + 1) % 5, index[3]];
                            }
                            else
                            {
                                output[mindex] = play[index[0], index[3]];
                                output[mindex + 1] = play[index[2], index[1]];
                            }
                            mindex = mindex + 2;
                        }
                        else
                        {
                            int[] index = getIndexOf(input[i], input[i + 1]);
                            if (index[0] == index[2])
                            {
                                output[mindex] = play[index[2], (index[1] + 1) % 5];
                                output[mindex + 1] = play[index[0], (index[3] + 1) % 5];
                            }
                            else if (index[1] == index[3])
                            {
                                output[mindex + 1] = play[(index[2] + 1) % 5, index[1]];
                                output[mindex] = play[(index[0] + 1) % 5, index[3]];
                            }
                            else
                            {
                                output[mindex] = play[index[0], index[3]];
                                output[mindex + 1] = play[index[2], index[1]];
                            }
                            i++;
                            mindex = mindex + 2;
                        }
                    }
                    else if (alphapit.IndexOf(input[i]) != -1 && alphapit.IndexOf(input[i + 1]) == -1)
                    {
                        input[i + 1] = input[i];
                    }
                }
            }
            trimArr(output);
            return string.Join("", output);
        }
        public String decrypt(String[] input, String[] key)
        {
            String[] output = new String[input.Length * 2];
            fill(key);
            int mindex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i == (input.Length - 1))
                {
                    int[] index = getIndexOf(input[i], "x");
                    if (index[0] == index[2])
                    {
                        output[mindex] = play[index[2], (index[1] > 0) ? index[1] - 1 : 4];
                        output[mindex + 1] = play[index[0], (index[3] > 0) ? index[3] - 1 : 4];
                    }
                    else if (index[1] == index[3])
                    {
                        output[mindex] = play[(index[2] > 0) ? index[2] - 1 : 4, index[1]];
                        output[mindex + 1] = play[(index[0] > 0) ? index[0] - 1 : 4, index[3]];
                    }
                    else
                    {
                        output[mindex] = play[index[0], index[3]];
                        output[mindex + 1] = play[index[2], index[1]];
                    }

                }
                else if ((i + 1) < input.Length)
                {
                    if (alphapit.IndexOf(input[i]) != -1 && alphapit.IndexOf(input[i + 1]) != -1)
                    {
                        if (input[i] == input[i + 1])
                        {
                            int[] index = getIndexOf(input[i], "x");
                            if (index[0] == index[2])
                            {
                                output[mindex] = play[index[2], (index[1] > 0) ? index[1] - 1 : 4];
                                output[mindex + 1] = play[index[0], (index[3] > 0) ? index[3] - 1 : 4];
                            }
                            else if (index[1] == index[3])
                            {
                                output[mindex] = play[(index[2] > 0) ? index[2] - 1 : 4, index[1]];
                                output[mindex + 1] = play[(index[0] > 0) ? index[0] - 1 : 4, index[3]];
                            }
                            else
                            {
                                output[mindex] = play[index[0], index[3]];
                                output[mindex + 1] = play[index[2], index[1]];
                            }
                            mindex = mindex + 2;
                        }
                        else
                        {
                            int[] index = getIndexOf(input[i], input[i + 1]);
                            if (index[0] == index[2])
                            {
                                output[mindex] = play[index[2], (index[1] > 0) ? index[1] - 1 : 4];
                                output[mindex + 1] = play[index[0], (index[3] > 0) ? index[3] - 1 : 4];
                            }
                            else if (index[1] == index[3])
                            {
                                output[mindex + 1] = play[(index[2] > 0) ? index[2] - 1 : 4, index[1]];
                                output[mindex] = play[(index[0] > 0) ? index[0] - 1 : 4, index[3]];
                            }
                            else
                            {
                                output[mindex] = play[index[0], index[3]];
                                output[mindex + 1] = play[index[2], index[1]];
                            }
                            i++;
                            mindex = mindex + 2;
                        }
                    }
                    else if (alphapit.IndexOf(input[i]) != -1 && alphapit.IndexOf(input[i + 1]) == -1 && (i + 1) < input.Length)
                    {
                        input[i + 1] = input[i];
                    }
                }
            }
            trimArr(output);
            return string.Join("", output);
        }
        public void fill(String[] array)
        {
            int length = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (alphapit.IndexOf(array[i]) != -1)
                {
                    if (array[i] == "i" || array[i] == "j")
                    {
                        int index = getIndex("i");
                        if (index == 1)
                        {

                        }
                        else
                        {
                            play[length / 5, length % 5] = "i";
                            length++;
                        }

                    }
                    else
                    {
                        int index = getIndex(array[i]);
                        if (index == 1)
                        {

                        }
                        else
                        {
                            play[length / 5, length % 5] = array[i];
                            length++;
                        }

                    }
                }
            }
            int row = length / 5;
            int column = length % 5;
            for (int k = 0; k < alphapit.Length; k++)
            {

                if (alphapit[k].ToString() == "i" || alphapit[k].ToString() == "j")
                {
                    int index = getIndex("i");
                    if (index == 1)
                    {

                    }
                    else
                    {
                        play[row, column] = "i";
                        column += 1;
                        if (column >= 5)
                        {
                            column = 0;
                            row += 1;
                        }
                    }
                }
                else
                {
                    int index = getIndex(alphapit[k].ToString());
                    if (index == 1)
                    {

                    }
                    else
                    {
                        play[row, column] = alphapit[k].ToString();
                        column += 1;
                        if (column >= 5)
                        {
                            column = 0;
                            row += 1;
                        }
                    }
                }

            }
        }
        int getIndex(String char1)
        {
            int index = 0;
            for (int i = 0; i < 5; i++)
                for (int k = 0; k < 5; k++)
                {
                    try
                    {
                        if (play[i, k] == char1)
                        {
                            index = 1;
                            break;
                        }
                        else
                        {

                        }
                    }
                    catch (Exception) { }
                }
            return index;
        }
        int[] getIndexOf(String char1, String char2)
        {
            int[] index = new int[4];
            if (char1 == "i" || char1 == "j")
            {
                char1 = "i";
            }

            if (char2 == "i" || char2 == "j")
            {
                char2 = "i";
            }
            for (int i = 0; i < 5; i++)
                for (int k = 0; k < 5; k++)
                {
                    try
                    {
                        if (play[i, k] == char1)
                        {
                            index[0] = i;
                            index[1] = k;
                        }
                        else if (play[i, k] == char2)
                        {
                            index[2] = i;
                            index[3] = k;
                        }
                        else
                        {

                        }
                    }
                    catch (Exception) { }
                }
            return index;
        }
        void trimArr(String[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    arr[i] = "";
                }
            }
        }
    }
}
