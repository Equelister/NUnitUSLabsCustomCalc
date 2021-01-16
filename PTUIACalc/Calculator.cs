using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PTUIACalc
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(sum("//[;]\n1;-2\n9;-10"));
        }

        public static double sum(string text)
        {
            double result = 0;
            string separator = ",";
            string errorString = "";
            string tempSeparator = "";
            List<string> separatorList = new List<string>();
            string[] separatorTable;

            try
            {
                //check and set new separator
                if (text.Length > 4)
                {
                    if (text[0] == '/' && text[1] == '/' && text[2] == '[' && text[text.LastIndexOf(']')+1] == '\n')
                    {
                        if(text.Split(']').Length - 1 == text.Split('[').Length - 1)
                        {
                            bool onlyDigits = true;
                            int parametersCount = text.Split(']').Length - 1;
                            for (int i = 0; i < parametersCount; i++)
                            {
                                separatorList.Add(text.Split('[', ']')[1]);
                                text = text.Substring(text.IndexOf(']') + 1);
                            }
                            text = text.Substring(text.IndexOf('\n') + 1);
                        }
                    }
                }

                //checks for negative numbers
                if (text.Contains('-'))
                {
                    bool isMinusInList = false;
                    foreach (string str in separatorList)
                    {
                        if (str.Contains('-'))
                        {
                            isMinusInList = true;
                            break;
                        }
                    }

                    if (isMinusInList == false)
                    {


                        List<String> negativeNumbersList = new List<String>();
                        errorString = "Parameter cannot be negative: ";
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (text[i] == '-')
                            {
                                errorString += text[i].ToString() + text[i + 1].ToString() + ", ";
                                negativeNumbersList.Add(text[i].ToString() + text[i + 1].ToString());
                            }
                        }
                        errorString = errorString.Remove(errorString.LastIndexOf(','), 2) + '.';
                        throw new ArgumentException(errorString);
                    }
                }


                //add digits
                separatorList.Add("\n");
                separatorList.Add(separator);
                separatorTable = separatorList.ToArray();
                string[] strArray = text.Split(separatorTable, StringSplitOptions.None);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (Convert.ToDouble(strArray[i]) > 1000 == false)
                    {
                        result += Convert.ToDouble(strArray[i]);
                    }
                }


            }
            catch (NullReferenceException nulle)
            {
                throw new NullReferenceException("Null parameter");
            }
            catch (ArgumentException arge)
            {
                throw new ArgumentException(errorString);
            }
            catch (Exception e)
            {

            }

            return result;
        }
    }
}
