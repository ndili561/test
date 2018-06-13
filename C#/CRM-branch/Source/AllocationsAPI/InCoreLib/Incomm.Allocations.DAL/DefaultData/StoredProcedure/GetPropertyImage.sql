Create PROCEDURE [dbo].[GetPropertyImage]
            (
              @PropertyCode VARCHAR(30) = NULL
            )
            AS 
            BEGIN
             SELECT	PropertyCode,ImageContent,ImageType,ImagePath
             FROM     Cloudvoids.dbo.PropertyImage
             WHERE PropertyCode =@PropertyCode
            END