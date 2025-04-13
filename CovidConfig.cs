using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul8_103022300116
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public CovidConfig() { }

        public CovidConfig(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
        public void UbahSatuan()
        {
            if (satuan_suhu.ToLower() == "celcius")
            {
                satuan_suhu = "fahrenheit";

            }
            else
            {
                satuan_suhu = "celcius";
            }
        }
    }

    public class ConfigHandler
    {
        public CovidConfig config;
        private const string filePath = "covid_config.json";


        public ConfigHandler()
        {

            try
            {
                string jsonString = File.ReadAllText(filePath);
                config = JsonSerializer.Deserialize<CovidConfig>(jsonString);

                Console.WriteLine("Konfigurasi berhasil dibaca:");
                Console.WriteLine($"Satuan suhu: {config.satuan_suhu}");
                Console.WriteLine($"Batas hari demam: {config.batas_hari_demam}");
                Console.WriteLine($"Pesan ditolak: {config.pesan_ditolak}");
                Console.WriteLine($"Pesan diterima: {config.pesan_diterima}");
                Console.WriteLine(" ");
            }
            catch
            {
                SetDefault();
                WriteConfig();

                Console.WriteLine("File konfigurasi tidak ditemukan / error. Menggunakan default config:");
                Console.WriteLine($"Satuan suhu      : {config.satuan_suhu}");
                Console.WriteLine($"Batas hari demam : {config.batas_hari_demam}");
                Console.WriteLine($"Pesan ditolak    : {config.pesan_ditolak}");
                Console.WriteLine($"Pesan diterima   : {config.pesan_diterima}");
            }

        }

        private void SetDefault()
        {
            config = new CovidConfig(
                "celcius",
                14,
                "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            );
        }

        private void WriteConfig()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
    }

}

