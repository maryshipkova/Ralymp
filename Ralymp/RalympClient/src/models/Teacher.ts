export interface ITeacher {
    teacherName: string,
    schoolTitle: string,
    participations: {
        studentName: string,
        subjectName: string,
        place: string,
        year: string
    }[]
}
