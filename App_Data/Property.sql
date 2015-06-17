
CREATE TABLE [AL_Property]
(
    [PropertyID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [PropertyName] [NVARCHAR](256) NULL,
    [Address] [TEXT] NULL,
    [CountryID] [INT] NULL,
    [StateID] [INT] NULL,
    [CityID] [INT] NULL,
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

CREATE PROCEDURE [AL_GetAllProperties]
AS
    SELECT * FROM AL_Property;
RETURN
GO

CREATE PROCEDURE [AL_GetPropertyByID]
(
    @PropertyID int
)
AS
    SELECT * FROM AL_Property
    WHERE PropertyID = @PropertyID;
RETURN
GO

CREATE PROCEDURE [AL_DeleteProperty]
(
    @PropertyID int
)
AS
    DELETE FROM AL_Property
    WHERE PropertyID = @PropertyID;
RETURN
GO

CREATE PROCEDURE [AL_InsertProperty]
(
    @PropertyID INT OUTPUT,
    @PropertyName NVARCHAR(256),
    @Address TEXT,
    @CountryID INT,
    @StateID INT,
    @CityID INT,
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
    INSERT INTO AL_Property
    VALUES
(
    @PropertyName,
    @Address,
    @CountryID,
    @StateID,
    @CityID,
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
SET @PropertyID =SCOPE_IDENTITY()
RETURN
GO

CREATE PROCEDURE [AL_UpdateProperty]
(
    @PropertyID INT,
    @PropertyName NVARCHAR(256),
    @Address TEXT,
    @CountryID INT,
    @StateID INT,
    @CityID INT,
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
    UPDATE AL_Property SET
    PropertyName = @PropertyName,
    Address = @Address,
    CountryID = @CountryID,
    StateID = @StateID,
    CityID = @CityID,
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
WHERE PropertyID = @PropertyID;
RETURN
