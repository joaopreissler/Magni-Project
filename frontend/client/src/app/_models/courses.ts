import { Subjects } from "./subjects";

export interface Courses {
    id: number,
    name: string,
    subjects: Subjects,
}
