export interface IStudent {
    studentName: string,
    schoolTitle: string,
    participation: {
        subjectName: string,
        place: string,
        year: string
    }[]
}
