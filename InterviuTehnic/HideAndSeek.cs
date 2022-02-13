// See https://aka.ms/new-console-template for more information
using System.Text;



namespace InterviuTehnic

{
    class HideAndSeek
    {
        private static string XorIng2(string key, string input)
        {

            int dec1 = Convert.ToInt32(key, 16);
            Console.WriteLine(dec1);
            int dec2 = Convert.ToInt32(input, 16);
            Console.WriteLine(dec2);
            int result = dec1 ^ dec2;
            string hexResult = result.ToString("X");

          

            Console.WriteLine(hexResult);
            return hexResult;
        }


        private static string XorIng(string key, string input)
        {


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                sb.Append((char)(input[i] ^ key[(i % key.Length)]));
            string result = sb.ToString();

            Console.WriteLine(result);
            return result;
        }



        private string ReturnInputFile(string InputFileName)
        {
            try
            {
                if (InputFileName == String.Empty)
                {
                    Console.WriteLine("Input file name not specified");
                    return null;
                }
                if (!File.Exists(InputFileName))
                {
                    Console.WriteLine($"Invalid file name {InputFileName}");
                }
                else 
                {
                    return InputFileName; 
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }

            catch (IOException e)
            {
                Console.WriteLine($"Invalid file name '{e}'");//cauta metoda in clasa Exception pentru eroarea specificata si daca nu exista foloseste IOException + mesajul de eroare specificat in enunt.
            }

            return InputFileName;
        }

        private string KeyToEncrypt(string Key)
        {
            try
            {


                if (Key == String.Empty)
                {
                    Console.WriteLine("Key not specified!");
                    return null;
                }
                if (Key.Length < 2)
                {
                    Console.WriteLine("Invalid key format!");
                    return null;
                }
                else
                { return Key; }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Key not specified: '{e}'");
                if (Key == String.Empty)
                {
                    Console.WriteLine("Key not specified!");
                    return null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Key;
        }

        private string OutputFileName(string FileToSave)
        {
            try
            {
                Console.WriteLine(FileToSave);// cauta despre try implementare
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }

            catch (IOException e)
            {
                Console.WriteLine($"Invalid file name '{e}'");//cauta metoda in clasa Exception pentru eroarea specificata si daca nu exista foloseste IOException + mesajul de eroare specificat in enunt.
            }

            return FileToSave;
        }

        private bool DecriptFile(string FileToSave)
        {
            return true;
        }

        private string Crc(bool Decriptare)
        {
            if (Decriptare == true)
            {
                return "";
            }
            else
            {
                return "Nu este solicitate decriptare";
            }
        }



        public void CriptareFisier(string InputFileName, string Key, string outputFileName) 
        {
            //Console.WriteLine(ReturnInputFile(InputFileName));
            using (StreamReader reader = new StreamReader(ReturnInputFile(InputFileName)))
            {
                using (StreamWriter fileToWrite = new StreamWriter(OutputFileName(outputFileName)))
                {
                    // Console.WriteLine(XorIng(KeyToEncrypt(Key), ReturnInputFile(InputFileName)));
                    fileToWrite.Write(XorIng(KeyToEncrypt(Key),reader.ReadToEnd()));
                }
            }
        }



        public void DecriptareFisier(string InputFileName, string Key,  string outputFileName)
        {
            using (StreamReader reader = new StreamReader(ReturnInputFile(InputFileName)))
            {
                using (StreamWriter fileToWrite = new StreamWriter( OutputFileName(outputFileName)))
                {
                    //Console.WriteLine(XorIng(KeyToEncrypt(Key), ReturnInputFile(InputFileName)));
                    fileToWrite.Write(XorIng(KeyToEncrypt(Key), reader.ReadToEnd()));

                }
            }

        }




        public void RunProgram(string inputFile, string key, string outputFile,  bool d)
        {
            if (d == false)
            {
                CriptareFisier(inputFile, key, outputFile);
            }
            if (d == true)
            {
                DecriptareFisier(inputFile, key, outputFile);
            }

        }



    }
}

