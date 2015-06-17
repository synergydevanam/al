
CREATE TABLE [Country]
(
    [CountryID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [CountryName] [NVARCHAR](256) NULL
);
GO

CREATE PROCEDURE [AL_GetAllCountries]
AS
    SELECT * FROM Country;
RETURN
GO

CREATE PROCEDURE [AL_GetCountryByID]
(
    @CountryID int
)
AS
    SELECT * FROM Country
    WHERE CountryID = @CountryID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteCountry]
(
    @CountryID int
)
AS
    DELETE FROM Country
    WHERE CountryID = @CountryID;
RETURN
GO

CREATE PROCEDURE [AL_InsertCountry]
(
    @CountryID INT OUTPUT,
    @CountryName NVARCHAR(256)
)
AS
    INSERT INTO Country
    VALUES
(
    @CountryName
)
SET @CountryID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateCountry]
(
    @CountryID INT,
    @CountryName NVARCHAR(256)
)
AS
    UPDATE Country SET
    CountryName = @CountryName
WHERE CountryID = @CountryID;
RETURN
