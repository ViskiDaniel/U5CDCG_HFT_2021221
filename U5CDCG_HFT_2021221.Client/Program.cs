using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Data;

namespace U5CDCG_HFT_2021221.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext db = new LibraryDbContext();

            Console.WriteLine(db.Books.Count());

            ;

        }
    }
}
