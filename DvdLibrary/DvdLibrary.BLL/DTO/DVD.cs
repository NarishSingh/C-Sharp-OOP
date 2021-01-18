using System;

namespace DvdLibrary.BLL.DTO
{
    public class DVD
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Studio { get; set; }
        public string MpaaRating { get; set; }
        public string UserRating { get; set; }

        public DVD()
        {
        }

        public DVD(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public DVD(string title, DateTime releaseDate, string director, string studio, string mpaaRating,
            string userRating)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Director = director;
            Studio = studio;
            MpaaRating = mpaaRating;
            UserRating = userRating;
        }

        public DVD(int id, string title, DateTime releaseDate, string director, string studio, string mpaaRating,
            string userRating)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Director = director;
            Studio = studio;
            MpaaRating = mpaaRating;
            UserRating = userRating;
        }

        /*Testing*/
        protected bool Equals(DVD other)
        {
            return Id == other.Id && Title == other.Title && ReleaseDate.Equals(other.ReleaseDate) &&
                   Director == other.Director && Studio == other.Studio && MpaaRating == other.MpaaRating &&
                   UserRating == other.UserRating;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DVD) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, ReleaseDate, Director, Studio, MpaaRating, UserRating);
        }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(ReleaseDate)}: {ReleaseDate}, " +
                $"{nameof(Director)}: {Director}, {nameof(Studio)}: {Studio}, {nameof(MpaaRating)}: {MpaaRating}, " +
                $"{nameof(UserRating)}: {UserRating}";
        }
    }
}