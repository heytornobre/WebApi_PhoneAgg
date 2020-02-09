namespace WebApi_PhoneAgg.FileReader
{
    class ReadFromFile
    {
        public static string[] Prefixes { get; set; }

        public static void Read()
        {
            string text = System.IO.File.ReadAllText(@"FileReader/prefixes.txt");

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            Prefixes = System.IO.File.ReadAllLines(@"FileReader/prefixes.txt");
        }
    }
}
