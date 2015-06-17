

CREATE TABLE [AL_Help]
(
    [AL_HelpID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [HelpTypeID] [INT] NULL,
    [Question] [NTEXT] NULL,
    [Answer] [NTEXT] NULL
);
GO

CREATE PROCEDURE [AL_GetAllAL_Helps]
AS
    SELECT * FROM AL_Help;
RETURN
GO

CREATE PROCEDURE [AL_GetAL_HelpByID]
(
    @AL_HelpID int
)
AS
    SELECT * FROM AL_Help
    WHERE AL_HelpID = @AL_HelpID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteAL_Help]
(
    @AL_HelpID int
)
AS
    DELETE FROM AL_Help
    WHERE AL_HelpID = @AL_HelpID;
RETURN
GO

CREATE PROCEDURE [AL_InsertAL_Help]
(
    @AL_HelpID INT OUTPUT,
    @HelpTypeID INT,
    @Question NTEXT,
    @Answer NTEXT
)
AS
    INSERT INTO AL_Help
    VALUES
(
    @HelpTypeID,
    @Question,
    @Answer
)
SET @AL_HelpID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateAL_Help]
(
    @AL_HelpID INT,
    @HelpTypeID INT,
    @Question NTEXT,
    @Answer NTEXT
)
AS
    UPDATE AL_Help SET
    HelpTypeID = @HelpTypeID,
    Question = @Question,
    Answer = @Answer
WHERE AL_HelpID = @AL_HelpID;
RETURN
