

CREATE TABLE [AL_ADLItem]
(
    [ADLItemID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [ADLItemName] [NVARCHAR](256) NULL,
    [ADLItemDescriptionID] [INT] NULL,
    [ADLStatusID] [INT] NULL,
    [ResidentID] [INT] NULL,
    [IteamTime] [DATETIME] NULL,
    [Comment] [TEXT] NULL,
    [ExtraField1] [NVARCHAR](256) NULL,
    [ExtraField2] [NVARCHAR](256) NULL,
    [ExtraField3] [NVARCHAR](256) NULL,
    [ExtraField4] [NVARCHAR](256) NULL,
    [ExtraField5] [NVARCHAR](256) NULL,
    [ExtraField6] [NVARCHAR](256) NULL,
    [ExtraField7] [NVARCHAR](256) NULL,
    [ExtraField8] [NVARCHAR](256) NULL,
    [ExtraField9] [NVARCHAR](256) NULL,
    [ExtraField10] [NVARCHAR](256) NULL
);
GO

CREATE PROCEDURE [AL_GetAllADLItems]
AS
    SELECT * FROM AL_ADLItem;
RETURN
GO

CREATE PROCEDURE [AL_GetADLItemByID]
(
    @ADLItemID int
)
AS
    SELECT * FROM AL_ADLItem
    WHERE ADLItemID = @ADLItemID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteADLItem]
(
    @ADLItemID int
)
AS
    DELETE FROM AL_ADLItem
    WHERE ADLItemID = @ADLItemID;
RETURN
GO

CREATE PROCEDURE [AL_InsertADLItem]
(
    @ADLItemID INT OUTPUT,
    @ADLItemName NVARCHAR(256),
    @ADLItemDescriptionID INT,
    @ADLStatusID INT,
    @ResidentID INT,
    @IteamTime DATETIME,
    @Comment TEXT,
    @ExtraField1 NVARCHAR(256),
    @ExtraField2 NVARCHAR(256),
    @ExtraField3 NVARCHAR(256),
    @ExtraField4 NVARCHAR(256),
    @ExtraField5 NVARCHAR(256),
    @ExtraField6 NVARCHAR(256),
    @ExtraField7 NVARCHAR(256),
    @ExtraField8 NVARCHAR(256),
    @ExtraField9 NVARCHAR(256),
    @ExtraField10 NVARCHAR(256)
)
AS
    INSERT INTO AL_ADLItem
    VALUES
(
    @ADLItemName,
    @ADLItemDescriptionID,
    @ADLStatusID,
    @ResidentID,
    @IteamTime,
    @Comment,
    @ExtraField1,
    @ExtraField2,
    @ExtraField3,
    @ExtraField4,
    @ExtraField5,
    @ExtraField6,
    @ExtraField7,
    @ExtraField8,
    @ExtraField9,
    @ExtraField10
)
SET @ADLItemID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateADLItem]
(
    @ADLItemID INT,
    @ADLItemName NVARCHAR(256),
    @ADLItemDescriptionID INT,
    @ADLStatusID INT,
    @ResidentID INT,
    @IteamTime DATETIME,
    @Comment TEXT,
    @ExtraField1 NVARCHAR(256),
    @ExtraField2 NVARCHAR(256),
    @ExtraField3 NVARCHAR(256),
    @ExtraField4 NVARCHAR(256),
    @ExtraField5 NVARCHAR(256),
    @ExtraField6 NVARCHAR(256),
    @ExtraField7 NVARCHAR(256),
    @ExtraField8 NVARCHAR(256),
    @ExtraField9 NVARCHAR(256),
    @ExtraField10 NVARCHAR(256)
)
AS
    UPDATE AL_ADLItem SET
    ADLItemName = @ADLItemName,
    ADLItemDescriptionID = @ADLItemDescriptionID,
    ADLStatusID = @ADLStatusID,
    ResidentID = @ResidentID,
    IteamTime = @IteamTime,
    Comment = @Comment,
    ExtraField1 = @ExtraField1,
    ExtraField2 = @ExtraField2,
    ExtraField3 = @ExtraField3,
    ExtraField4 = @ExtraField4,
    ExtraField5 = @ExtraField5,
    ExtraField6 = @ExtraField6,
    ExtraField7 = @ExtraField7,
    ExtraField8 = @ExtraField8,
    ExtraField9 = @ExtraField9,
    ExtraField10 = @ExtraField10
WHERE ADLItemID = @ADLItemID;
RETURN
