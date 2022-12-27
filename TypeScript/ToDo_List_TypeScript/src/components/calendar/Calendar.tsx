import { useState } from "react";
import { IMonthsAndListOfTasks } from "../interfaces/IMonthsAndListOfTasks";
import {
	getDayMonthYearSelected,
	getMonthYear,
	prevNextMonth,
} from "../localStorage/LocalStorage";
import CalendarDays from "./components/CalendarDays";
import "./Days.css";
import "./mediaDays.css";

interface CalendarProps {
	listOfAllTasks: IMonthsAndListOfTasks[];
	selectedDayAndUpdateTaskList: (
		month: number,
		year: number,
		eDay: number
	) => void;
}

export default function Calendar({
	listOfAllTasks,
	selectedDayAndUpdateTaskList,
}: CalendarProps) {
	const [MonthCalendar, setMonthCalendar] = useState<number>(
		getDayMonthYearSelected()[1]
	);
	const [YearCalendar, setYearCalendar] = useState<number>(
		getDayMonthYearSelected()[2]
	);

	function changeToNextOrPrevMonth(
		ePrevNext: React.MouseEvent<HTMLButtonElement, MouseEvent>
	): void {
		prevNextMonth(ePrevNext);
		setMonthCalendar(getMonthYear()[0]);
		setYearCalendar(getMonthYear()[1]);
	}

	function selectedDay(eDay: number) {
		selectedDayAndUpdateTaskList(MonthCalendar, YearCalendar, eDay);
	}

	function firstOpenCalendar(): void {
		setMonthCalendar(getMonthYear()[0]);
		setYearCalendar(getMonthYear()[1]);
	}
	return (
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
					selectedDay={selectedDay}
					firstOpenCalendar={firstOpenCalendar}
				/>
				<tfoot>
					<tr>
						<td colSpan={7} id="year">
							{YearCalendar}
						</td>
					</tr>
				</tfoot>
			</table>
		</div>
	);
}
