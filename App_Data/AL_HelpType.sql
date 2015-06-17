

CREATE TABLE [AL_HelpType]
(
    [AL_HelpTypeID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [HelpTypeName] [NVARCHAR](256) NULL
);
GO

CREATE PROCEDURE [AL_GetAllAL_HelpTypes]
AS
    SELECT * FROM AL_HelpType;
RETURN
GO

CREATE PROCEDURE [AL_GetAL_HelpTypeByID]
(
    @AL_HelpTypeID int
)
AS
    SELECT * FROM AL_HelpType
    WHERE AL_HelpTypeID = @AL_HelpTypeID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteAL_HelpType]
(
    @AL_HelpTypeID int
)
AS
    DELETE FROM AL_HelpType
    WHERE AL_HelpTypeID = @AL_HelpTypeID;
RETURN
GO

CREATE PROCEDURE [AL_InsertAL_HelpType]
(
    @AL_HelpTypeID INT OUTPUT,
    @HelpTypeName NVARCHAR(256)
)
AS
    INSERT INTO AL_HelpType
    VALUES
(
    @HelpTypeName
)
SET @AL_HelpTypeID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateAL_HelpType]
(
    @AL_HelpTypeID INT,
    @HelpTypeName NVARCHAR(256)
)
AS
    UPDATE AL_HelpType SET
    HelpTypeName = @HelpTypeName
WHERE AL_HelpTypeID = @AL_HelpTypeID;
RETURN
