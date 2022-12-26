import React, { ReactHTMLElement, useEffect, useState } from "react";
import { IMonthsAndListOfTasks } from "../interfaces/IMonthsAndListOfTasks";
import "./Days.css";
import "./mediaDays.css";
let crrDay: string;

interface DaysProps {
	listOfAllTasks: IMonthsAndListOfTasks[];
	Month: number;
	Year: number;
	selectedDay: () => void;
}

interface ReactElements {
	id: string;
	key: string;
	className: string;
	onClick?: (e: React.MouseEvent<HTMLElement, MouseEvent>) => void;
}

function Days({ listOfAllTasks, Month, Year, selectedDay }: DaysProps) {
	const [trState, setTrState] = useState([]);

	let allTDs: React.DetailedReactHTMLElement<ReactElements, HTMLElement>[] = [];
	let allTRs: React.DetailedReactHTMLElement<ReactElements, HTMLElement>[] = [];

	function createCalendarDays() {
		let fistDayOfWeek: number = new Date(Year, Month, 1).getDay() - 1;
		let totalDaysInMonth: number = new Date(Year, Month + 1, 0).getDate();
		let all42CalendarDays: number = -fistDayOfWeek;

		for (let index = 1; index <= 42; index++, all42CalendarDays++) {
			let indexDate: Date = new Date(Year, Month, all42CalendarDays);
			let Now: Date = new Date();

			let calendarDay: number = indexDate.getDate();
			let tdID: string = "";
			let tdClass: string = "";

			const isTheIndexDayTheCurrentDay: boolean =
				indexDate.getFullYear() == Now.getFullYear() &&
				indexDate.getMonth() == Now.getMonth() &&
				indexDate.getDate() == Now.getDate();

			if (isTheIndexDayTheCurrentDay) {
				tdID = "currentDay";
			}
			if (all42CalendarDays < 1 || all42CalendarDays > totalDaysInMonth) {
				tdClass = "prevNextMonth";
			}
			if (
				MONTHS[month].listOfAllTasks &&
				MONTHS[month].listOfAllTasks.filter(
					(e) => e.year == year && e.day == indexDate.getDate()
				).length >= 1 &&
				tdClass == ""
			) {
				//Checks if the selected day has tasks.
				tdClass = "task";
			}
			let TD;
			if (tdClass == "" || tdClass == "task") {
				//Ensures that the day of the previous or next month cannot be selected.
				TD = React.createElement(
					"td",
					{
						id: tdID,
						key: index,
						className: tdClass,
						onClick: (e) => selectedDay(e.target.innerHTML),
					},
					calendarDay
				);
			} else {
				TD = React.createElement(
					"td",
					{ id: tdID, key: index, className: tdClass },
					calendarDay
				);
			}
			allTDs.push(TD);

			if (index % 7 === 0 && index <= 42) {
				//Every week a new line with the TDs is created.
				let TR = React.createElement("tr", { key: index }, allTDs);
				allTDs = [];
				allTRs.push(TR);
			}
		}
	}

	useEffect(() => {
		allTRs = [];
		createCalendarDays();
		setTrState(allTRs);
	}, [month, upClassTask]);

	if (once) {
		//The first time the site is opened, the current day is selected.
		once = false;
		setTimeout(() => {
			selectedDay(new Date().getMonth(), crrDay);
		}, 1);
	}

	return <tbody id="days">{trState}</tbody>;
}

export default Days;
