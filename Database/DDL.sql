CREATE TABLE SchoolarLevels (
    idSchoolarLevel INTEGER PRIMARY KEY AUTOINCREMENT,
    nameLevel varchar(15) NOT NULL
);

CREATE TABLE Schedules (
    idSchedule INTEGER PRIMARY KEY AUTOINCREMENT,
    startTimeSchedule TIMESTAMP NOT NULL,
    endTimeSchedule TIMESTAMP NOT NULL,
    daySchedule varchar(15) NOT NULL
);

CREATE TABLE Subjects(
    idSubject INTEGER PRIMARY KEY AUTOINCREMENT,
    nameSubject varchar(25) NOT NULL,
    infoSubject varchar(45) NOT NULL
);

CREATE TABLE Teachers(
    idTeacher INTEGER PRIMARY KEY AUTOINCREMENT,
    nameTeacher varchar(45) NOT NULL,
    ccTeacher varchar(15) NOT NULL,
    emailTeacher varchar(45) NOT NULL,
    phoneTeacher varchar(15) NOT NULL,
    infoTeacher varchar(45) NOT NULL
);

CREATE TABLE SubLevels(
    idSublevel INTEGER PRIMARY KEY AUTOINCREMENT,
    nameSublevel varchar(15) NOT NULL,
    yearSublevel DATE NOT NULL,
    idSchLevelS INTEGER NOT NULL,
    FOREIGN KEY (idSchLevelS) REFERENCES SchoolarLevels(idSchoolarLevel)
);

CREATE TABLE Students(
    idStudent INTEGER PRIMARY KEY AUTOINCREMENT,
    nameStudent varchar(45) NOT NULL,
    ccStudent varchar(15) NOT NULL,
    emailStudent varchar(45) NOT NULL,
    phoneStudent varchar(15) NOT NULL,
    idSublevelS INT NOT NULL,
    FOREIGN KEY (idSublevelS) REFERENCES SubLevels(idSublevel)
);

CREATE TABLE SubjectFull(
    idSubjectFull INTEGER PRIMARY KEY AUTOINCREMENT,
    yearSf DATE NOT NULL,
    idScheduleSf INT NOT NULL,
    idSubjectSf INT NOT NULL,
    idTeacherSf INT NOT NULL,
    FOREIGN KEY (idScheduleSf) REFERENCES Schedules(idSchedule),
    FOREIGN KEY (idSubjectSf) REFERENCES Subjects(idSubject),
    FOREIGN KEY (idTeacherSf) REFERENCES Teachers(idTeacher)
);

CREATE TABLE Notes(
    idNote INTEGER PRIMARY KEY AUTOINCREMENT,
    noteN float NOT NULL,
    idStudentN INT NOT NULL,
    idSubjectFullN INT NOT NULL,
    FOREIGN KEY (idStudentN) REFERENCES Students(idStudent),
    FOREIGN KEY (idSubjectFullN) REFERENCES SubjectFull(idSubjectFull)
);

CREATE TABLE Class(
    idClass INTEGER PRIMARY KEY AUTOINCREMENT,
    classroomClass varchar(25) NOT NULL,
    idSublevelC INT NOT NULL,
    idSubjectFullC INT NOT NULL,
    FOREIGN KEY (idSublevelC) REFERENCES SubLevels(idSublevel),
    FOREIGN KEY (idSubjectFullC) REFERENCES SubjectFull(idSubjectFull)
);