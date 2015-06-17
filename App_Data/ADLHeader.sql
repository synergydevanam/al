USE anamul2
GO

CREATE TABLE [AL_ADLHeader]
(
    [ADLHeaderID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [ADLHeaderName] [NVARCHAR](256) NULL,
    [ExtraField1] [NVARCHAR](256) NULL,
    [ExtraField2] [NVARCHAR](256) NULL,
    [ExtraField3] [NVARCHAR](256) NULL,
    [ExtraField4] [NVARCHAR](256) NULL,
    [ExtraField5] [NVARCHAR](256) NULL
);
GO

CREATE PROCEDURE [AL_GetAllADLHeaders]
AS
    SELECT * FROM AL_ADLHeader;
RETURN
GO

CREATE PROCEDURE [AL_GetADLHeaderByID]
(
    @ADLHeaderID int
)
AS
    SELECT * FROM AL_ADLHeader
    WHERE ADLHeaderID = @ADLHeaderID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteADLHeader]
(
    @ADLHeaderID int
)
AS
    DELETE FROM AL_ADLHeader
    WHERE ADLHeaderID = @ADLHeaderID;
RETURN
GO

CREATE PROCEDURE [AL_InsertADLHeader]
(
    @ADLHeaderID INT OUTPUT,
    @ADLHeaderName NVARCHAR(256),
    @ExtraField1 NVARCHAR(256),
    @ExtraField2 NVARCHAR(256),
    @ExtraField3 NVARCHAR(256),
    @ExtraField4 NVARCHAR(256),
    @ExtraField5 NVARCHAR(256)
)
AS
    INSERT INTO AL_ADLHeader
    VALUES
(
    @ADLHeaderName,
    @ExtraField1,
    @ExtraField2,
    @ExtraField3,
    @ExtraField4,
    @ExtraField5
)
SET @ADLHeaderID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateADLHeader]
(
    @ADLHeaderID INT,
    @ADLHeaderName NVARCHAR(256),
    @ExtraField1 NVARCHAR(256),
    @ExtraField2 NVARCHAR(256),
    @ExtraField3 NVARCHAR(256),
    @ExtraField4 NVARCHAR(256),
    @ExtraField5 NVARCHAR(256)
)
AS
    UPDATE AL_ADLHeader SET
    ADLHeaderName = @ADLHeaderName,
    ExtraField1 = @ExtraField1,
    ExtraField2 = @ExtraField2,
    ExtraField3 = @ExtraField3,
    ExtraField4 = @ExtraField4,
    ExtraField5 = @ExtraField5
WHERE ADLHeaderID = @ADLHeaderID;
RETURN
