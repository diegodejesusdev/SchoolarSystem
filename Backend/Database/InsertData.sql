INSERT INTO SchoolarLevels (nameLevel) VALUES ('Primero');
INSERT INTO SchoolarLevels (nameLevel) VALUES ('Segundo');
INSERT INTO SchoolarLevels (nameLevel) VALUES ('Tercero');
INSERT INTO SchoolarLevels (nameLevel) VALUES ('Cuarto');
INSERT INTO SchoolarLevels (nameLevel) VALUES ('Quinto');

INSERT INTO Schedules (startTimeSchedule, endTimeSchedule, daySchedule)
VALUES ('07:00:00', '09:00:00', 'LUNES');
INSERT INTO Schedules (startTimeSchedule, endTimeSchedule, daySchedule)
VALUES ('09:00:00', '11:00:00', 'LUNES');
INSERT INTO Schedules (startTimeSchedule, endTimeSchedule, daySchedule)
VALUES ('07:00:00', '09:00:00', 'MARTES');
INSERT INTO Schedules (startTimeSchedule, endTimeSchedule, daySchedule)
VALUES ('09:00:00', '11:00:00', 'MARTES');
INSERT INTO Schedules (startTimeSchedule, endTimeSchedule, daySchedule)
VALUES ('07:00:00', '09:00:00', 'MIERCOLES');
INSERT INTO Schedules (startTimeSchedule, endTimeSchedule, daySchedule)
VALUES ('09:00:00', '11:00:00', 'MIERCOLES');

INSERT INTO Subjects(nameSubject, infoSubject) VALUES ('Matemáticas', 'números pues');
INSERT INTO Subjects(nameSubject, infoSubject) VALUES ('Español', 'letras pues');
INSERT INTO Subjects(nameSubject, infoSubject) VALUES ('Geometría', 'figuras pues');
INSERT INTO Subjects(nameSubject, infoSubject) VALUES ('Aplicaciones Web', 'apps pues');

INSERT INTO Teachers (nameTeacher, ccTeacher, emailTeacher, phoneTeacher, infoTeacher)
VALUES ('Pablo Ruiz', '1002456963', 'pablo@gmail.com', '3115636357','The Best');
INSERT INTO Teachers (nameTeacher, ccTeacher, emailTeacher, phoneTeacher, infoTeacher)
VALUES ('Carlos Uribe', '1004569643', 'carlos@gmail.com', '3145696357','El Mynor');
INSERT INTO Teachers (nameTeacher, ccTeacher, emailTeacher, phoneTeacher, infoTeacher)
VALUES ('Sandra Ramirez', '107894963', 'sandra@gmail.com', '3115456123','MilloGang');

INSERT INTO SubLevels(nameSublevel, yearSublevel, idSchLevelS) VALUES ('-A','2024-02-18',1);
INSERT INTO SubLevels(nameSublevel, yearSublevel, idSchLevelS) VALUES ('-A','2024-02-18',2);
INSERT INTO SubLevels(nameSublevel, yearSublevel, idSchLevelS) VALUES ('-A','2024-02-18',3);
INSERT INTO SubLevels(nameSublevel, yearSublevel, idSchLevelS) VALUES ('-A','2024-02-18',4);
INSERT INTO SubLevels(nameSublevel, yearSublevel, idSchLevelS) VALUES ('-A','2024-02-18',5);

INSERT INTO Students(nameStudent, ccStudent, emailStudent, phoneStudent, idSublevelS)
VALUES ('Alejandra Jimenez', '1006569874', 'aleja@gmail.com', '3216549877', 1);
INSERT INTO Students(nameStudent, ccStudent, emailStudent, phoneStudent, idSublevelS)
VALUES ('Yesica Quito', '1006456174', 'yesica@gmail.com', '3456788977', 2);
INSERT INTO Students(nameStudent, ccStudent, emailStudent, phoneStudent, idSublevelS)
VALUES ('David Andrade', '1006556478', 'david@gmail.com', '3216536985', 3);
INSERT INTO Students(nameStudent, ccStudent, emailStudent, phoneStudent, idSublevelS)
VALUES ('Andres Soto', '1234589874', 'andres@gmail.com', '3002249877', 4);
INSERT INTO Students(nameStudent, ccStudent, emailStudent, phoneStudent, idSublevelS)
VALUES ('Sara Narvaez', '1569329874', 'sara@gmail.com', '3217854127', 5);

INSERT INTO SubjectFull(yearSf, idScheduleSf, idSubjectSf, idTeacherSf) VALUES ('2024-02-18', 1, 1, 3);
INSERT INTO SubjectFull(yearSf, idScheduleSf, idSubjectSf, idTeacherSf) VALUES ('2024-02-18', 5, 1, 3);
INSERT INTO SubjectFull(yearSf, idScheduleSf, idSubjectSf, idTeacherSf) VALUES ('2024-02-18', 2, 2, 1);
INSERT INTO SubjectFull(yearSf, idScheduleSf, idSubjectSf, idTeacherSf) VALUES ('2024-02-18', 3, 3, 2);
INSERT INTO SubjectFull(yearSf, idScheduleSf, idSubjectSf, idTeacherSf) VALUES ('2024-02-18', 4, 4, 1);

INSERT INTO Notes(noteN, idStudentN, idSubjectFullN) VALUES (4.5, 1, 1);
INSERT INTO Notes(noteN, idStudentN, idSubjectFullN) VALUES (1.5, 2, 1);
INSERT INTO Notes(noteN, idStudentN, idSubjectFullN) VALUES (3.4, 3, 2);
INSERT INTO Notes(noteN, idStudentN, idSubjectFullN) VALUES (2.3, 4, 3);
INSERT INTO Notes(noteN, idStudentN, idSubjectFullN) VALUES (5.0, 5, 4);

INSERT INTO Class(classroomClass, idSublevelC, idSubjectFullC) VALUES ('10', 1, 1);
INSERT INTO Class(classroomClass, idSublevelC, idSubjectFullC) VALUES ('04', 2, 2);
INSERT INTO Class(classroomClass, idSublevelC, idSubjectFullC) VALUES ('02', 3, 3);
INSERT INTO Class(classroomClass, idSublevelC, idSubjectFullC) VALUES ('06', 4, 4);
INSERT INTO Class(classroomClass, idSublevelC, idSubjectFullC) VALUES ('07', 5, 5);