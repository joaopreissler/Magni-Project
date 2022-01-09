import { Subjects } from "./subjects";

export interface Students {
    id : number,
    name : string,
    birthday:Date,
    registration : number,
    grade: number,
    subjects : Subjects
}
