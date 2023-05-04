import { StudentLevel } from "./student-level";

export interface StudentClass {
    studentClassId: number;
	name: string;
	studentLevelId: number;
	studentLevel: StudentLevel;
	dateCreated: string;
	dateUpdated: string;
	datePublished: string;
	deleted: boolean;
	authorId?: any;
	published: boolean;
}

