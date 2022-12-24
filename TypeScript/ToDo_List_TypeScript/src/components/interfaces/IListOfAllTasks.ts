export interface IListOfAllTasks{
	 	year: number;
		day: string;
		tasks: {
				id: string;
				cont: string;
				check: string;
		}[];
}