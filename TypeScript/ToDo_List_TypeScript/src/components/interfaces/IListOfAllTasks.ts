export interface IListOfAllTasks{
	 	year: number;
		day: number;
		tasks: IListOfTasks[];
}

export interface IListOfTasks{
		id: string;
		cont: string;
		check: string;
}