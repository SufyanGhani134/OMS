use OnlineMovieSystem;
-----CREATE
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[CreateUser]'))
	DROP PROCEDURE CreateUser

GO
	CREATE PROCEDURE CreateUser
		@firstName VARCHAR(20),
		@lastName VARCHAR(20),
		@dob DATE,
		@email VARCHAR(50),
		@password VARCHAR (50),
		@PKID int = 0 output
AS

BEGIN
	INSERT INTO Users(firstName, lastName , dob, email, password, roleID)
		VALUES(@firstName, @lastName, @dob, @email, @password, 2)
	
	SET @PKID = @@IDENTITY

	Select @PKID as PKID
END


---Email Validation (Email already exist)
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[EmailValidation]'))
	DROP PROCEDURE EmailValidation

GO
	CREATE PROCEDURE EmailValidation
		@email VARCHAR(50),
		@isUser BIT output
AS
BEGIN 
	IF EXISTS(SELECT 1 from Users WHERE email = @email)
		BEGIN
			SET @isUser = 1
		END
	ELSE SET @isUser = 0
	SELECT @isUser AS isUser
END


---User Validation
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[UserValidation]'))
	DROP PROCEDURE UserValidation

GO
	CREATE PROCEDURE UserValidation
		@email VARCHAR(50),
		@password VARCHAR(100),
		@isValidUser INT output
AS
BEGIN 
	
	BEGIN
		IF EXISTS (SELECT 1 FROM Users WHERE email = @email AND password = @password)
			BEGIN
				SET @isValidUser = (SELECT userID FROM Users WHERE email = @email);
			END
		ELSE SET @isValidUser = 0
	END
	SELECT @isValidUser AS isValidUser
END


---Get User
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetUser]'))
	DROP PROCEDURE GetUser

GO
	CREATE PROCEDURE GetUser
		@userID INT
AS
BEGIN 
	SELECT * FROM Users WHERE userID = @userID	
END


---Add Movie
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[AddMovie]'))
	DROP PROCEDURE AddMovie

GO
	CREATE PROCEDURE AddMovie
		@userID INT,
		@title VARCHAR(50),
		@poster NVARCHAR(MAX),
		@releaseYear INT,
		@description VARCHAR(500),
		@duration VARCHAR(50),
		@price FLOAT,
		@ratings FLOAT,
		@PKID INT = 0 OUTPUT
AS
BEGIN 
	INSERT INTO Movies(userID, title, description, releaseYear, poster, duration, price, ratings) 
		VALUES (@userID, @title, @description, @releaseYear, @poster, @duration, @price, @ratings)

	SET @PKID = @@IDENTITY
	SELECT @PKID AS PKID
END

 execute AddMovie 9, 'A', 'asdf', 23, 'asdfgdgf', '2:3', 5, 4

----Add Genres in Genres Table
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[AddGenre]'))
	DROP PROCEDURE AddGenre
GO
	CREATE PROCEDURE AddGenre
	@genre VARCHAR(MAX)
AS
BEGIN 
	DECLARE @isGenre BIT = 0;
	IF EXISTS (SELECT 1 FROM Genres WHERE title = @genre)
		BEGIN 
			SET @isGenre = 1
		END

	IF @isGenre = 0 INSERT INTO Genres(title) VALUES (@genre);
END


---Add To MovieGenre Table
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[AddMovieGenre]'))
	DROP PROCEDURE AddMovieGenre
GO
	CREATE PROCEDURE AddMovieGenre
	@genre VARCHAR(MAX),
	@movieID INT
AS
BEGIN
	INSERT INTO MovieGenre (movieID) VALUES (@movieID);
	INSERT INTO MovieGenre (genreID)
    SELECT G.genreID FROM  Genres G WHERE G.title = @genre
END

execute AddMovieGenre 'fiction', 1

---Add To MovieResolution Table
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[AddMovieResolution]'))
	DROP PROCEDURE AddMovieResolution
GO
	CREATE PROCEDURE AddMovieResolution
	@movieID INT,
	@resolution VARCHAR(MAX)
AS
BEGIN
	INSERT INTO MovieResolution (movieID) VALUES (@movieID);
	INSERT INTO MovieResolution (resolutionID)
    SELECT R.resolutionID FROM  Resolution R WHERE R.title =@resolution
END


execute AddMovieResolution 1, '720p'
---Get All Movies
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetAllMovies]'))
	DROP PROCEDURE GetAllMovies

GO
	CREATE PROCEDURE GetAllMovies
AS
BEGIN 
	SELECT * FROM Movies
END

---Get Admin Movies
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetAdminMovies]'))
	DROP PROCEDURE GetAdminMovies

GO
	CREATE PROCEDURE GetAdminMovies
	@userID INT
AS
BEGIN 
	SELECT * FROM Movies where userID = @userID
END

---Get GenreID of a MovieID
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetGenreIDs]'))
	DROP PROCEDURE GetGenreIDs

GO
	CREATE PROCEDURE GetGenreIDs
	@movieID INT
AS
BEGIN 
	SELECT genreID FROM MovieGenre WHERE movieID = @movieID
END

---Get AllGenres of a movie
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetGenres]'))
	DROP PROCEDURE GetGenres

GO
	CREATE PROCEDURE GetGenres
	@genreID INT
AS
BEGIN 
	SELECT * FROM MovieGenre WHERE genreID = @genreID
END

--Get All Genres
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetAllGenres]'))
	DROP PROCEDURE GetAllGenres

GO
	CREATE PROCEDURE GetAllGenres
AS
BEGIN 
	SELECT title FROM Genres;
END

---GetResolutionIDs
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetResolutionIDs]'))
	DROP PROCEDURE GetResolutionIDs

GO
	CREATE PROCEDURE GetResolutionIDs
	@movieID INT
AS
BEGIN 
	SELECT resolutionID FROM MovieResolution WHERE movieID = @movieID
END

---GetResolution
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetResolutions]'))
	DROP PROCEDURE GetResolutions

GO
	CREATE PROCEDURE GetResolutions
	@resolutionID INT
AS
BEGIN 
	SELECT * FROM MovieResolution WHERE resolutionID = @resolutionID
END


---Remove Admin Movies
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[RemoveMovies]'))
	DROP PROCEDURE RemoveMovies

GO
	CREATE PROCEDURE RemoveMovies
	@userID INT,
	@movieID INT
AS
BEGIN 
	DECLARE @isValid BIT = 1;
	IF EXISTS (SELECT 1 FROM Movies WHERE userID = @userID AND movieID = @movieID)
    BEGIN
        DELETE FROM Movies WHERE userID = @userID AND movieID = @movieID
    END
    ELSE
    BEGIN
		SET @isValid = 0;
	END
	SELECT @isValid AS isValid;
END

---Update Admin Movies
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[UpdateMovie]'))
	DROP PROCEDURE UpdateMovie

GO
	CREATE PROCEDURE UpdateMovie
		@userID INT,
		@movieID INT,
		@title VARCHAR(50),
		@poster NVARCHAR(MAX),
		@releaseYear DATE,
		@description VARCHAR(500),
		@duration TIME,
		@price FLOAT,
		@ratings FLOAT
AS
BEGIN 
	DECLARE @isValid BIT = 1;
	IF EXISTS (SELECT 1 FROM Movies WHERE userID = @userID AND movieID = @movieID)
	BEGIN
		UPDATE Movies 
		SET title = @title, description = @description, releaseYear = @releaseYear, poster = @poster, duration = @duration, price= @price, ratings = @ratings
		WHERE userID = @userID AND movieID = @movieID
	END
	ELSE
	BEGIN
		SET @isValid = 0;
	END
	SELECT @isValid AS isValid;
END

---Update To MovieGenre Table
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[UpdateMovieGenre]'))
	DROP PROCEDURE UpdateMovieGenre
GO
	CREATE PROCEDURE UpdateMovieGenre
	@genre VARCHAR(MAX),
	@movieID INT
AS
BEGIN
	DECLARE @genreID INT;
	SELECT @genreID = genreID
	FROM Genre WHERE title = @genre

	IF @genreID IS NULL 
	BEGIN
		INSERT INTO Genre(title) VALUES (@genre)
	END

	UPDATE MovieGenre
    SET genreID = G.genreID
    FROM Genres G
    WHERE G.title = @genre
    AND MovieGenre.movieID = @movieID;
END

--Update MovieResolution Table
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[UpdateMovieResolution]'))
	DROP PROCEDURE UpdateMovieResolution
GO
	CREATE PROCEDURE UpdateMovieResolution
	@movieID INT,
	@resolution VARCHAR(MAX)
AS
BEGIN
	UPDATE MovieResolution
    SET resolutionID = R.resolutionID
    FROM Resolution R
    WHERE R.title = @resolution
    AND MovieResolution.movieID = @movieID;
END

---Add Cart
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[AddCart]'))
	DROP PROCEDURE AddCart

GO
	CREATE PROCEDURE AddCart
		@userID INT,
		@totalCost FLOAT,
		@generatedDate DATE,
		@PKID int output
AS
BEGIN 
	DECLARE @cartID INT;
	SELECT @cartID = cartID
    FROM Cart
    WHERE userID = @userID;
    IF @cartID IS NOT NULL
    BEGIN
        UPDATE Cart
        SET totalCost = @totalCost,
            GeneratedDate = @generatedDate
        WHERE cartID = @cartID;
    END
    ELSE
    BEGIN
        INSERT INTO Cart (userID, totalCost, GeneratedDate)
        VALUES (@userID, @totalCost, @generatedDate);
		SET @PKID = @@IDENTITY
		Select @PKID as PKID
    END	
END


---Add Cart Items
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[AddCartItems]'))
	DROP PROCEDURE AddCartItems

GO
	CREATE PROCEDURE AddCartItems
		@cartID INT,
		@title VARCHAR(50),
		@poster NVARCHAR(MAX),
		@unitCost FLOAT,
		@generatedDate DATETIME,
		@isCheck BIT
AS
BEGIN 
	INSERT INTO CartItems(cartID, title, poster, unitCost, generatedDate, isCheck) 
		VALUES (@cartID, @title, @poster, @unitCost, @generatedDate, @isCheck)
END

---Remove From Cart
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[RemoveCartItem]'))
	DROP PROCEDURE RemoveCartItem

GO
	CREATE PROCEDURE RemoveCartItem
		@cartItemID INT
AS
BEGIN 
	DELETE FROM CartItems WHERE cartItemID = @cartItemID;
END


---Get CartItems
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetCartItems]'))
	DROP PROCEDURE GetCartItems

GO
	CREATE PROCEDURE GetCartItems
	@cartID INT
AS
BEGIN 
	SELECT * FROM CartItems WHERE cartID = @cartID
END

--Update Cart Item
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[UpdateCartItem]'))
	DROP PROCEDURE UpdateCartItem
GO
	CREATE PROCEDURE UpdateCartItem
	@cartID INT
AS
BEGIN
	UPDATE CartItems
    SET isCheck = 1, generatedDate = GETDATE()
    FROM CartItems 
    WHERE cartID = @cartID
END


---Add Search History
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[AddSearchHistory]'))
	DROP PROCEDURE AddSearchHistory

GO
	CREATE PROCEDURE AddSearchHistory
		@userID INT,
		@genre VARCHAR(50)
AS
BEGIN 
	INSERT INTO SearchHistory (userID, genre)
		VALUES(@userID, @genre)
END

---Clear Search
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[ClearSearch]'))
	DROP PROCEDURE ClearSearch

GO
	CREATE PROCEDURE ClearSearch
		@userID INT
AS
BEGIN 
	DELETE FROM SearchHistory WHERE userID = @userID;
END

---GetSearch
IF EXISTS (SELECT 1 FROM sys.procedures where OBJECT_ID = OBJECT_ID(N'[dbo].[GetSearch]'))
	DROP PROCEDURE GetSearch

GO
	CREATE PROCEDURE GetSearch
		@search VARCHAR(50)
AS
BEGIN 
	SELECT * FROM Movies WHERE title LIKE '%' + @search + '%';
END


---Suggestions
IF EXISTS (SELECT 1 FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Suggestions]'))
    DROP PROCEDURE Suggestions;
GO
	CREATE PROCEDURE Suggestions
		@userID INT
AS
BEGIN
    CREATE TABLE #TempGenres (genre VARCHAR(50));
    INSERT INTO #TempGenres (genre)
    SELECT DISTINCT genre
    FROM SearchHistory
    WHERE userID = @userID;


    CREATE TABLE #TempGenreID (genreID INT);
    INSERT INTO #TempGenreID (genreID)
    SELECT G.genreID
    FROM Genres G
    INNER JOIN #TempGenres TG ON G.title = TG.genre;


    CREATE TABLE #TempMovieID (movieID INT);
    
    INSERT INTO #TempMovieID (movieID)
    SELECT DISTINCT MG.movieID
    FROM MovieGenre MG
    INNER JOIN #TempGenreID TGI ON MG.genreID = TGI.genreID;

    SELECT M.*
    FROM Movie M
    INNER JOIN #TempMovieID TM ON M.MovieID = TM.movieID;

    DROP TABLE #TempGenres;
    DROP TABLE #TempGenreID;
    DROP TABLE #TempMovieID;
END

---Add Admin
INSERT INTO Users(firstName, lastName, dob, email, password, roleID)
	VALUES('Sufyan', 'Ghani', '1999-08-17', 'sufyan@admin.com', '0987654321', 1);
