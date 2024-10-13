﻿namespace FilmoSearch.DataAcessLayer.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Stars { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
