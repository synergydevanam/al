
CREATE TABLE [State]
(
    [StateID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [StateName] [NVARCHAR](256) NULL,
    [CountryID] [INT] NULL
);
GO

CREATE PROCEDURE [AL_GetAllStates]
AS
    SELECT * FROM State;
RETURN
GO

CREATE PROCEDURE [AL_GetStateByID]
(
    @StateID int
)
AS
    SELECT * FROM State
    WHERE StateID = @StateID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteState]
(
    @StateID int
)
AS
    DELETE FROM State
    WHERE StateID = @StateID;
RETURN
GO

CREATE PROCEDURE [AL_InsertState]
(
    @StateID INT OUTPUT,
    @StateName NVARCHAR(256),
    @CountryID INT
)
AS
    INSERT INTO State
    VALUES
(
    @StateName,
    @CountryID
)
SET @StateID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateState]
(
    @StateID INT,
    @StateName NVARCHAR(256),
    @CountryID INT
)
AS
    UPDATE State SET
    StateName = @StateName,
    CountryID = @CountryID
WHERE StateID = @StateID;
RETURN
