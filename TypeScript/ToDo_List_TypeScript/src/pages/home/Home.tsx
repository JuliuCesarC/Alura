import { useState } from "react";
import "./Home.css";
import "./mediaHome.css";
import Days from "../../components/calendar/Days";
import Tasks from "../../components/TodoList/Tasks";
import {
	getListOfAllTasksFromLS,
	getMonthYear,
	getDayMonthYearSelected,
	prevNextMonth,
	selectedDay,
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
	// const [updateTaskClass, setUpdateTaskClass] = useState([]);

	function changeToNextOrPrevMonth(
		ePrevNext: React.MouseEvent<HTMLButtonElement, MouseEvent>
	): void {
		prevNextMonth(ePrevNext);
		setMonth(getMonthYear()[0]);
		setYear(getMonthYear()[1]);
	}

	function selectedDayAndUpdateTaskList(eDay: number): void {
		selectedDay(Month, Year, eDay);
		setDay(getDayMonthYearSelected()[0]);
		setMonth(getDayMonthYearSelected()[1]);
		setYear(getDayMonthYearSelected()[2]);
	}
	function updateListOfAllTasks(eAdd: IMonthsAndListOfTasks[]): void {
		setListOfAllTasks(eAdd);
	}
	return (
		<div className="container">
			<div id="Table">
				<header id="Header">
					<button
						className="btn-prev"
						id="Btn-Prev"
						onClick={changeToNextOrPrevMonth}
					>
						&lt;
					</button>
					<h2 id="month">{Month}</h2>
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
					<Days
						listOfAllTasks={listOfAllTasks}
						Month={Month}
						Year={Year}
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
					ls={LocalS}
					taskDay={taskDay}
					add={addNewTaskLS}
					Switch={switchCheckLS}
					tAdd={updateAdd}
					update={updateTaskLS}
					delete={deleteTaskLS}
				/>
			</div>
			<div id="shadow"></div>
		</div>
	);
}

export default App;
