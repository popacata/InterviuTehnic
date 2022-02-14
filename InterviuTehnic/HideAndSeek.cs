// See https://aka.ms/new-console-template for more information
using System.Text;



namespace InterviuTehnic

{
    class HideAndSeek
    {

        private static string XorIng(string key, string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                sb.Append((char)(input[i] ^ key[(i % key.Length)]));
            string result = sb.ToString();

            Console.WriteLine(result);
            return result;
        }



        public void CriptareFisier(string InputFileName, string Key, string outputFileName)
        {

            try
            {
                using (StreamReader reader = new StreamReader(InputFileName))
                {
                    try
                    {
                        using (StreamWriter fileToWrite = new StreamWriter(outputFileName))
                        {
                            try
                            {
                                fileToWrite.Write(XorIng(Key, reader.ReadToEnd()));
                            }
                            catch
                            {
                                Console.WriteLine("Ceva nu a functionat");
                            }

                            Console.WriteLine("Operation completed successfully!");
                        }
                    }
                    catch(Exception )
                    {
                        Console.WriteLine("Operation failed");
                    }

                }

            }

            catch(FileNotFoundException)
            {
                Console.WriteLine($"File not found {InputFileName}");
            }
            catch(Exception)
            {
                Console.WriteLine("Operation failed");
            }
        }



        public void DecriptareFisier(string InputFileName, string Key,  string outputFileName)
        {
            using (StreamReader reader = new StreamReader(InputFileName))
            {
                using (StreamWriter fileToWrite = new StreamWriter(outputFileName))
                {
                    try
                    {
                        fileToWrite.Write(XorIng(Key, reader.ReadToEnd()));
                    }
                    catch
                    {
                        Console.WriteLine("Ceva nu a functionat");
                    }

                    Console.WriteLine("Operation completed successfully!");

                }
            }

        }




        public void RunProgram(string inputFile, string key, string outputFile,  bool d)
        {
            if (d == false)
            {
                CriptareFisier(inputFile, key, outputFile + ".enc");
            }
            if (d == true)
            {
                DecriptareFisier(inputFile, key, outputFile + ".dec");
            }

        }

    }
}

