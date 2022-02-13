// See https://aka.ms/new-console-template for more information
namespace InterviuTehnic


{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Slutare!");
            HideAndSeek hideAndSeek = new HideAndSeek();
            //hideAndSeek.RunProgram("Test1.txt", "00110101", "Test2.txt",false);
            hideAndSeek.RunProgram("Test1.txt", "1", "Test3.txt", false);

            //hideAndSeek.Decriptare("fisier2.txt", "00110101","fisier5.txt");

            //hideAndSeek.RunProgram("fisier2.txt", "00110101", "fisier5.txt", true);

        }
    }

}