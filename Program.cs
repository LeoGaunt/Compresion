using System;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Drawing;


//Need to decrompress hex codes, covert to bytes
//foreach while if lines need to be sorted to only do consecutive numbers

namespace converter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting an image and turning it into its' hex codes
            var bytes = File.ReadAllBytes("image2.JPG");
            //The next 2 lines are the start of the loss test
            var ByteTest = bytes;
            File.WriteAllBytes(@"C:\Users\leoga\Documents\Projects_Atom\Pad_Wood\WriteBytes.txt", ByteTest);
            var hexPairs = String.Join("", bytes.Select(b => b.ToString("X2")));            
            var chunkSize = 6;          
            var hexCode = Enumerable.Range(0, hexPairs.Length / chunkSize).Select(i => hexPairs.Substring(i * chunkSize, chunkSize));
            Console.WriteLine(String.Join(",", hexCode));
            
            System.IO.File.WriteAllText(@"C:\Users\leoga\Documents\Projects_Atom\Pad_Wood\WriteText2.txt", String.Join(",", hexCode));


            //bytes input
            string VarInput = System.IO.File.ReadAllText(@"C:\Users\leoga\Documents\Projects_Atom\Pad_Wood\WriteText2.txt");
            var charsToRemove = new string[] { ","};
            foreach (var c in charsToRemove)
            {
                VarInput = VarInput.Replace(c, string.Empty);
            }

            char[] characters = VarInput.ToCharArray();

            String result = String.Join("",characters);
            System.IO.File.WriteAllText(@"C:\Users\leoga\Documents\Projects_Atom\Pad_Wood\WriteText2CharacterArray.txt", result);

            // foreach(char x in characters) {
            //     foreach(char y in characters){
            //         while(y>x){
            //             if(characters[x] == characters[y]){
            //                 //Console.WriteLine("Yes");
            //             }
            //         }
            //     }
            // }
        
            //next 5 lines are continuation of the loss test
            static byte[] StringToByteArray(string VarInput) {
            return Enumerable.Range(0, VarInput.Length)
                            .Where(x => x % 2 == 0)
                            .Select(x => Convert.ToByte(VarInput.Substring(x, 2), 16))
                            .ToArray();
            } 

            File.WriteAllBytes(@"C:\Users\leoga\Documents\Projects_Atom\Pad_Wood\WriteBytes2.txt", bytes);


            //Creating an image

            Image byteArrayToImage(byte[] VarInput)
            {
                MemoryStream ms = new MemoryStream(VarInput);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
                FileStream file = new FileStream(@"C:\Users\leoga\Documents\Projects_Atom\Pad_Wood\Image2Copy.JPG", FileMode.Create, FileAccess.Write);
                ms.WriteTo(file);   
            }

            
            
            
        }
    }
}