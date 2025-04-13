// See https://aka.ms/new-console-template for more information
using System;
using tpmodul8_103022300116;

namespace tpmodul8_103022300116
{
    public class Program
    {
        static void Main(string[] args)
        {

            ConfigHandler handler = new ConfigHandler();
            CovidConfig config = handler.config;

            Console.WriteLine($"Satuan suhu saat ini: {config.satuan_suhu}");

            Console.Write("Apakah Anda ingin mengganti satuan suhu? (y/n): ");
            string ubah = Console.ReadLine().ToLower();

            if (ubah == "y" || ubah == "yes")
            {
                config.UbahSatuan();
                Console.WriteLine($"Satuan suhu berhasil diubah menjadi: {config.satuan_suhu}");
            }

            Console.WriteLine();   
            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
            int hariDemam = Convert.ToInt32(Console.ReadLine());

            bool suhuValid = false;
            if (config.satuan_suhu.ToLower() == "celcius")
                suhuValid = suhu >= 36.5 && suhu <= 37.5;
            else if (config.satuan_suhu.ToLower() == "fahrenheit")
                suhuValid = suhu >= 97.7 && suhu <= 99.5;

            bool demamValid = hariDemam < config.batas_hari_demam;

            Console.WriteLine();
            if (suhuValid && demamValid)
                Console.WriteLine(config.pesan_diterima);
            else
                Console.WriteLine(config.pesan_ditolak);
        }
    }
}
