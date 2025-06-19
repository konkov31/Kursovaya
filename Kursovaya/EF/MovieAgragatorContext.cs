namespace Kursovaya.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieAgragatorContext : DbContext
    {
        public MovieAgragatorContext() : base()
        {
        }

        public virtual DbSet<AWARDINGS> AWARDINGS { get; set; }
        public virtual DbSet<FAVORITE_GENRES> FAVORITE_GENRES { get; set; }
        public virtual DbSet<FILM_POSITIONS> FILM_POSITIONS { get; set; }
        public virtual DbSet<FILMS> FILMS { get; set; }
        public virtual DbSet<GENRES> GENRES { get; set; }
        public virtual DbSet<MOVIE_AVAILABILITY> MOVIE_AVAILABILITY { get; set; }
        public virtual DbSet<MOVIE_GENRES> MOVIE_GENRES { get; set; }
        public virtual DbSet<NOMINATIONS> NOMINATIONS { get; set; }
        public virtual DbSet<PERSONS> PERSONS { get; set; }
        public virtual DbSet<PLATFORMS> PLATFORMS { get; set; }
        public virtual DbSet<RATING_SOURCES> RATING_SOURCES { get; set; }
        public virtual DbSet<RATINGS> RATINGS { get; set; }
        public virtual DbSet<REVIEWS> REVIEWS { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<HighRatedMovies> HighRatedMovies { get; set; }
        public virtual DbSet<MovieDetailedInfo> MovieDetailedInfo { get; set; }
        public virtual DbSet<UserReviewsSummary> UserReviewsSummary { get; set; }

        public virtual DbSet<FILMS_GANRES> FILMS_GANRES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FILM_POSITIONS>()
                .Property(e => e.position_type)
                .IsUnicode(false);

            modelBuilder.Entity<FILM_POSITIONS>()
                .Property(e => e.character_name)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.original_title)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.age_rating)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.imdb_rating)
                .HasPrecision(3, 1);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.poster_url)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.trailer_url)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.AWARDINGS)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.FILM_POSITIONS)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.MOVIE_AVAILABILITY)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.MOVIE_GENRES)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.RATINGS)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.REVIEWS)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GENRES>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<GENRES>()
                .Property(e => e.genre_description)
                .IsUnicode(false);

            modelBuilder.Entity<GENRES>()
                .HasMany(e => e.MOVIE_GENRES)
                .WithRequired(e => e.GENRES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MOVIE_AVAILABILITY>()
                .Property(e => e.rental_price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<NOMINATIONS>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<NOMINATIONS>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<NOMINATIONS>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<NOMINATIONS>()
                .HasMany(e => e.AWARDINGS)
                .WithRequired(e => e.NOMINATIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONS>()
                .Property(e => e.full_name)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONS>()
                .Property(e => e.photo_url)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONS>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONS>()
                .Property(e => e.imdb_link)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONS>()
                .HasMany(e => e.FILM_POSITIONS)
                .WithRequired(e => e.PERSONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONS>()
                .HasMany(e => e.NOMINATIONS)
                .WithRequired(e => e.PERSONS)
                .HasForeignKey(e => e.participant_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PLATFORMS>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PLATFORMS>()
                .Property(e => e.subscription_cost)
                .HasPrecision(5, 2);

            modelBuilder.Entity<PLATFORMS>()
                .Property(e => e.logo_url)
                .IsUnicode(false);

            modelBuilder.Entity<PLATFORMS>()
                .HasMany(e => e.MOVIE_AVAILABILITY)
                .WithRequired(e => e.PLATFORMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RATING_SOURCES>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<RATING_SOURCES>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<RATING_SOURCES>()
                .Property(e => e.logo_url)
                .IsUnicode(false);

            modelBuilder.Entity<RATING_SOURCES>()
                .HasMany(e => e.RATINGS)
                .WithRequired(e => e.RATING_SOURCES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RATINGS>()
                .Property(e => e.rating_comment)
                .IsUnicode(false);

            modelBuilder.Entity<RATINGS>()
                .Property(e => e.original_url)
                .IsUnicode(false);

            modelBuilder.Entity<REVIEWS>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.REVIEWS)
                .WithRequired(e => e.USERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HighRatedMovies>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<HighRatedMovies>()
                .Property(e => e.imdb_rating)
                .HasPrecision(3, 1);

            modelBuilder.Entity<MovieDetailedInfo>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<MovieDetailedInfo>()
                .Property(e => e.original_title)
                .IsUnicode(false);

            modelBuilder.Entity<MovieDetailedInfo>()
                .Property(e => e.duration_formatted)
                .IsUnicode(false);

            modelBuilder.Entity<MovieDetailedInfo>()
                .Property(e => e.age_rating)
                .IsUnicode(false);

            modelBuilder.Entity<MovieDetailedInfo>()
                .Property(e => e.imdb_rating)
                .HasPrecision(3, 1);

            modelBuilder.Entity<MovieDetailedInfo>()
                .Property(e => e.genres)
                .IsUnicode(false);

            modelBuilder.Entity<MovieDetailedInfo>()
                .Property(e => e.free_on_platform)
                .IsUnicode(false);

            modelBuilder.Entity<UserReviewsSummary>()
                .Property(e => e.username)
                .IsUnicode(false);
        }
    }
}
