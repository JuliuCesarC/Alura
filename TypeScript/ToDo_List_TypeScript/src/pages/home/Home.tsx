import { useState } from "react";
import Tasks from "../../components/TodoList/Tasks";
import Calendar from "../../components/calendar/Calendar";
import {
	getListOfAllTasksFromLS,
	getDayMonthYearSelected,
	selectedDayLS,
	addNewTaskLS,
	updateTaskLS,
	switchCheckLS,
	deleteTaskLS,
} from "../../components/localStorage/LocalStorage";
import { IMonthsAndListOfTasks } from "../../components/interfaces/IMonthsAndListOfTasks";
import "./Home.css";
import "./mediaHome.css";

function App() {
	const [listOfAllTasks, setListOfAllTasks] = useState<IMonthsAndListOfTasks[]>(
		getListOfAllTasksFromLS()
	);
	const [Day, setDay] = useState(getDayMonthYearSelected()[0]);
	const [Month, setMonth] = useState<number>(getDayMonthYearSelected()[1]);
	const [Year, setYear] = useState<number>(getDayMonthYearSelected()[2]);

	function selectedDayAndUpdateTaskList(
		month: number,
		year: number,
		eDay: number
	): void {
		selectedDayLS(month, year, eDay);
		setDay(eDay);
		setMonth(month);
		setYear(year);
	}
	function updateListOfAllTasks(): void {
		setListOfAllTasks(getListOfAllTasksFromLS());
	}
	return (
		<div className="container">
			<Calendar
				listOfAllTasks={listOfAllTasks}
				selectedDayAndUpdateTaskList={selectedDayAndUpdateTaskList}
			/>
			<Tasks
				listOfAllTasks={listOfAllTasks}
				updateListOfAllTasks={updateListOfAllTasks}
				addNewTaskLS={addNewTaskLS}
				switchCheckLS={switchCheckLS}
				updateTaskLS={updateTaskLS}
				deleteTaskLS={deleteTaskLS}
				month={Month}
				year={Year}
				day={Day}
			/>
			<div id="shadow"></div>
		</div>
	);
}

export default App;
