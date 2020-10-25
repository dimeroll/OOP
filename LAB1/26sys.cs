using System;
using System.Collections.Generic;
using System.Text;

namespace LabCalculator
{
    public class _26Sys
    {
        public static string To26Sys(int num)
        {
            int j = 0;
            int[] arr = new int[100];
            while(num > 25)
            {
                arr[j] = num / 26 - 1;
                j++;
                num = num % 26;
            }
            arr[j] = num;
            string res = "";
            for(int r = 0; r<=j; r++)
            {
                res += ((char)('A' + arr[r])).ToString();
            }
            return res;
        }

        public static int[] From26Sys(string index)
        {
            int[] nums = new int[2];
            string first_part = "";
            int letteridx = 0;
            foreach(char c in index)
            {
                if (Char.IsLetter(c))
                {
                    first_part += c;
                    letteridx++;
                    continue;
                }

                char[] arr = first_part.ToCharArray();
                int length = arr.Length;
                int rez = 0;
                for(int i = length - 2; i>=0; i--)
                {
                    rez += (arr[i] - 'A' + 1) * Convert.ToInt32(Math.Pow(26, length-1-i));
                }
                rez += arr[length - 1] - 'A';
                nums[0] = rez;
                break;
            }
            nums[1] = Convert.ToInt32(index.Substring(letteridx));
            return nums;
        }
    }
}
