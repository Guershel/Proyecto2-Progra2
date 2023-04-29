	CREATE DATABASE GestiondeEducacion

USE GestiondeEducacion

CREATE TABLE SCHOOL
(
  SchoolId int IDENTITY(1,1) PRIMARY KEY,
  SchoolName varchar(50) NOT NULL UNIQUE,
  [Description] varchar(1000) NULL,
  [Address] varchar(50) NULL,
  Phone varchar(50) NULL,
  PostCode varchar(50) NULL,
  PostAddress varchar(50) NULL,
)

CREATE TABLE CLASS
(
  ClassId int IDENTITY(1,1) PRIMARY KEY,
  SchoolId int NOT NULL,
  ClassName varchar(50) NOT NULL UNIQUE,
  Description varchar(1000) NULL,
  CONSTRAINT FK_CLASS_SchoolId FOREIGN KEY (SchoolId) REFERENCES SCHOOL (SchoolId)
)

CREATE TABLE COURSE
(
  CourseId int IDENTITY(1,1) PRIMARY KEY,
  CourseName varchar(50) NOT NULL UNIQUE,
  SchoolId int NOT NULL,
  Description varchar(1000) NULL,
  CONSTRAINT FK_COURSE_SchoolId FOREIGN KEY (SchoolId) REFERENCES SCHOOL (SchoolId),
)

CREATE TABLE STUDENT
(
  StudentId int IDENTITY(1,1) PRIMARY KEY,
  ClassId int NOT NULL,
  StudentName varchar(100) NOT NULL,
  StudentNumber varchar(20) NOT NULL,
  TotalGrade float NULL,
  Address varchar(100) NULL,
  Phone varchar(20) NULL,
  EMail varchar(100) NULL,
  CONSTRAINT FK_STUDENT_ClassId FOREIGN KEY (ClassId) REFERENCES CLASS (ClassId),
)

CREATE TABLE TEACHER(
  TeacherId int IDENTITY(1,1) PRIMARY KEY,
  SchoolId int NOT NULL,
  TeacherName VARCHAR(50),
  Description VARCHAR(1000) NULL,
  CONSTRAINT FK_TEACHER_SchoolId FOREIGN KEY (SchoolId) REFERENCES SCHOOL (SchoolId),
)

CREATE TABLE STUDENT_COURSE 
(
  StudentId int NOT NULL,  
  CourseId int NOT NULL, 
  CONSTRAINT FK_STUDENT_COURSE_StudentId FOREIGN KEY (StudentId) REFERENCES STUDENT (StudentId),
  CONSTRAINT FK_STUDENT_COURSE_CourseId FOREIGN KEY (CourseId) REFERENCES COURSE (CourseId)
)

CREATE TABLE TEACHER_COURSE
(
  TeacherId int NOT NULL,
  CourseId int NOT NULL, 
  CONSTRAINT FK_TEACHER_COURSE_TeacherId FOREIGN KEY (TeacherId) REFERENCES TEACHER (TeacherId),
  CONSTRAINT FK_TEACHER_COURSE_CourseId FOREIGN KEY (CourseId) REFERENCES COURSE (CourseId)
)

CREATE TABLE GRADE(
  GradeId int IDENTITY(1,1) PRIMARY KEY,
  StudentId int NOT NULL,
  CourseId int NOT NULL,
  Grade float NOT NULL,
  Comment varchar(1000) NULL,
  CONSTRAINT FK_GRADE_StudentId FOREIGN KEY (StudentId) REFERENCES STUDENT (StudentId),
  CONSTRAINT FK_GRADE_CourseId FOREIGN KEY (CourseId) REFERENCES COURSE (CourseId),
)

CREATE TABLE USERS
(
  ID INT IDENTITY (1,1),
  Email varchar (100) ,
  Password varchar (100),
  CONSTRAINT FK_ID PRIMARY KEY (ID),
  CONSTRAINT UQ_EMAIL UNIQUE (Email)
)

GO
INSERT INTO USERS VALUES ('prueba@gmail.com', 'prueba2023')
GO

--PROCEDIMIENTOS SCHOOL --
CREATE PROCEDURE SP_InsertSchool
( 
@SchoolName varchar(50)  ,
@Description varchar(1000) ,
@Address varchar(50) ,
@Phone varchar(50) ,
@PostCode varchar(50) ,
@PostAddress varchar(50) )
AS BEGIN 

	IF NOT EXISTS (SELECT * FROM SCHOOL where LTRIM(RTRIM(UPPER(SchoolName))) = LTRIM(RTRIM(UPPER(@SchoolName)))) 
	BEGIN 
		INSERT INTO SCHOOL(SchoolName, Description, Address, Phone, PostCode, PostAddress) 
		VALUES(UPPER(@SchoolName), UPPER(@Description), UPPER(@Address), UPPER(@Phone), UPPER(@PostCode), UPPER(@PostAddress)) 

		SELECT 'Escuela registrada.' as Result
	END 
	ELSE BEGIN 
		SELECT 'Escuela ya existe registrada.' as Result 
	END 
END 
go 
CREATE PROCEDURE SP_ListSchool
AS BEGIN 
	SELECT * FROM SCHOOL 
END
go
CREATE PROCEDURE SP_ListSchool_Id(
@Id int)
AS BEGIN 
	IF (@Id = 0 ) begin
		SELECT * FROM SCHOOL
	end 
	else begin 
		SELECT * FROM SCHOOL where SchoolId = @Id
	end 
	
END 
GO
CREATE PROCEDURE SP_UpdateSchool( 
@Id INT, 
@SchoolName varchar(50)  ,
@Description varchar(1000) ,
@Address varchar(50) ,
@Phone varchar(50) ,
@PostCode varchar(50) ,
@PostAddress varchar(50) )
AS BEGIN 

	IF EXISTS (SELECT * FROM SCHOOL where SchoolId = @Id) 
	BEGIN 

		UPDATE SCHOOL 
		SET SchoolName = @SchoolName
		, Description = @Description
		, Address = @Address
		, Phone = @Phone
		, PostCode = @PostCode
		, PostAddress = @PostAddress
		WHERE SchoolId = @Id
		

		SELECT 'Escuela editada.' as Result
	END 
	
END 
GO 
CREATE PROCEDURE SP_BORRARSCHOOL
(
    @SchoolId int
)
AS
BEGIN
    DELETE FROM SCHOOL WHERE SchoolId = @SchoolId
END
GO

-- PROCEDIMIENTOS CLASS --
CREATE PROCEDURE SP_AGREGARCLASS
(
    @SchoolId int,
    @ClassName varchar(50),
    @Description varchar(1000)
)
AS
BEGIN
	IF NOT EXISTS( SELECT * FROM CLASS WHERE UPPER(LTRIM(RTRIM(ClassName))) = UPPER(LTRIM(RTRIM(@ClassName)))) 
	BEGIN 
		    INSERT INTO CLASS (SchoolId, ClassName, Description)
			VALUES ( @SchoolId, upper(@ClassName), upper(@Description))
			SELECT 'Registro exitoso' AS Result
	END 
	ELSE BEGIN 
		SELECT 'La clase ya existe.' AS Result
	END 

END
GO 
CREATE PROCEDURE SP_BORRARCLASS
(
    @ClassId int
)
AS
BEGIN
    DELETE FROM CLASS WHERE ClassId = @ClassId
END
GO 
CREATE PROCEDURE SP_MODIFICARCLASS
(
    @ClassId int,
    @SchoolId int,
    @ClassName varchar(50),
    @Description varchar(1000)
)
AS
BEGIN
	
    UPDATE CLASS SET
        SchoolId = @SchoolId,
        ClassName = @ClassName,
        Description = @Description
    WHERE ClassId = @ClassId
END
GO
CREATE PROCEDURE SP_CONSULTARCLASS
(
    @ClassId int
)
AS
BEGIN
    SELECT * FROM CLASS WHERE ClassId = @ClassId
END
GO 
CREATE PROCEDURE SP_CONSULTARCLASSTotal
AS
BEGIN
    SELECT * FROM CLASS
END

GO
CREATE PROCEDURE SP_ListClass_Id(
@ClassId int)
AS BEGIN 
	IF (@ClassId = 0 ) begin
		SELECT * FROM CLASS
	end 
	else begin 
		SELECT * FROM CLASS where ClassId = @ClassId
	end 
	
END --O USAR ESTE TIPO asi 

GO

-- PROCEDIMIENTOS COURSE --
CREATE PROCEDURE SP_AGREGARCOURSE
(
  @SchoolId int,
  @CourseName varchar(50), 
  @Description varchar(1000)
)
AS
BEGIN
	IF NOT EXISTS( SELECT * FROM COURSE WHERE UPPER(LTRIM(RTRIM(CourseName))) = UPPER(LTRIM(RTRIM(@CourseName)))) 
	BEGIN 
		    INSERT INTO COURSE (SchoolId, CourseName, Description)
			VALUES ( @SchoolId, upper(@CourseName), upper(@Description))
			SELECT 'Registro exitoso' AS Result
	END 
	ELSE BEGIN 
		SELECT 'El curso ya existe.' AS Result
	END 

END
go 
CREATE PROCEDURE SP_BORRARCOURSE
(
  @CourseId int
)
AS
BEGIN
  DELETE FROM COURSE WHERE CourseId = @CourseId
END
GO

CREATE PROCEDURE SP_CONSULTARCOURSE
(
  @CourseId int
)
AS
BEGIN
  IF (@CourseId = 0) BEGIN 
	SELECT * FROM COURSE
  END 
  ELSE BEGIN 
	SELECT * FROM COURSE WHERE CourseId = @CourseId
  END 
END
GO

CREATE PROCEDURE SP_MODIFICARCOURSE
(
  @CourseId int,
  @CourseName varchar(50),
  @SchoolId int,
  @Description varchar(1000)
)
AS
BEGIN
  UPDATE COURSE SET CourseName = @CourseName, SchoolId = @SchoolId, Description = @Description
  WHERE CourseId = @CourseId
END

GO
CREATE PROCEDURE SP_ListCourse_Id(
@CourseId int)
AS BEGIN 
	IF (@CourseId = 0 ) begin
		SELECT * FROM COURSE
	end 
	else begin 
		SELECT * FROM COURSE where CourseId = @CourseId
	end 
	
END
GO

-- PROCEDIMIENTOS STUDENT --
CREATE PROCEDURE SP_AGREGARSTUDENT
(
    @ClassId int,
    @StudentName varchar(100),
    @StudentNumber varchar(20),
    @TotalGrade float = NULL,
    @Address varchar(100) = NULL,
    @Phone varchar(20) = NULL,
    @EMail varchar(100) = NULL
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM STUDENT where UPPER(LTRIM(RTRIM(StudentName))) = UPPER(LTRIM(RTRIM(@StudentName))))
	BEGIN 
		INSERT INTO STUDENT (ClassId, StudentName, StudentNumber, TotalGrade, Address, Phone, EMail)
		VALUES (@ClassId, UPPER(@StudentName), UPPER(@StudentNumber), UPPER(@TotalGrade), UPPER(@Address), UPPER(@Phone), UPPER(@EMail))
		SELECT 'Registro exitoso' as Result
	END 
	ELSE BEGIN 
		SELECT 'El estudiante ya existe.' as Result
	END 
END
GO

CREATE PROCEDURE SP_BORRARSTUDENT
(
    @StudentId int
)
AS
BEGIN
    DELETE FROM STUDENT WHERE StudentId = @StudentId
END
GO

CREATE PROCEDURE SP_CONSULTARSTUDENT
(
    @StudentId int
)
AS
BEGIN
	IF (@StudentId = 0) BEGIN 
		SELECT * FROM STUDENT
	END 
	ELSE BEGIN 
		SELECT * FROM STUDENT WHERE StudentId = @StudentId
	END 
END
GO

CREATE PROCEDURE SP_MODIFICARSTUDENT
(
    @StudentId int,
    @ClassId int = NULL,
    @StudentName varchar(100) = NULL,
    @StudentNumber varchar(20) = NULL,
    @TotalGrade float = NULL,
    @Address varchar(100) = NULL,
    @Phone varchar(20) = NULL,
    @EMail varchar(100) = NULL
)
AS
BEGIN
    UPDATE STUDENT SET
        ClassId = COALESCE(@ClassId, ClassId),
        StudentName = COALESCE(@StudentName, StudentName),
        StudentNumber = COALESCE(@StudentNumber, StudentNumber),
        TotalGrade = COALESCE(@TotalGrade, TotalGrade),
        Address = COALESCE(@Address, Address),
        Phone = COALESCE(@Phone, Phone),
        EMail = COALESCE(@EMail, EMail)
    WHERE StudentId = @StudentId
END

GO
CREATE PROCEDURE SP_ListStudent_Id(
@StudentId int)
AS BEGIN 
	IF (@StudentId = 0 ) begin
		SELECT * FROM STUDENT
	end 
	else begin 
		SELECT * FROM STUDENT where StudentId = @StudentId
	end 
	
END
GO

-- PROCEDIMIENTOS TEACHER --
CREATE PROCEDURE SP_AGREGARTEACHER
(
  @SchoolId INT,
  @TeacherName VARCHAR(50),
  @Description VARCHAR(1000)
	)
AS
BEGIN
  IF NOT EXISTS(SELECT * FROM TEACHER where UPPER(LTRIM(RTRIM(TeacherName))) = UPPER(LTRIM(RTRIM(@TeacherName))))
  BEGIN 
		INSERT INTO TEACHER (SchoolId, TeacherName, Description)
		VALUES (@SchoolId, UPPER(@TeacherName), UPPER(@Description))
		SELECT 'Registro exitoso' as Result
	END 
	ELSE BEGIN 
		SELECT 'El Profesor ya existe.' as Result
	END
END
GO

CREATE PROCEDURE SP_BORRARTEACHER
(
  @TeacherId INT
)
AS
BEGIN
  DELETE FROM TEACHER
  WHERE TeacherId = @TeacherId
END
GO

CREATE PROCEDURE SP_CONSULTARTEACHER
(
  @TeacherId INT
)
AS
BEGIN
  IF (@TeacherId = 0) BEGIN 
		SELECT * FROM TEACHER
	END 
	ELSE BEGIN 
		SELECT * FROM TEACHER WHERE TeacherId = @TeacherId
	END 
END
GO

CREATE PROCEDURE SP_MODIFICARTEACHER
(
  @TeacherId INT,
  @SchoolId INT,
  @TeacherName VARCHAR(50),
  @Description VARCHAR(1000)
)
AS
BEGIN
  UPDATE TEACHER
  SET 
	  SchoolId = @SchoolId,
      TeacherName = @TeacherName,
      Description = @Description
  WHERE TeacherId = @TeacherId
END

GO
CREATE PROCEDURE SP_ListTeacher_Id(
@TeacherId int)
AS BEGIN 
	IF (@TeacherId = 0 ) begin
		SELECT * FROM TEACHER
	end 
	else begin 
		SELECT * FROM TEACHER where TeacherId = @TeacherId
	end 
	
END
GO

-- PROCEDIMIENTOS STUDENT_COURSE --
CREATE PROCEDURE SP_AGREGARSTUDENTCOURSE
(
  @StudentId int,
  @CourseId int
  )
AS
BEGIN
  IF NOT EXISTS(SELECT * FROM STUDENT_COURSE where UPPER(LTRIM(RTRIM(StudentId))) = UPPER(LTRIM(RTRIM(@StudentId))) AND UPPER(LTRIM(RTRIM(CourseId))) = UPPER(LTRIM(RTRIM(@CourseId))))
  BEGIN 
		INSERT INTO STUDENT_COURSE (StudentId, CourseId)
		VALUES (@StudentId, UPPER(@CourseId))
		SELECT 'Registro exitoso' as Result
	END 
	ELSE BEGIN 
		SELECT 'El Curso del estudiante ya existe.' as Result
	END
END

CREATE PROCEDURE SP_ObtenerEstudianteXCedula(
	@Cedula varchar(100)
) 
AS BEGIN 
	SELECT * FROM [dbo].[STUDENT] WHERE StudentNumber = @Cedula
END 
GO 
ALTER PROCEDURE SP_ObtenerCursosActuales(
@StudentId varchar(100) 
)
as begin 

	SELECT CO.* FROM STUDENT_COURSE SC
	INNER JOIN [STUDENT] st on st.StudentId= sc.StudentId
	inner join [COURSE] CO on co.CourseId = sc.CourseId
	WHERE st.StudentNumber = @StudentId
end 
go 
ALTER PROCEDURE [dbo].[SP_MODIFICARSTUDENTCOURSE]
  @StudentId int,
  @CourseId int, 
  @CourseOld int
AS
BEGIN
  UPDATE STUDENT_COURSE
  SET CourseId = @CourseId
  WHERE StudentId = @StudentId
  AND CourseId = @CourseOld
END
GO 
ALTER PROCEDURE [dbo].[SP_BORRARSTUDENTCOURSE]
  @StudentId int,
  @CourseId int
AS
BEGIN
  DELETE FROM STUDENT_COURSE
  where StudentId = @StudentId
  and CourseId = @CourseId
END


CREATE PROCEDURE SP_CONSULTARSTUDENTCOURSE
(
		@StudentId int,
		@CourseId int
)
AS		
BEGIN
  IF (@StudentId = 0) BEGIN 
		SELECT * FROM STUDENT_COURSE
	END 
	ELSE BEGIN 
		SELECT * FROM STUDENT_COURSE WHERE StudentId = @StudentId  AND CourseId = @CourseId
	END 
END
GO

-- PROCEDIMIENTOS TEACHER_COURSE --
CREATE PROCEDURE SP_AGREGARTEACHERCOURSE
(
  @TeacherId int,
  @CourseId int
  )
AS
BEGIN
  IF NOT EXISTS(SELECT * FROM TEACHER_COURSE where UPPER(LTRIM(RTRIM(TeacherId))) = UPPER(LTRIM(RTRIM(@TeacherId)))  AND UPPER(LTRIM(RTRIM(CourseId))) = UPPER(LTRIM(RTRIM(@CourseId))))
  BEGIN 
		INSERT INTO TEACHER_COURSE (TeacherId, CourseId)
		VALUES (@TeacherId, UPPER(@CourseId))
		SELECT 'Registro exitoso' as Result
	END 
	ELSE BEGIN 
		SELECT 'El Curso del profesor ya existe.' as Result
	END
END

GO
CREATE PROCEDURE SP_BORRARTEACHERCOURSE
  @TeacherId int,
  @CourseId int
AS
BEGIN
  DELETE FROM TEACHER_COURSE
	
END
GO

CREATE PROCEDURE SP_CONSULTARTEACHERCOURSE
(
		@TeacherId int,
		@CourseId int
)
AS		
BEGIN
  IF (@TeacherId = 0) BEGIN 
		SELECT * FROM TEACHER_COURSE
	END 
	ELSE BEGIN 
		SELECT * FROM TEACHER_COURSE WHERE TeacherId = @TeacherId AND CourseId = @CourseId
	END 
END
GO

CREATE PROCEDURE SP_MODIFICARTEACHERCOURSE
  @TeacherId int,
  @CourseId int
AS
BEGIN
  UPDATE TEACHER_COURSE
  SET CourseId = @CourseId
  WHERE TeacherId = @TeacherId
END
GO

-- PROCEDIMIENTOS GRADE --
CREATE PROCEDURE SP_AGREGARGRADE
  @StudentId int,
  @CourseId int,
  @Grade float,
  @Comment varchar(1000)
AS
BEGIN
  IF NOT EXISTS(SELECT * FROM GRADE where UPPER(LTRIM(RTRIM(Grade))) = UPPER(LTRIM(RTRIM(@Grade))))
  BEGIN 
		INSERT INTO GRADE (StudentId, CourseId, Grade, Comment)
		VALUES (@StudentId, @CourseId, UPPER(@Grade), UPPER(@Comment))
		SELECT 'Registro exitoso' as Result
	END 
	ELSE BEGIN 
		SELECT 'El Grado ya existe.' as Result
	END
END

GO
CREATE PROCEDURE SP_BORRARGRADE
  @GradeId int
AS
BEGIN
  DELETE FROM GRADE
  WHERE GradeId = @GradeId
END
GO

CREATE PROCEDURE SP_CONSULTARGRADE
(
    @Grade int
)
AS
BEGIN
	IF (@Grade = 0) BEGIN 
		SELECT * FROM GRADE
	END 
	ELSE BEGIN 
		SELECT * FROM GRADE WHERE Grade = @Grade
	END 
END
GO

CREATE PROCEDURE SP_MODIFICARGRADE
  @GradeId int,
  @StudentId int,
  @CourseId int,
  @Grade float,
  @Comment varchar(1000)
AS
BEGIN
  UPDATE GRADE
  SET StudentId = @StudentId, CourseId = @CourseId, Grade = @Grade, Comment = @Comment
  WHERE GradeId = @GradeId
END
GO
CREATE PROCEDURE SP_ListGrade_Id(
@GradeId int)
AS BEGIN 
	IF (@GradeId = 0 ) begin
		SELECT * FROM GRADE
	end 
	else begin 
		SELECT * FROM GRADE where GradeId = @GradeId
	end 
	
END
GO
--PROCEDIMIENTO LOGIN--

CREATE PROCEDURE SesionLogin
  @Email varchar(100) = '',
  @Password varchar(100) = ''
AS
BEGIN
  SELECT Email, Password
  FROM USERS
  WHERE Email = @Email AND Password = @Password
END