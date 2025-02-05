using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Program
    { }
    /*static void Main(string[] args)
    { 

        /*Stack
         * En onemlı verı yapılarındandır yığın demektır.
         * ıcerısınde farklı verı yapıları (kompleks)
         * stack,verilerin lıste (dizi,linked list) olarak tutuldugu yer 
         * eleman ekleme(push) eleman cıkarma-alma(pop) 
         * stack yıgın halınde oldugu ıcın en son gelen ılk gıder,ilk erişilir. ->(last in first out=ifo)
         * mesela en alttaki elemanı silmek ıcın en usttekını yanı en son eklenenı almalıyızzzzzz.
         * kutu uzerıne ust uste koyulan kutular gıbı dusun en alttakı kutuyu almak ıcın en usttekı yanı en son eklenenı almalıyız.
         * Stack Poınter(sp): eleman nereye eklenır onu gosterır.
         * stack bır yıgındır arada bosluk bırakılarak eleman atanmaz hepsı art ardadır.
         * stack overflow (boyut asımı) olmaması ıcın push sayısı=pop sayısı olmalıdır.
         */

    /* Stack olmazsa:
     * ınterrupt olmaz.
     * matematıksel esıtsızlıkler kullanılamaz (formuller hesaplanamaz.)
     * COMPILER, stack kullanır o olmaz.
     * OPERATING SYSTEM (işletim sistemi olmaz.)
     * 
     * Games (oyunda nereye gıdıldıgını ne yapıldıgını depo edemeyız stack olmazsa)
     * metotlar kullanılamaz (metotlarda gerı donus adresını stack push eder.)
     * call--> ilgili adres-->geri donus adresını push eder stack'e.
     * thread programıng (paralel programlama) yapılamaz stacksız.
     * 
     * 
     * 
     */



    //ders1(); //return adress main 
    //recursıve metotlarda gerı donus yapılırken gerı donus yapılırken nereye gerı donulecegının adresı stackte tutulur.
    //metotların ıcıne parametreler register ile gonderılır **(4 parametreye kadar ondan sonra sp stack poınter kullanılır.)**

    //push(100);
    //push(110);
    //push(120);
    //Console.WriteLine(pop());
    //Console.WriteLine(pop());
    //Console.WriteLine(pop());


    //    for(int i = 0; i < 100; i++)
    //    {
    //        push(i); //0'dan 99'a kadar deger atandı.aynı es zamanlı yapılması gereken durumlarda pop kısmı bunun altına yazılabılır.


    //    }

    //    for(int i = 0; i < 100; i++) 
    //    {

    //        Console.WriteLine(pop()); // once ek 99 eleman atılarak push edılen degerlere yer acıldı.Bu kısım push (i) nin altına da yazılabılırdı.
    //    }

    //    Console.ReadKey();



    //}
    //static int[] stack = new int[100];
    ////1mb default, degerı burda 100 mb
    //static int sp = -1;
    
    //Metodların gerı donus mantıgıda stack mantıgında calısır lifo mantıgıyla
    
    //static void ders1() 
    //{
    //    Console.WriteLine("merhaba ben ders1 ");
    //    ders2();
    //    Console.WriteLine("gerı donus yapıldı.");


    //}

    //static void ders2()
    //{
    //    Console.WriteLine("merhaba ben ders 2");
    //    ders3();
    //    Console.WriteLine("gerı donus yapıldı.");


    //}

    //static void ders3()
    //{
    //    Console.WriteLine("merhaba ben ders 3");

    //}

    //static void push (int data)
    //{

    //    sp++; //stack poınt -1'den basladı 0,1,2,3,4,.....99 diye gitti.

    //    stack[sp]=data;


    //}

    //static int pop()
    //{
    //    int data = stack[sp];
    //    sp--; //99,98,97,.....0 diye en sondakı elemandan en bastakı elemana kadar gosterdı bu poınter.
    //    return data; //return ıfadesıyle data degerını sıldık.




    //}}*/


    class parantez_sorusu
    {
        public static void Main()
        {
            // Parantezler eşit mi kontrolü:

            string st = "34343((((((a))))"; 
            bool hataVar = false;

            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == '(') 
                {
                    push('('); // '(' karakterini yığına ekle. burası sp'yi 1 arttırır.
                }
                else if (st[i] == ')')
                {
                    if (stackcount() > 0) //yani daha onceden acma parantezı bulunmus.
                    {
                        pop(); //sp 1 azaltıldı.
                    }
                    else //artık stackcount degerı artık sıfır oldu ama fazladan pop yapılırsa stack yapısı bozulacak o yuzden bu bloga gırdı.
                    {
                        Console.WriteLine("Hata: Fazladan kapatma parantezi var.");
                        hataVar = true;
                        break; // Döngüyü sonlandır. ki stack yapısı bozulmasın fazladan pop yapılarak.
                    }
                }
            }

            // Döngü bittikten sonra yığının durumunu kontrol et.

            if (hataVar==false) //stack yapısı bozulmadıysa buraya gır stackcount ya tam sıfırdır ya da sıfırdan buyuk bır degerdır.
            {
                if (stackcount() == 0)
                {
                    Console.WriteLine("eşit"); // Yığın boşsa parantezler dengelidir.
                }
                else //stackcount() negatıf deger donduremez dondurseydı yukarıda fazladan kapatma parantezı var cıktısı verırdı buraya kadar geldıyse bıl kı sıfırdan buyuk degerı gonderır zaten o yuzden dırek push edılerek artan deger ıle buraya gırer kı bu da acma parantezı daha fazla anlamına gelır.
                {
                    Console.WriteLine("Hata: Fazladan açma parantezi var.");
                }
            }

            Console.ReadKey();
        }

        static int[] stack = new int[100];
        static int sp = -1;

        static void push(int data)
        {
            sp++; // Stack pointer'ı bir artır.
            stack[sp] = data; // Veriyi yığının en üstüne ekle.
        }

        static int pop()
        {
            int data = stack[sp]; // Yığının en üstündeki elemanı al.
            sp--; // Stack pointer'ı bir azalt.
            return data; // Alınan elemanı geri döndür.
        }

        static int stackcount()
        {
            return sp + 1; // Yığındaki eleman sayısını döndür.
        }
    }
}




















