export interface IListOfAllTasks{
	 	year: string;
		day: string;
		tasks: IListOfTasks[];
}

export interface IListOfTasks{
		id: string;
		cont: string;
		check: string;
}