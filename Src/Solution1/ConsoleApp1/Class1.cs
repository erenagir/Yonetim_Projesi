using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Class1
    {

        public int Method(int x,int y)
        {
            return x + y;
        }

        public string Method2( ) 
        {
            var kullanıcıAdı=Console.ReadLine();
            var sifre =Console.ReadLine();
            

            if(kullanıcıAdı=="abc" && sifre == "123")
            {
                return("giriş Başarılı");
            }
            else
            {
                return "tekrar deneyniz";
            }

        }
    }
}
