// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

namespace InterviuTehnic


{

    class Program
    {
        static void Main(string[] args)
        {
            bool decriptare = false;
            string cheieCriptare = "";
            string fisierIesire = "";




            if(args[0] == "/?")
            {
                Console.Write("Parametrii:\n" +
                    "InputFileName          Numele fisierului ce se cripteaza sau decripteaza. In cazul in care numele nu contine calea atunci fisierul este cautat in folder-ul curent.\n" +
                    "/k:        key \n" +
                    "o/:        Numele fisierul de output.\n" +
                    "/d        Daca este specificat inseamna ca operatia este de decriptare\n" +
                    "/?        Afiseaza comanda cu parametrii precum si descrierea acestora\n" +
                    "Exemplu:   HideAndSeek inputFileName /k:Key [/o:outputFileName] [/d] [/?]");
                return;
            } else
            {
                if(args[0].Contains("*") || args[0].Contains(" ") || args[0].Contains("<") || args[0].Contains(">") || args[0].Contains("?") || args[0].Contains("'\'") || args[0].Contains("|") || args[0].Contains("/") || args[0].Contains(":"))
                {
                    Console.WriteLine("Invalid file name  " + args[0]);
                    return;
                }
            }


            for(int i=1; i <args.Length;i++)
            {
                switch(args[i])
                {
                    case "/d": decriptare = true; break;
                    case string argFisierIesire when argFisierIesire.Contains("/o:"): fisierIesire = argFisierIesire[3..]; break;
                    case string argCheieCriptare when argCheieCriptare.Contains("/k:"): cheieCriptare = argCheieCriptare[3..]; break;
                    default: Console.Write("Invalid parameter " + args[i]); break;

                }
            }


            if (cheieCriptare.Length==0)
            {
                Console.WriteLine("Key not specified");
                return;
            }
            if (cheieCriptare.Length < 2 || vldRegex(cheieCriptare)==false)
            {
                Console.WriteLine("Invalid key format");
                return;
            }


          
            HideAndSeek hideAndSeek = new HideAndSeek();
            hideAndSeek.RunProgram(args[0],cheieCriptare,fisierIesire, decriptare);






            bool vldRegex(string strInput)
            {
                
                Regex myRegex = new Regex("^[a-fA-F0-9]+$");
                
                bool isValid = false;
                if (string.IsNullOrEmpty(strInput))
                {
                    isValid = false;
                   
                }
                else
                {
                    isValid = myRegex.IsMatch(strInput);
                    
                }
                
                return isValid;
            }

        }

   

    }

}