import { IListOfAllTasks } from "./IListOfAllTasks";

export interface IMonthsAndListOfTasks{
	month: string,
	listOfAllTasks?: IListOfAllTasks[]
}