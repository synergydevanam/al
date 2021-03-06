USE [AssistedLiving]
GO
/****** Object:  StoredProcedure [dbo].[AL_InsertMedicine]    Script Date: 11/13/2014 20:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AL_InsertMedicine]
(
    @MedicineID INT OUTPUT,
    @MedicineName NVARCHAR(256)
)
AS

Declare @ID int
Set @ID =(select Top 1 MedicineName from AL_Medicine where MedicineName=@MedicineName)
IF @ID is null
BEGIN
    INSERT INTO AL_Medicine
    VALUES
(
    @MedicineName
)
SET @MedicineID =SCOPE_IDENTITY()
END
ELSE
BEGIN
SET @MedicineID =@ID	
END
RETURN
