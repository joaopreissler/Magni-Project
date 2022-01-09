import { Courses } from "./courses";

export interface Colleges {
    id: number,
    name: string,
    courses: Courses[],
}
