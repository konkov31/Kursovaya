--представления (готово)
--1 фильмы с высокой оценкой
USE movie_agregator
GO

--триггеры (готовы)(не проверены)
--1
CREATE TRIGGER trg_LimitPrimaryGenres
ON MOVIE_GENRES
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.is_primary = 1
        AND (SELECT COUNT(*) FROM MOVIE_GENRES WHERE movie_id = i.movie_id AND is_primary = 1) >= 2
    )
    BEGIN
        RAISERROR('У фильма не может быть двух основных жанров', 16, 1);
        RETURN;
    END
    
    INSERT INTO MOVIE_GENRES (movie_id, genre_id, is_primary, genre_order)
    SELECT movie_id, genre_id, is_primary, genre_order
    FROM inserted;
END;
go

--2
CREATE TRIGGER trg_CheckUserReg
ON REVIEWS
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (
        SELECT 1 
        FROM inserted i
        JOIN USERS u ON i.user_id = u.user_id
        WHERE u.registration_date > DATEADD(MONTH, -1, GETDATE())
    )
    BEGIN
        RAISERROR('Only users registered more than 1 month ago can leave reviews', 16, 1);
        RETURN;
    END
    
    INSERT INTO REVIEWS (movie_id, user_id, rating, comment, is_favourite, likes_count)
    SELECT movie_id, user_id, rating, comment, is_favourite, likes_count
    FROM inserted;
END;
go

--3 (курсор)
CREATE TRIGGER trg_UpdateMovieAvgRating
ON REVIEWS
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @movie_id INT;
    DECLARE @avg_rating DECIMAL(3,1);
    
    -- Создаем курсор для всех затронутых фильмов
    DECLARE movie_cursor CURSOR FOR
    SELECT DISTINCT movie_id FROM (
        SELECT movie_id FROM inserted
        UNION
        SELECT movie_id FROM deleted
    ) AS affected_movies;
    
    OPEN movie_cursor;
    FETCH NEXT FROM movie_cursor INTO @movie_id;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Вычисляем новый средний рейтинг
        SELECT @avg_rating = AVG(CAST(rating AS DECIMAL(3,1)))
        FROM REVIEWS
        WHERE movie_id = @movie_id;
        
        -- Обновляем запись фильма
        UPDATE FILMS
        SET imdb_rating = @avg_rating
        WHERE movie_id = @movie_id;
        
        FETCH NEXT FROM movie_cursor INTO @movie_id;
    END
    
    CLOSE movie_cursor;
    DEALLOCATE movie_cursor;
END;
go

--4 (вложенные курсоры)
--Назначение: Этот триггер проверяет, соответствует ли фильм, на который оставлен отзыв, любимым жанрам пользователя, и регистрирует предупреждение, если соответствий не найдено.
CREATE TRIGGER trg_CheckUserGenrePreferences
ON REVIEWS
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @user_id INT;
    DECLARE @movie_id INT;
    DECLARE @genre_id INT;
    DECLARE @match_found BIT;
    
    -- Создаем курсор для всех новых отзывов
    DECLARE review_cursor CURSOR FOR
    SELECT user_id, movie_id FROM inserted;
    
    OPEN review_cursor;
    FETCH NEXT FROM review_cursor INTO @user_id, @movie_id;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @match_found = 0;
        
        -- Проверяем, есть ли совпадения с любимыми жанрами пользователя
        DECLARE genre_cursor CURSOR FOR
        SELECT g.genre_id
        FROM MOVIE_GENRES mg
        JOIN GENRES g ON mg.genre_id = g.genre_id
        WHERE mg.movie_id = @movie_id
        AND g.genre_id IN (
            SELECT genre_id FROM FAVORITE_GENRES WHERE user_id = @user_id
        );
        
        OPEN genre_cursor;
        FETCH NEXT FROM genre_cursor INTO @genre_id;
        
        IF @@FETCH_STATUS = 0
        BEGIN
            SET @match_found = 1;
            -- Можно добавить логику обработки совпадений
        END
        
        CLOSE genre_cursor;
        DEALLOCATE genre_cursor;
        
        -- Если нет совпадений с любимыми жанрами, регистрируем предупреждение
        IF @match_found = 0
        BEGIN
            PRINT CONCAT('Пользователь ', @user_id, ' оставил отзыв на фильм ', 
                        @movie_id, ' не из своих любимых жанров');
        END
        
        FETCH NEXT FROM review_cursor INTO @user_id, @movie_id;
    END
    
    CLOSE review_cursor;
    DEALLOCATE review_cursor;
END;
GO
--5
CREATE TRIGGER trg_UpdatePlatformStats
ON MOVIE_AVAILABILITY
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Определяем затронутые платформы
    DECLARE @affected_platforms TABLE (platform_id INT);
    
    INSERT INTO @affected_platforms
    SELECT platform_id FROM inserted
    UNION
    SELECT platform_id FROM deleted;
    
    -- Курсор для обработки платформ
    DECLARE @platform_id INT;
    DECLARE @movie_count INT;
    DECLARE @free_movies INT;
    
    DECLARE platform_cursor CURSOR FOR
    SELECT platform_id FROM @affected_platforms;
    
    OPEN platform_cursor;
    FETCH NEXT FROM platform_cursor INTO @platform_id;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Считаем количество фильмов на платформе
        SELECT @movie_count = COUNT(*) 
        FROM MOVIE_AVAILABILITY 
        WHERE platform_id = @platform_id;
        
        -- Считаем количество бесплатных фильмов
        SELECT @free_movies = COUNT(*) 
        FROM MOVIE_AVAILABILITY 
        WHERE platform_id = @platform_id AND is_free = 1;
        
        -- В реальной системе здесь было бы обновление статистики
        PRINT CONCAT('Платформа ID:', @platform_id, 
                    ' | Всего фильмов: ', @movie_count,
                    ' | Бесплатных: ', @free_movies);
        
        FETCH NEXT FROM platform_cursor INTO @platform_id;
    END
    
    CLOSE platform_cursor;
    DEALLOCATE platform_cursor;
END;

GO