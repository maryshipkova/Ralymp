export interface IStudent {
    name: string,
    schoolTitle: string,
    participationList: {
        id:number,
        subjectName: string,
        place: string,
        year: number
    }[],
    id?:number,
    categoryRows?: {
        title: string,
        value: number
    }[],
    totalWinsOnMunicipalStage?: number,
    totalWinsOnRegionStage?: number,
    totalWinsOnCountryStage?: number
}
