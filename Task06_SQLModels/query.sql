SELECT DISTINCT T.*
FROM Teacher T
JOIN TeacherPupil TP ON T.Id = TP.TeacherId
JOIN Pupil P ON P.Id = TP.PupilId
WHERE P.FirstName = 'გიორგი';
