CREATE TABLE Teacher (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Gender NVARCHAR(10),
    Subject NVARCHAR(100)
);

CREATE TABLE Pupil (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Gender NVARCHAR(10),
    Class NVARCHAR(10)
);

CREATE TABLE TeacherPupil (
    TeacherId INT,
    PupilId INT,
    PRIMARY KEY (TeacherId, PupilId),
    FOREIGN KEY (TeacherId) REFERENCES Teacher(Id),
    FOREIGN KEY (PupilId) REFERENCES Pupil(Id)
);
