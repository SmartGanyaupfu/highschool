export interface StudentLevel {

    studentLevelId: number;
	name: string;
	dateCreated: Date;
	dateUpdated?: Date;
	datePublished?: Date;
	deleted: boolean;
	authorId?: any;
	published: boolean;
}
