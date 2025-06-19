USE movie_agregator;

GO

CREATE PROC RegisterUser(@Username NVARCHAR(50), @Email NVARCHAR(100), @Password NVARCHAR(200))
AS
BEGIN

	IF EXISTS (SELECT * FROM USERS WHERE username = @Username) throw 50000, 'User already exist', 1

    INSERT INTO USERS (username, email, user_password)
    VALUES (@Username, @Email, @Password);

END

Go

CREATE PROCEDURE AddFavoriteGenre (@user_id INT, @genre_id INT)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Проверяем существование пользователя
        IF NOT EXISTS (SELECT 1 FROM USERS WHERE user_id = @user_id)
        BEGIN
            RAISERROR('Пользователь с указанным ID не существует', 16, 1);
            RETURN;
        END
        
        -- Проверяем существование жанра
        IF NOT EXISTS (SELECT 1 FROM GENRES WHERE genre_id = @genre_id)
        BEGIN
            RAISERROR('Жанр с указанным ID не существует', 16, 1);
            RETURN;
        END
        
        -- Проверяем, не добавлен ли уже этот жанр пользователю
        IF EXISTS (SELECT 1 FROM FAVORITE_GENRES WHERE user_id = @user_id AND genre_id = @genre_id)
        BEGIN
            RAISERROR('Этот жанр уже добавлен в избранное для данного пользователя', 16, 1);
            RETURN;
        END
        
        -- Добавляем запись
        INSERT INTO FAVORITE_GENRES (user_id, genre_id)
        VALUES (@user_id, @genre_id);
        
        PRINT 'Жанр успешно добавлен в избранное пользователя';
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO