import { useState } from "react";
import "./Home.css";
import "./mediaHome.css";
import CalendarDays from "../../components/calendar/CalendarDays";
import Tasks from "../../components/TodoList/Tasks";
import {
	getListOfAllTasksFromLS,
	getMonthYear,
	getDayMonthYearSelected,
	prevNextMonth,
	selectedDayLS,
	addNewTaskLS,
	updateTaskLS,
	switchCheckLS,
	deleteTaskLS,
} from "../../components/localStorage/LocalStorage";
import { IMonthsAndListOfTasks } from "../../components/interfaces/IMonthsAndListOfTasks";

function App() {
	const [listOfAllTasks, setListOfAllTasks] = useState<IMonthsAndListOfTasks[]>(
		getListOfAllTasksFromLS()
	);
	const [Day, setDay] = useState(getDayMonthYearSelected()[0]);
	const [Month, setMonth] = useState<number>(getDayMonthYearSelected()[1]);
	const [Year, setYear] = useState<number>(getDayMonthYearSelected()[2]);
	const [MonthCalendar, setMonthCalendar] = useState<number>(getDayMonthYearSelected()[1]);
	const [YearCalendar, setYearCalendar] = useState<number>(getDayMonthYearSelected()[2]);

	function changeToNextOrPrevMonth(
		ePrevNext: React.MouseEvent<HTMLButtonElement, MouseEvent>
	): void {
		prevNextMonth(ePrevNext);
		setMonthCalendar(getMonthYear()[0]);
		setYearCalendar(getMonthYear()[1]);
	}

	function selectedDayAndUpdateTaskList(eDay: number): void {
		selectedDayLS(MonthCalendar, YearCalendar, eDay);
		setListOfAllTasks(getListOfAllTasksFromLS());
		setDay(eDay);
		setMonth(MonthCalendar);
		setYear(YearCalendar);
	}
	function updateListOfAllTasks(): void {
		setListOfAllTasks(getListOfAllTasksFromLS());
	}
	return (
		<div className="container">
			<div id="Calendar">
				<header id="Header">
					<button
						className="btn-prev"
						id="Btn-Prev"
						onClick={changeToNextOrPrevMonth}
					>
						&lt;
					</button>
					<h2 id="month">{listOfAllTasks[MonthCalendar].month}</h2>
					<button
						className="btn-next"
						id="Btn-Next"
						onClick={changeToNextOrPrevMonth}
					>
						&gt;
					</button>
				</header>
				<table>
					<thead>
						<tr id="daysOfWeek">
							<td>D</td>
							<td>S</td>
							<td>T</td>
							<td>Q</td>
							<td>Q</td>
							<td>S</td>
							<td>S</td>
						</tr>
					</thead>
					<CalendarDays
						listOfAllTasks={listOfAllTasks}
						Month={MonthCalendar}
						Year={YearCalendar}
						selectedDay={selectedDayAndUpdateTaskList}
					/>
					<tfoot>
						<tr>
							<td colSpan={7} id="year">
								{Year}
							</td>
						</tr>
					</tfoot>
				</table>
			</div>
			<div id="toDoList">
				<Tasks
					listOfAllTasks={listOfAllTasks}
					updateListOfAllTasks={updateListOfAllTasks}
					addNewTaskLS={addNewTaskLS}
					switchCheckLS={switchCheckLS}
					updateTaskLS={updateTaskLS}
					deleteTaskLS={deleteTaskLS}
					MONTH={Month}
					YEAR={Year}
					day={Day}
				/>
			</div>
			<div id="shadow"></div>
		</div>
	);
}

export default App;
