export interface ITeacher {
    name: string,
    schoolTitle: string,
    participationList: {
        id:number,
        studentName: string,
        subjectName: string,
        place: string,
        year: string
    }[]
}
