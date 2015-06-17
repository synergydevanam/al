

CREATE TABLE [AL_ADLItemDescription]
(
    [ADLItemDescriptionID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [ADLItemDescriptionName] [NVARCHAR](256) NULL
);
GO

CREATE PROCEDURE [AL_GetAllADLItemDescriptions]
AS
    SELECT * FROM AL_ADLItemDescription;
RETURN
GO

CREATE PROCEDURE [AL_GetADLItemDescriptionByID]
(
    @ADLItemDescriptionID int
)
AS
    SELECT * FROM AL_ADLItemDescription
    WHERE ADLItemDescriptionID = @ADLItemDescriptionID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteADLItemDescription]
(
    @ADLItemDescriptionID int
)
AS
    DELETE FROM AL_ADLItemDescription
    WHERE ADLItemDescriptionID = @ADLItemDescriptionID;
RETURN
GO

CREATE PROCEDURE [AL_InsertADLItemDescription]
(
    @ADLItemDescriptionID INT OUTPUT,
    @ADLItemDescriptionName NVARCHAR(256)
)
AS
    INSERT INTO AL_ADLItemDescription
    VALUES
(
    @ADLItemDescriptionName
)
SET @ADLItemDescriptionID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateADLItemDescription]
(
    @ADLItemDescriptionID INT,
    @ADLItemDescriptionName NVARCHAR(256)
)
AS
    UPDATE AL_ADLItemDescription SET
    ADLItemDescriptionName = @ADLItemDescriptionName
WHERE ADLItemDescriptionID = @ADLItemDescriptionID;
RETURN
