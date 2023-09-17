IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE OBJECT_ID('OnlineMovieSystem') IS NULL)
BEGIN
    CREATE DATABASE OnlineMovieSystem;
END;


use OnlineMovieSystem;

---Role Table
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[Role]'))
		DROP TABLE Role

	CREATE TABLE Role
	(
		roleID INT IDENTITY(1,1) PRIMARY KEY,
		title VARCHAR(20) NOT NULL,
	)

	INSERT INTO Role (title)
	VALUES
		('Admin'),
    ('Customer');

END

---Users Table
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[Users]'))
		DROP TABLE Users

	CREATE TABLE Users
	(
		userID INT IDENTITY(1,1) PRIMARY KEY,
		firstName VARCHAR(20) NOT NULL,
		lastName VARCHAR(20) NOT NULL,
		dob DATE,
		email VARCHAR(50) NOT NULL,
		password VARCHAR(100) NOT NULL,
		roleID INT NOT NULL,
		FOREIGN KEY (roleID) REFERENCES Role(roleID)
	)
END

---Genres Table
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[Genres]'))
		DROP TABLE Genres

	CREATE TABLE Genres
	(
		genreID INT IDENTITY(1,1) PRIMARY KEY,
		title VARCHAR(20) NOT NULL,
	)
END


--- Resolution Table
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[Resolution]'))
		DROP TABLE Resolution

	CREATE TABLE Resolution
	(
		resolutionID INT IDENTITY(1,1) PRIMARY KEY,
		title VARCHAR(20) NOT NULL,
	)

	INSERT INTO Resolution(title)
	VALUES
		('720p'),
		('1080p'),
		('2k or 1440p'),
		('4k or 2160p');

END


--- Movies Table
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[Movies]'))
		DROP TABLE Movies

	CREATE TABLE Movies
	(
		movieID INT IDENTITY(1,1) PRIMARY KEY,
		title VARCHAR(20) NOT NULL,
		description VARCHAR(500),
		releaseYear DATE NOT NULL,
		poster NVARCHAR(MAX),
		duration TIME NOT NULL,
		price FLOAT NOT NULL,
		ratings FLOAT,
		userID INT,
		FOREIGN KEY (userID) REFERENCES Users(userID)
	)
END

---MovieGenre
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[MovieGenre]'))
		DROP TABLE MovieGenre

	CREATE TABLE MovieGenre
	(
		movieGenreID INT IDENTITY(1,1) PRIMARY KEY,
		movieID INT,
		FOREIGN KEY (movieID) REFERENCES Movies(movieID),
		genreID INT,
		FOREIGN KEY (genreID) REFERENCES Genres(genreID)
	)
END

---MovieResolution
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[MovieResolution]'))
		DROP TABLE MovieResolution

	CREATE TABLE MovieResolution
	(
		movieResolutionID INT IDENTITY(1,1) PRIMARY KEY,
		movieID INT,
		FOREIGN KEY (movieID) REFERENCES Movies(movieID),
		resolutionID INT,
		FOREIGN KEY (resolutionID) REFERENCES Resolution(resolutionID)
	)
END


--- Cart Table
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[Cart]'))
		DROP TABLE Cart

	CREATE TABLE Cart
	(
		cartID INT IDENTITY(1,1) PRIMARY KEY,
		totalCost FLOAT,
		userID INT,
		FOREIGN KEY (userID) REFERENCES Users(userID)
	)
END


---CartItems Table
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[CartItems]'))
		DROP TABLE CartItems

	CREATE TABLE CartItems
	(
		cartItemID INT IDENTITY(1,1) PRIMARY KEY,
		title VARCHAR(50) NOT NULL,
		poster NVARCHAR(MAX),
		unitCost FLOAT NOT NULL,
		generatedDate DATETIME NOT NULL,
		isCheck BIT,
		cartID INT,
		FOREIGN KEY (cartID) REFERENCES Cart(cartID)
	)
END


---SearchHistory Table
BEGIN
	IF EXISTS (SELECT 1 FROM sys.tables where OBJECT_ID = OBJECT_ID(N'[dbo].[SearchHistory]'))
		DROP TABLE SearchHistory

	CREATE TABLE SearchHistory
	(
		searchHistoryID INT IDENTITY(1,1) PRIMARY KEY,
		genre VARCHAR(50) NOT NULL,
		userID INT,
		FOREIGN KEY (userID) REFERENCES Users(userID),
	)
END