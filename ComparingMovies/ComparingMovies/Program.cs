using System;
using System.Collections.Generic;

namespace ComparingMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MovieRatings> movies = new List<MovieRatings>
            {
                new() {Title = "Her", Rating = 8},
                new() {Title = "Fletch", Rating = 5},
                new() {Title = "Superbabies: Baby Geniuses 2", Rating = 9},
                new() {Title = "Howl's Moving Castle", Rating = 10}
            };
            movies.Sort(); //will use the CompareTo override we provided in the class

            foreach (MovieRatings movieRatings in movies)
            {
                Console.WriteLine(movieRatings.ToString());
            }
        }
    }
}