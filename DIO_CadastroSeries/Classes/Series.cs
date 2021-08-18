using System;

namespace DIO_CadastroSeries
{
    public class Series : EntityBase
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private int Year { get; set; }
        private bool Active { get; set; }

        public Series(int id, Genre genre, string title, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Year = year;
            this.Active = true;
        }

        public override string ToString()
        {
            string seriesDetails = "Genre: " + this.Genre;
            seriesDetails += " | Title: " + this.Title;
            seriesDetails += " | Year: " + this.Year;
            seriesDetails += " | Available: " + this.Active;

            return seriesDetails;
        }

        public int getId()
        {
            return this.Id;
        }

        public string getTitle()
        {
            return this.Title;
        }

        public void setInactive()
        {
            this.Active = false;
        }
    }
}