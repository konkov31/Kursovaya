USE movie_agregator

GO

CREATE VIEW HighRatedMovies AS
SELECT movie_id, title, release_year, duration, imdb_rating
FROM FILMS
WHERE imdb_rating > 8.5

GO

CREATE VIEW MovieDetailedInfo AS
SELECT 
    f.movie_id,
    f.title,
    f.original_title,
    f.release_year,
    CONCAT(f.duration / 60, '÷ ', f.duration % 60, 'ì') AS duration_formatted,
    f.age_rating,
    f.imdb_rating,
    (
        SELECT STRING_AGG(g.name, ', ')
        FROM MOVIE_GENRES mg
        JOIN GENRES g ON mg.genre_id = g.genre_id
        WHERE mg.movie_id = f.movie_id
    ) AS genres,
    (
        SELECT TOP 1 p.name
        FROM PLATFORMS p
        JOIN MOVIE_AVAILABILITY ma ON p.platform_id = ma.platform_id
        WHERE ma.movie_id = f.movie_id AND ma.is_free = 1
    ) AS free_on_platform,
    AVG(r.rating) AS avg_user_rating,
    COUNT(r.review_id) AS reviews_count
FROM 
    FILMS f
LEFT JOIN 
    REVIEWS r ON f.movie_id = r.movie_id
GROUP BY 
    f.movie_id, f.title, f.original_title, f.release_year, 
    f.duration, f.age_rating, f.imdb_rating;
go

CREATE VIEW UserReviewsSummary AS
SELECT
    u.user_id,
    u.username,
    COUNT(r.review_id) AS total_reviews,
    AVG(r.rating) AS avg_user_rating
FROM 
    USERS u
LEFT JOIN 
    REVIEWS r ON u.user_id = r.user_id
GROUP BY
    u.user_id, u.username;
go

CREATE VIEW FILMS_GANRES
AS
SELECT movie_id, [name]
FROM GENRES g INNER JOIN MOVIE_GENRES mg ON g.genre_id = mg.genre_id

GO