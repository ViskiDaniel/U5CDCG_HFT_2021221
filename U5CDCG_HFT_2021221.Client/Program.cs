using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            RestService rs = new RestService("http://localhost:64653/");

            rsMenu menu = new rsMenu(rs);

            menu.startUp();



        }
    }
}
