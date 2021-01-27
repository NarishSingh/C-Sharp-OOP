using System;

namespace ComparingMovies
{
    public class MovieRatings: IComparable<MovieRatings>
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        
        public int CompareTo(MovieRatings? other)
        {
            if (other == null)
            {
                return 1; // > 0 b/c null will be added ahead, at end of list
            }

            return Rating.CompareTo(other.Rating);
        }

        public override string ToString()
        {
            return $"{nameof(Title)}: {Title}, {nameof(Rating)}: {Rating}";
        }
    }
}