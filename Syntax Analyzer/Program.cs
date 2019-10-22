using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Syntax_Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";

            Console.WriteLine("====================:Syntax Analyzer:======================\n");

            try
            {
                string  filePath = "C:/Users/Faraz_Ahmed/code.txt";

                string _for = @"^for\(((int\s)|(float\s)|(char\s))?\w+=(\d|\w)+;\w+(=|<=|>=|<|>)(\d|\w)+;\w+(\+\+|--)?\)$";
                string _while = @"^while{1}\(\w+(=|<=|>=|>|<|!=|==)(\d|\w)+\)$";
                string _print = @"^(print.this){1}\((\w*\s*\d*)*\);$";
                string _input = @"^(\w)+=(input.this){1}\((\w*\s*\d*)*\);$";
                string _dowhile = @"^do{1}\{(print.this){1}\([0-9a-zA-Z]*\);\}$";
                string _if = @"^if{1}\s?\(\w+(=|<=|>=|>|<|!=|==)(\d|\w)+\)\{(print.this){1}\((\w*\s*\d*)*\);}$";
                string _elif = @"^else{1}\s{1}if{1}\(\w+(=|<=|>=|>|<|!=|==)(\d|\w)+\)\{(print.this){1}\((\w*\s*\d*)*\);}$";
                string _else = @"^else\s{1}(print.this){1}\((\w*\s*\d*)*\);$";
                string _main = @"void main()";
                string _main1 = "void main(void)";

                string _sw = @"^switch\(\w+\){$";
                string _case = @"^case\s(\d)+:+$";
                string _break = @"^break{1};$";
                string _continue = @"^continue{1};$";
                string _decl = @"^(int\s|float\s|char\s){1}(\w+,*)+;$";
                string _dasign = @"^(int\s|float\s|char\s)\w+=(\d|\w)+;$";
                string _asig = @"^(\w+)=(\d|\w)+;$";
                string _deflt = @"^}\s*default:\s*(print.this){1}\((\w*\s*\d*)*\);$";
                string _header = "#include";
                string _buildin_func = @"getch()|getchar()|cls()";
                string _terminator = ";";



                String[] FileContent = File.ReadAllLines(filePath);
 
                foreach (String line in FileContent)
                {
                    string[] w = line.Split('\n');
                    foreach (string user in w)
                    {
                        if (Regex.IsMatch("for (int a = 0 ; a < 10 ; a++)", _for))
                        {
                            output += "For Loop Matched : " + user + "\n";
                        }

                        if (Regex.IsMatch(user, _header))
                        {
                            output += "Header file Matched : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _while))
                        {
                            output += "While Loop Matched : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _print))
                        {
                            output += "Print Statment matched : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _input))
                        {
                            output += " Input Statment matched : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _dowhile))
                        {
                            output += "Do-While Loop Matched  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _if))
                        {
                            output += "If Statement Mathced  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _elif))
                        {
                            output += "Else-If Statement Matched  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _else))
                        {
                            output += "Else Statement Matched  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _main) || Regex.IsMatch(user , _main1))
                        {
                            output += "Main Matched : " + user + "\n";
                            Console.WriteLine(output);
                        }

                        else if (Regex.IsMatch(user, _sw))
                        {
                            output += "Switch Statement Matched  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _case))
                        {
                            output += "Case Statement Matched  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _break))
                            output += "Break Statement Matched  : " + user + "\n";

                        else if (Regex.IsMatch(user, _continue))
                        {
                            output += "Continue Statement Matched  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _decl))
                        {
                            output += "Declaration Matched  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _dasign))
                        {
                            output += "Declare Assignment Matched : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _asig))
                        {
                            output += "Assign Matched : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _deflt))
                        {
                            output += "Default Statement Matched  : " + user + "\n";
                        }

                        else if (Regex.IsMatch(user, _buildin_func) && Regex.IsMatch(user, _terminator))
                        {
                            output += "Buildin function Matched  : " + user + "\n";
                        }

                        else
                        {
                            output += "Syntax Error : " + user + "\n";
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            Console.WriteLine(output);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
