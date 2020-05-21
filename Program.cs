using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// coefficient =ضریب     degree= درجه توان   term = جمله    fix== working truely;
namespace Polynomial
{
    class Polynomial
    {
        string Poly1;
        string Poly2;
        private int TermCount1; // the number of Terms in the first polynomial number
        private int TermCount2; // the number of Terms in the second polynomial number 

        private bool NegetiveFirstTerm1=true;
        private bool NegetiveFirstTerm2 = true;



        private int[] Degree1; // array of degrees in  first Polynomial number
        private int[] Degree2; // array of degrees in seconc Polynomial number

        private int[] Coefficients1; // array of Coefficients in  first Polynomial number
        private int[] Coefficients2; // array of Coefficients in seconc Polynomial number



        private void TermCountInitializer(string Pol1, string Pol2)
        {
            //<<Step1: Initialize Term1 count>>
            int Count1 = 0;
            for (int i = 0; i < Pol1.Length; i++)
            {
                if (Pol1[i] == '+' || Pol1[i] == '-')
                    Count1++;
            }
            if (Pol1[0] != '-')
            {
                NegetiveFirstTerm1 = false;
                Count1++;
            }
            TermCount1 = Count1;

            //<<Step2: Initialize Term2 count>>
            int Count2 = 0;
            for (int i = 0; i < Pol2.Length; i++)
            {
                if (Pol2[i] == '+' || Pol2[i] == '-')
                    Count2++;
            }
            if (Pol2[0] != '-')
            {
                NegetiveFirstTerm2 = false;
                Count2++;
            }
            TermCount2 = Count2;
        }
        ///============================================================
        private void DegreeInitializer(string Pol1, string Pol2)   //initializes Degree1 & Degree2
        {
            int Index1 = 0;// index of Degree1 array
            

            //<<Step1: Initialize Degree1>>
            string NumberHolder = "";
            for (int i = 0; i < Pol1.Length; i++)
            {
                if (Pol1[i] == '^')
                {
                    i++;
                    while(Pol1[i]>=48&& Pol1[i] <= 57)  // puts the degree in an string
                    {
                        NumberHolder += Pol1[i];
                        i++;
                        if (i >= Pol1.Length)
                            break;
                    }
                    Degree1[Index1] = int.Parse(NumberHolder);
                    Index1++;
                    NumberHolder = "";
                }
            }
            int Index2 = 0;// index of Degree2 array
            //<<Step2: Initialize Degree2>>
            NumberHolder = "";
            for (int i = 0; i < Pol2.Length; i++)
            {
                if (Pol2[i] == '^')
                {
                    i++;
                    while (Pol2[i] >= 48 && Pol2[i] <= 57)  // puts the degree in an string
                    {
                        NumberHolder += Pol2[i];
                        i++;
                        if (i >= Pol2.Length)
                            break;
                    }
                    Degree2[Index2] = int.Parse(NumberHolder);
                    Index2++;
                    NumberHolder = "";
                }
            }


        }
        ///============================================================
        private void CoefficientInitializer(string Pol1, string Pol2) 
        {
            bool negetiveCo1 = false;
            bool negetiveCo2 = false;
            string CoefficientHolder="";
            int Index1 = 0;// index of Coefficient array 1
            int Index2 = 0;// index of Coefficient array 2
            //<<Step1: Initialize coefficents 1>>
            for (int i=0; i < Pol1.Length; i++)
            {
                if(Pol1[i]=='-')
                {
                    negetiveCo1 = true;
                }
                else if(Pol1[i]=='+')
                {
                    negetiveCo1 = false;
                }
                if(Pol1[i]>=48&& Pol1[i] <= 57)    //Ascci code :   int 0 ==48 ascci code  
                {
                    if(negetiveCo1==true)
                    {
                        CoefficientHolder += "-";
                    }
                    while (Pol1[i] >= 48 && Pol1[i] <= 57)
                    {

                        CoefficientHolder += Pol1[i];
                        i++;
                        if (i >= Pol1.Length)
                            break;
                    }
                    Coefficients1[Index1] = int.Parse(CoefficientHolder);
                    Index1++;
                    CoefficientHolder = "";
                    // add to fix that bug
                    if (i == Pol1.Length)
                    {
                        break;
                    }
                    while (Pol1[i] != '+'|| Pol1[i] != '-')
                    {
                        if(Pol1[i]=='+'||Pol1[i]=='-')
                        {

                            if (Pol1[i] == '-')
                            {
                                negetiveCo1 = true;
                            }
                            else if (Pol1[i] == '+')
                            {
                                negetiveCo1 = false;
                            }
                            break;
                        }
                        if(i==Pol1.Length)
                        {
                            break;
                        }
                        else
                        {
                            i++;
                        }
                        if (i == Pol1.Length)
                        {
                            break;
                        }
                    }

                }
            }

            //<<Step2: Initialize coefficents 2>>

            CoefficientHolder = "";
            for (int i = 0; i < Pol2.Length; i++)
            {
                if (Pol2[i] == '-')
                {
                    negetiveCo2 = true;
                }
                else if (Pol2[i] == '+')
                {
                    negetiveCo2 = false;
                }
                if (Pol2[i] >= 48 && Pol2[i] <= 57)    //Ascci code :   int 0 ==48 ascci code  
                {

                    if (negetiveCo2 == true)
                    {
                        CoefficientHolder += '-';
                    }
                    while (Pol2[i] >= 48 && Pol2[i] <= 57)
                    {
                        
                        CoefficientHolder += Pol2[i];
                        i++;
                        if (i >= Pol2.Length)
                            break;
                    }
                    Coefficients2[Index2] = int.Parse(CoefficientHolder);
                    Index2++;
                    CoefficientHolder = "";
                    if (i == Pol2.Length)
                    {
                        break;
                    }
                    // add to fix that bug
                    while (Pol2[i] != '+' || Pol2[i] != '-')
                    {
                        if (Pol2[i] == '+' || Pol2[i] == '-')
                        {
                            if (Pol2[i] == '-')
                            {
                                negetiveCo2 = true;
                            }
                            else if (Pol2[i] == '+')
                            {
                                negetiveCo2 = false;
                            }
                            break;
                        }
                        if (i == Pol2.Length)
                        {
                            break;
                        }
                        else
                        {
                            i++;
                        }
                        if (i == Pol2.Length)
                        {
                            break;
                        }
                    }
                }
            }

        }
        ///============================================================

        public void Sum()
        {
            int maxTerms = TermCount1;
            if (TermCount2 > TermCount1)
            {
                maxTerms = TermCount2;
            }
            int sumTerms = TermCount1 + TermCount2;
            int[] SumCoefficients = new int[sumTerms];
            int[] SumDegree = new int[sumTerms];

            int index = 0;
            for(int i=0;i<Degree1.Length;i++)
            {
                for(int j = 0; j < Degree2.Length; j++)
                {
                    if (Degree1[i] == Degree2[j])
                    {
                        SumDegree[index] = Degree1[i];
                        SumCoefficients[index] = Coefficients1[i] + Coefficients2[j];
                        index++;
                    }

                }
            }
            // oonaee ke degree eshoon barabar nist ro benevis;
            //part1:
            for (int i = 0; i < Degree2.Length; i++)
            {
                bool Existance = false; // whether deggree1 exist in both polynomeriac 1 and 2?
                for (int j = 0; j < Degree1.Length; j++)
                {
                    if (Degree2[i] == Degree1[j])
                    {
                        Existance = true;
                    }

                }
                if (Existance == false)
                {
                    SumDegree[index] = Degree2[i];
                    SumCoefficients[index] = Coefficients2[i];
                    index++;
                }
            }

            /// part 2:
            for (int i = 0; i < Degree1.Length; i++)
            {
                bool Existance = false; // whether deggree1 exist in both polynomeriac 1 and 2?
                for (int j = 0; j < Degree2.Length; j++)
                {
                    if (Degree1[i] == Degree2[j])
                    {
                        Existance = true;
                    }

                }
                if (Existance == false)
                {
                    SumDegree[index] = Degree1[i];
                    SumCoefficients[index] = Coefficients1[i];
                    index++;
                }
            }

            

            //--------------------------------
            Console.Write("\n sum = ");
            for (int i = 0; i < sumTerms; i++)
            {
                if (SumCoefficients[i] > 0)
                {
                    Console.Write("+");
                }
                if(SumCoefficients[i] != 0)
                {
                    Console.Write(SumCoefficients[i]);
                    if (SumDegree[i] != 0)
                    {
                        Console.Write("x^{0}",SumDegree[i]);
                    }
                    Console.Write(" ");

                }
            }
           

        }
        ///============================================================

        public void Subtraction()
        {
            int maxTerms = TermCount1;
            if (TermCount2 > TermCount1)
            {
                maxTerms = TermCount2;
            }
            int sumTerms = TermCount2 + TermCount1;
            int[] SubtractionCoefficients = new int[sumTerms];
            int[] SumDegree = new int[sumTerms];

            int index = 0;
            for (int i = 0; i < Degree1.Length; i++)
            {
                for (int j = 0; j < Degree2.Length; j++)
                {
                    if (Degree1[i] == Degree2[j])
                    {
                        SumDegree[index] = Degree1[i];
                        SubtractionCoefficients[index] = Coefficients1[i] - Coefficients2[j];
                        index++;
                    }

                }
            }

            // oonaee ke degree eshoon barabar nist ro benevis;
            //part1:
            for (int i = 0; i < Degree2.Length; i++)
            {
                bool Existance = false; // whether deggree1 exist in both polynomeriac 1 and 2?
                for (int j = 0; j < Degree1.Length; j++)
                {
                    if (Degree2[i] == Degree1[j])
                    {
                        Existance = true;
                    }

                }
                if (Existance == false)
                {
                    SumDegree[index] = Degree2[i];
                    SubtractionCoefficients[index] = -1*Coefficients2[i];
                    index++;
                }
            }

            /// part 2:
            for (int i = 0; i < Degree1.Length; i++)
            {
                bool Existance = false; // whether deggree1 exist in both polynomeriac 1 and 2?
                for (int j = 0; j < Degree2.Length; j++)
                {
                    if (Degree1[i] == Degree2[j])
                    {
                        Existance = true;
                    }

                }
                if (Existance == false)
                {
                    SumDegree[index] = Degree1[i];
                    SubtractionCoefficients[index] = Coefficients1[i];
                    index++;
                }
            }
            Console.Write("\n subtraction = ");
            for (int i = 0; i < sumTerms; i++)
            {
                if (SubtractionCoefficients[i] > 0)
                {
                    Console.Write("+");
                }
                if(SubtractionCoefficients[i]!=0)
                {
                    Console.Write(SubtractionCoefficients[i]);
                    if (SumDegree[i] != 0)
                    {
                        Console.Write("x^{0}", SumDegree[i]);
                    }
                    Console.Write(" ");
                }
            }

        }
        ///============================================================
        public void SetX(int X)
        {
            double Ans1 = 0;
            double Ans2 = 0;

            // set to F(x)1;
            for(int i = 0;i < Degree1.Length; i++)
            {
                double power = Math.Pow(X, Degree1[i]);
                Ans1 += Coefficients1[i]*power;
            }
            Console.WriteLine("");
            Console.WriteLine("F(x)={0}  -> F({1}) = {2}",Poly1,X,Ans1);


            // set to F(x)2;
            for (int i = 0; i < Degree2.Length; i++)
            {
                double power = Math.Pow(X, Degree2[i]);
                Ans2 += Coefficients2[i] * power;
            }
            Console.WriteLine("F(x)={0}  -> F({1}) = {2}", Poly2, X, Ans2);
        }



        //*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^*^
        public Polynomial(string Pol1, string Pol2)
        {
            Poly1 = Pol1;
            Poly2 = Pol2;
            Console.ForegroundColor = ConsoleColor.Green;
            TermCountInitializer(Pol1, Pol2);      // fix: true

            Degree1 = new int[TermCount1]; 
            Degree2= new int[TermCount2];
            Coefficients1 = new int[TermCount1];
            Coefficients2 = new int[TermCount2];

            DegreeInitializer(Pol1, Pol2);        // fix: true
            CoefficientInitializer(Pol1,Pol2);     // fix: True
        }




    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> Command = new List<string>();
            List<int> XList = new List<int>();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter First polynomial number :");
            Console.ForegroundColor = ConsoleColor.White;
            string Pol1 = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter Second polynomial number :");
            Console.ForegroundColor = ConsoleColor.White;
            string Pol2 = Console.ReadLine();

            Polynomial polymer = new Polynomial(Pol1, Pol2);

            // take command from user ;   + for sum
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter Commands :  (+ for sum    - for subtraction   . to set X     ; to finish");
            Console.ForegroundColor = ConsoleColor.White;

            int com = 0;
            
            string commend;
            commend = Console.ReadLine();
            Command.Add(commend);
            while(Command[com]!=";")
            {
                if (Command[com] == ".")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter X >> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    int xvalue = int.Parse(Console.ReadLine());
                    XList.Add(xvalue);
                }
                commend = Console.ReadLine();
                Command.Add(commend);
                com++;
            }
            int XIndex=0;
            for(int i = 0; i < Command.Count;i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (Command[i] == "+")
                    polymer.Sum();
                else if (Command[i] == "-")
                    polymer.Subtraction();
                else if (Command[i] == ".")
                {
                    polymer.SetX(XList[XIndex]);
                    XIndex++;
                }
            }



            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n\n\n\n <<Finish>>   -------------> Developed By :");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" <Aryana.Bkh>");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n\t\t\t     My Github   : ");
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write("https://github.com/AryanaBakhshandeh ");
            Console.ReadKey();
        }
    }
}
