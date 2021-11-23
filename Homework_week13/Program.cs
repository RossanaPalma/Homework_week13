/// Chapter No. 25 - Homework13
/// File Name: Homework12.java
/// @author: Rossana Palma
/// Date:  November 20, 2021
///
/// Problem Statement: Write a program that reads both the girl’s and boy’s 
/// files into memory using a dictionary.  The key should be the name and 
/// value should be a user defined object which is the count and rank of 
/// the name.  Allow the user to input a name, the program should find the 
/// name in the dictionary and print out the rank and the number of namings. 
/// If the name isn’t a key in the dictionary then the program should note 
/// this and say that no match exists.
///
/// Overall Plan:
/// 1) Create string variables
/// 2) Create dictionary to read files name
/// 3) Create a class Name with properties for Rank and Count
/// 4) Prompt the user to type a name
/// 5) Create a function to find the name in dictionary
/// 6) Create a function to display a rank
/// 7) Display the result on the screen



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Homework_week13
{
    class Program
    {
        private const string boyNamesFile = "boynames.txt";
        private const string girlNamesFile = "girlnames.txt";
        static void Main(string[] args)
        {
            char[] chars = { ' ' };
            Dictionary<string, Name> boyNames = readFile(boyNamesFile);
            Dictionary<string, Name> girlNames = readFile(girlNamesFile);


            while (checkInput(boyNames, girlNames))
            {

            }
        }

        private static Dictionary<string, Name> readFile(string filename)
        {
            Dictionary<string, Name> dic1 = new Dictionary<string, Name>();
            char[] chars = { ' ' };
            //Reading the file
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                int count = 1;

                while((line = sr.ReadLine()) != null)
                {
                    string[] lineData = line.Split(chars);
                    Name inputName = new Name();
                    inputName.Rank = count;
                    inputName.Count = Int32.Parse(lineData[1]);
                    dic1.Add(lineData[0].ToLower(), inputName);
                    count++;
                }
            }
            return dic1;
        }

        private static bool checkInput(Dictionary<string, Name> boyNames, Dictionary<string, Name> girlsNames)
        {
            
            Console.Write("\nType name:\n");
            string input = Console.ReadLine();
            input = input.ToLower();
            
            if (input.Equals("quit".ToLower()) || input.Equals("q".ToLower()))
            {
                return false;
            }
           

            displayRank(input, boyNames, "boys");
            displayRank(input, girlsNames, "girls");
                      
            return true;
        }
        
        private static void displayRank(string name, Dictionary<string, Name> dict, string gender)
        {
            Name inputName = null;
            if (dict.ContainsKey(name))
            {
                inputName = dict[name];
            }

            name = name.Substring(0, 1).ToUpper() + name.Substring(1);
            if (inputName == null)
            {
                Console.WriteLine("{0} is not ranked among the top 1000 {1} names.", name, gender);
                 //"Walter is not ranked among the top 1000 girl names.
            }
            else  
            {
                Console.WriteLine("{0} is ranked {1} in popularity among {2} with {3} namings.",
                    name, inputName.Rank, gender, inputName.Count);
                //Walter is ranked 356 in popularity among boys with 775 namings.
            }
        }
        
    }
}
