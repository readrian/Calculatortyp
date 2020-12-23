using System;

namespace Calculatortyp
{
    class Program
    {
        static string input()
        {
            Console.WriteLine("Input your calculation: ");
            string input = Console.ReadLine();
            return input;
        }

        static string rems(string input)
        {
            int counter = 0;
            char[] charArray = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                while (!(charArray[i] >= 42 && charArray[i] <= 57))
                {
                    for (int k = i; k < charArray.Length - 1; k++)
                    {
                        charArray[k] = charArray[k + 1];
                    }
                    counter++;
                }
            }
            char[] charArray1 = new char[charArray.Length - counter];
            for (int i = 0; i < charArray1.Length; i++)
            {
                charArray1[i] = charArray[i];
            }
            return new string(charArray1);
        }

        static string calc(string input)
        {
            char[] charArray = input.ToCharArray();
            int removed = 0;
            int switchover = 0;
            int counter1 = 1;
            int counter2 = 0;
            int switchcounter = 0;
            for (int i = 0; i < charArray.Length - 1; i++)
            {
              
                counter1 = 0;
                counter2 = 0;
                int c1m = 1, c2m = 1;
                int temp = 0;
                int r1 = 0, r2 = 0;


                if (((charArray[i] == '*' || charArray[i] == '/') && switchover == 0) || (charArray[i] == '+' || charArray[i] == '-') && switchover == 1)
                {
                    for (int k = i + 1; !(charArray[k] == '+' || charArray[k] == '-' || charArray[k] == '*' || charArray[k] == '/' || charArray[k] == '#'); k++)
                    {
                        counter1++;
                        if (k == charArray.Length - 1)
                            break;
                    }
                    for (int k = i - 1; !(charArray[k] == '+' || charArray[k] == '-' || charArray[k] == '*' || charArray[k] == '/' || charArray[k] == '#'); k--)
                    {
                        counter2++;
                        if (k == 0)
                            break;
                    }

                    for (int e = 0; e < counter1 - 1; e++)
                        c1m = c1m * 10;

                    for (int x = i + 1; x < i + counter1 + 1; x++)
                    {
                        temp = Convert.ToInt32(Char.GetNumericValue(charArray[x]));
                        temp = temp * c1m;
                        r1 = r1 + temp;
                        c1m = c1m / 10;
                    }

                    for (int x = i - 1; x > (i - counter2 - 1); x--)
                    {
                        temp = Convert.ToInt32(Char.GetNumericValue(charArray[x]));
                        temp = temp * c2m;
                        r2 = r2 + temp;
                        c2m = c2m * 10;
                    }
                    int cl = 0;
                    switch (charArray[i])
                    {
                        case '+':
                            cl = r2 + r1;
                            break;
                        case '-':
                            cl = r2 - r1;
                            break;
                        case '*':
                            cl = r2 * r1;
                            break;
                        case '/':
                            cl = r2 / r1;
                            break;
                        default:
                            break;
                    }
                    int cllen = cl.ToString().Length;

                    string scl = cl.ToString();

                    char[] charArraytmp = scl.ToCharArray();

                    int z = 0;
                    for (int x = i - counter2; x < (i - counter2 + cllen); x++)
                    {
                        charArray[x] = charArraytmp[z];
                        z++;
                    }

                    int r = 0;
                    for (int x = (i - counter2 + cllen); x < charArray.Length; x++)
                    {
                        if ((i + counter1 + 1 + r) == charArray.Length)
                        {
                            break;
                        }
                        charArray[x] = charArray[i + counter1 + 1 + r];
                        r++;
                    }
                    removed = (removed + counter1 + counter2 + 1) - cllen;
                    for (int x = charArray.Length - removed; x < charArray.Length; x++)
                    {
                        charArray[x] = '#';
                        i = -1;
                        switchcounter = 0;
                    }
                    
                }
                if (counter1 == 0)
                {
                    switchcounter++;
                }

                if ((switchcounter >= (charArray.Length - 1)) && switchover == 0)
                {
                    switchover = 1;
                    i = -1;
                    switchcounter = 0;
                }
                if (switchcounter >= charArray.Length - 1 && switchover == 1)
                {
                    i = 99999;
                }
            }
            char[] charArray1 = new char[charArray.Length-removed];
            for (int x = 0; x < charArray1.Length; x++)
            {
                charArray1[x] = charArray[x];
            }
            return new string(charArray1);
        }


        static void Main(string[] args)
        {
            string inp = input();
            inp = rems(inp);
            Console.WriteLine(calc(inp));
        }
    }
}
