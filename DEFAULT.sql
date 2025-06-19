USE movie_agregator
GO
-- значения по умолчанию (+)
--1. Создание и привязка значения по умолчанию для registration_date
CREATE DEFAULT DF_GetCurrentDate AS GETDATE()
Go
EXEC sp_bindefault 'DF_GetCurrentDate', 'USERS.registration_date';
GO

--2. Создание и привязка значения по умолчанию для is_premium
CREATE DEFAULT DF_DefaultFalse AS 0
GO
EXEC sp_bindefault 'DF_DefaultFalse', 'MOVIE_AVAILABILITY.rental_price';

/*
UPDATE MOVIE_AVAILABILITY
SET rental_price = 0 
WHERE rental_price IS NULL;
*/

GO

--3. Создание и привязка значения по умолчанию для description
CREATE DEFAULT DF_DefaultDescription AS 'описание отсутствует'
GO
EXEC sp_bindefault 'DF_DefaultDescription', 'NOMINATIONS.description'

/*
--проверка
INSERT INTO NOMINATIONS (name, category, participant_id)
VALUES
('Оскар', 'Лучший', 1)

select *
from nominations

delete
from Nominations
where category = 'лучший'
DBCC checkident (USERS, RESEED, 5)

INSERT INTO USERS (username, email, avatar_url)
VALUES
('Reveraf', 'mkonkov32@mail.ru', 'https://example.com/avatars/user3.jpg')


select *
from USERS

delete
from USERS
where username = 'Revera'
DBCC checkident (USERS, RESEED, 5)

SELECT user_id, username, is_premium 
                                    FROM USERS 
                                    WHERE username = 'Revera' AND user_password = 'imlegend'

Select *
	From users



	--для mainform



	*/