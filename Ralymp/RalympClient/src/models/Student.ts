export interface IStudent {
    studentName: string,
    schoolTitle: string,
    participation: {
        subjectName: string,
        place: string,
        year: number
    }[],
    studentId?:number,
    categoryRows?: {
        title: string,
        value: number
    }[],
    totalWinsOnMunicipalStage?: number,
    totalWinsOnRegionStage?: number,
    totalWinsOnCountryStage?: number
}
