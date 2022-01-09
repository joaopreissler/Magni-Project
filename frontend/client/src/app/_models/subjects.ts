import { Students } from "./students";
import { Teacher } from "./teacher";

export interface Subjects {
    id : number,
    name : string,
    teacher : Teacher,
    CoursesId : number,
    students : Students
}
