using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ArabaListesi
{
    public class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Yakit { get; set; }
        public string Renk { get; set; }
        public string Vites { get; set; }
        public string KasaTipi { get; set; }
        public string Aciklama { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Araba> arabalar = new List<Araba>
            {
                new Araba
                {
                    Plaka = "33 ABC 123",
                    Marka = "bmw",
                    Model = "A4",
                    Yakit = "Benzin",
                    Renk = "siyah",
                    Vites = "Otomatik",
                    KasaTipi = "Sedan",
                    Aciklama = "Spor otomobil"
                },
                new Araba
                {
                    Plaka = "35 abc 239",
                    Marka = "Mercedes",
                    Model = "C180",
                    Yakit = "Dizel",
                    Renk = "beyaz",
                    Vites = "Manuel",
                    KasaTipi = "Sedan",
                    Aciklama = "Konforlu otomobil"
                }
            };

            
            var xmlSerializer = new XmlSerializer(typeof(List<Araba>));
            using (var writer = new System.IO.StreamWriter("arabalar.xml"))
            {
                xmlSerializer.Serialize(writer, arabalar);
            }

            
            var json = JsonConvert.SerializeObject(arabalar, Formatting.Indented);
            System.IO.File.WriteAllText("arabalar.json", json);

            
            var form = new System.Windows.Forms.Form
            {
                Width = 800,
                Height = 600
            };
            var propertyGrid = new System.Windows.Forms.PropertyGrid
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                SelectedObject = arabalar
            };
            form.Controls.Add(propertyGrid);
            System.Windows.Forms.Application.Run(form);
        }
    }
}
