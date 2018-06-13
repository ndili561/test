namespace InCoreLib.DAL.Migrations.SQL
{
    public class GetHOAQuestionsAndAnswers
    {
        public static string drop_GetHOAQuestionsAndAnswers
        {
            get
            {
                return @"EXEC ('IF EXISTS (
                                SELECT type_desc, type
                                FROM sys.procedures WITH(NOLOCK)
                                WHERE NAME = ''GetHOAQuestionsAndAnswers''
                                    AND type = ''P''
                              )
                             DROP PROCEDURE dbo.GetHOAQuestionsAndAnswers')";
            }
        }


        public static string create_GetHOAQuestionsAndAnswers
        {
            get { return @"EXEC ('
                                CREATE PROCEDURE GetHOAQuestionsAndAnswers
                                    (
                                      @CaseReference INT 
                                    )
                                AS 
                                 BEGIN
                                        SET NOCOUNT ON;
                                        SELECT Q.QstnText AS ''Question'',ISNULL(A.ItemText,QA.AnswerValue) AS ''Answer'' FROM tsubHOAQuestionAnswers QA
                                        INNER JOIN dbo.lstQuestion Q
                                        ON QA.QstnID= Q.QstnID
                                        LEFT JOIN dbo.lstQuestionAltText A
                                        ON QA.QstnAltID= A.QstnAltID
                                        WHERE CaseRef = @CaseReference 
                                        AND QA.QstnairID NOT IN (4,5,6)
                                        ORDER BY Q.Seqno
                                          SET NOCOUNT OFF;
                                END')"; }
        }

        public static string update_GetHOAQuestionsAndAnswers
        {

            get { return @"ALTER PROCEDURE [dbo].[GetHOAQuestionsAndAnswers]
                                    (
                                      @CaseReference INT 
                                    )
                                AS 
                                 BEGIN
                                        SET NOCOUNT ON;
                                        SELECT Q.QstnText AS 'Question',ISNULL(A.ItemText,QA.AnswerValue) AS 'Answer' FROM tsubHOAQuestionAnswers QA
                                        INNER JOIN dbo.lstQuestion Q
                                        ON QA.QstnID= Q.QstnID
                                        LEFT JOIN dbo.lstQuestionAltText A
                                        ON QA.QstnAltID= A.QstnAltID
                                        WHERE CaseRef = @CaseReference 
                                        AND QA.QstnairID NOT IN (4,5,6)
                                        ORDER BY Q.Seqno
                                          SET NOCOUNT OFF;
                                END"; }

        }

        public static string rollback_GetHOAQuestionsAndAnswers
        {
            get { return @"ALTER PROCEDURE [dbo].[GetHOAQuestionsAndAnswers]
                                    (
                                      @CaseReference INT 
                                    )
                                AS 
                                 BEGIN
                                        SET NOCOUNT ON;
                                        SELECT Q.QstnText AS 'Question',ISNULL(A.ItemText,QA.AnswerValue) AS 'Answer' FROM tsubHOAQuestionAnswers QA
                                        INNER JOIN dbo.lstQuestion Q
                                        ON QA.QstnID= Q.QstnID
                                        LEFT JOIN dbo.lstQuestionAltText A
                                        ON QA.QstnAltID= A.QstnAltID
                                        WHERE CaseRef = @CaseReference 
                                        AND QA.QstnairID NOT IN (4,5,6)
                                        ORDER BY QA.Seqno
                                          SET NOCOUNT OFF;
                                END"; }

        }

    }

}