using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalloWeb.Models
{
    public class Games
    {
        public int Id { get; set; }
        public string Hersteller { get; set; }
        public string Vertieb { get; set; }
        public Genre Genre { get; set; }
        public string Titel { get; set; }
        public decimal Preis { get; set; }
        public DateTime Veröffentlicht { get; set; }
        public string Beschreibung { get; set; }

        public int Alter { get; set; }
    }

    public enum Genre
    {
        RPG,
        Shooter,
        Simulation
    }
}