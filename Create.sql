-- Основные таблицы
USE master
CREATE DATABASE [movie_agregator]
ON
(NAME='Movie_Data',
FILENAME='C:\Databases\Movie_data.mdf',
SIZE=2,
MAXSIZE=16,
FILEGROWTH=2)
LOG ON
(NAME='Movie_Log',
FILENAME='C:\Databases\Movie_Log.ldf',
SIZE=5,
MAXSIZE=20,
FILEGROWTH=2)
GO

USE movie_agregator;
-- Основные таблицы
CREATE TABLE FILMS (
    movie_id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    original_title VARCHAR(255),
    release_year INT NOT NULL,
    duration INT NOT NULL,
    description TEXT,
    age_rating VARCHAR(20),
    imdb_rating DECIMAL(3,1),
    poster_url VARCHAR(255),
    trailer_url VARCHAR(255)
);
GO

-- Таблица для личностей (актеров и режиссеров)
CREATE TABLE PERSONS (
    person_id INT IDENTITY(1,1) PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    birth_date DATE,
    photo_url VARCHAR(255),
    country VARCHAR(50),
    height INT,
    imdb_link VARCHAR(255),
);
GO

CREATE TABLE PLATFORMS (
    platform_id INT IDENTITY PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    subscription_cost DECIMAL(5,2) NOT NULL,
    logo_url VARCHAR(255),
    added_date DATE
);
GO

CREATE TABLE GENRES (
    genre_id INT IDENTITY PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    genre_description TEXT
);
GO

CREATE TABLE USERS (
    user_id INT IDENTITY PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
	user_password NVARCHAR(200) NOT NULL UNIQUE,
    registration_date DATE NOT NULL,
    is_premium BIT DEFAULT 0
);
GO


CREATE TABLE RATING_SOURCES (
    source_id INT IDENTITY PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    website VARCHAR(255),
    logo_url VARCHAR(255),
    trust_score FLOAT
);
GO

-- Таблица номинаций с прямой связью с участниками (личностями)
CREATE TABLE NOMINATIONS (
    nomination_id INT IDENTITY PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    category VARCHAR(100) NOT NULL, -- "Лучший актер", "Лучший режиссер" и т.д.
    description TEXT,
    participant_id INT NOT NULL, -- обязательная ссылка на участника-личность
    FOREIGN KEY (participant_id) REFERENCES PERSONS(person_id),
);
GO

-- Таблица церемоний награждения
CREATE TABLE AWARDINGS (
    awarding_id INT IDENTITY PRIMARY KEY,
    movie_id int not null,
	nomination_id int not null,
	FOREIGN KEY (movie_id) REFERENCES FILMS(movie_id),
	FOREIGN KEY (nomination_id) REFERENCES NOMINATIONS (nomination_id)
);
GO

-- Ассоциативные таблицы
CREATE TABLE MOVIE_AVAILABILITY (
    availability_id INT IDENTITY PRIMARY KEY,
    movie_id INT NOT NULL,
    platform_id INT NOT NULL,
    is_free BIT DEFAULT 0,
    rental_price DECIMAL(5,2),
    available_from DATE,
    FOREIGN KEY (movie_id) REFERENCES FILMS(movie_id),
    FOREIGN KEY (platform_id) REFERENCES PLATFORMS(platform_id)
);
GO

CREATE TABLE MOVIE_GENRES (
    movie_genre_id INT IDENTITY PRIMARY KEY,
    movie_id INT NOT NULL,
    genre_id INT NOT NULL,
    is_primary BIT DEFAULT 0,
    genre_order INT,
    FOREIGN KEY (movie_id) REFERENCES FILMS(movie_id),
    FOREIGN KEY (genre_id) REFERENCES GENRES(genre_id)
);
GO

CREATE TABLE REVIEWS (
    review_id INT IDENTITY PRIMARY KEY,
    movie_id INT NOT NULL,
    user_id INT NOT NULL,
    rating INT,
    comment TEXT,
    is_favourite BIT DEFAULT 0,
    likes_count INT DEFAULT 0,
    FOREIGN KEY (movie_id) REFERENCES FILMS(movie_id),
    FOREIGN KEY (user_id) REFERENCES USERS(user_id)
);
GO

-- Таблица для должностей в фильме
CREATE TABLE FILM_POSITIONS (
    position_id INT IDENTITY PRIMARY KEY,
    movie_id INT NOT NULL,
    person_id INT NOT NULL,
    position_type VARCHAR(50) NOT NULL, -- 'Actor', 'Director' и т.д.
    character_name VARCHAR(100), -- для актерских ролей
    is_lead_role BIT DEFAULT 0,
    FOREIGN KEY (movie_id) REFERENCES FILMS(movie_id),
    FOREIGN KEY (person_id) REFERENCES PERSONS(person_id)
);
GO

CREATE TABLE RATINGS (
    rating_id INT IDENTITY PRIMARY KEY,
    movie_id INT NOT NULL,
    source_id INT NOT NULL,
    value INT,
    rating_date DATE,
    votes_count INT,
    rating_comment TEXT,
    original_url VARCHAR(255),
    FOREIGN KEY (movie_id) REFERENCES FILMS(movie_id),
    FOREIGN KEY (source_id) REFERENCES RATING_SOURCES(source_id)
);
GO

CREATE TABLE FAVORITE_GENRES (
    user_genre_id INT IDENTITY PRIMARY KEY,
    user_id INT NOT NULL,
    genre_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES USERS(user_id) ON DELETE CASCADE,
    FOREIGN KEY (genre_id) REFERENCES GENRES(genre_id) ON DELETE CASCADE,
    CONSTRAINT UQ_User_Genre UNIQUE (user_id, genre_id)
);
GO