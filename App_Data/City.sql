
CREATE TABLE [City]
(
    [CityID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [CityName] [NVARCHAR](256) NULL,
    [StateID] [INT] NULL
);
GO

CREATE PROCEDURE [AL_GetAllCities]
AS
    SELECT * FROM City;
RETURN
GO

CREATE PROCEDURE [AL_GetCityByID]
(
    @CityID int
)
AS
    SELECT * FROM City
    WHERE CityID = @CityID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteCity]
(
    @CityID int
)
AS
    DELETE FROM City
    WHERE CityID = @CityID;
RETURN
GO

CREATE PROCEDURE [AL_InsertCity]
(
    @CityID INT OUTPUT,
    @CityName NVARCHAR(256),
    @StateID INT
)
AS
    INSERT INTO City
    VALUES
(
    @CityName,
    @StateID
)
SET @CityID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateCity]
(
    @CityID INT,
    @CityName NVARCHAR(256),
    @StateID INT
)
AS
    UPDATE City SET
    CityName = @CityName,
    StateID = @StateID
WHERE CityID = @CityID;
RETURN
