import React, { useEffect, useState } from "react";
import { IMonthsAndListOfTasks } from "../../interfaces/IMonthsAndListOfTasks";
import { selectedDayLS } from "../../localStorage/LocalStorage";

let once: boolean = true;

interface DaysProps {
	listOfAllTasks: IMonthsAndListOfTasks[];
	Month: number;
	Year: number;
	selectedDay: (parameter: number) => void;
	firstOpenCalendar: () => void
}

function CalendarDays({ listOfAllTasks, Month, Year, selectedDay, firstOpenCalendar }: DaysProps) {
	const [calendarWeeks, setCalendarWeeks] = useState<JSX.Element[]>([]);

	let allTDs: JSX.Element[] = [];
	let allTRs: JSX.Element[] = [];

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
			let TD: JSX.Element;

			const indexDateIsTheCurrentDay: boolean =
				indexDate.getFullYear() == Now.getFullYear() &&
				indexDate.getMonth() == Now.getMonth() &&
				indexDate.getDate() == Now.getDate();
			const thereAreTasksInThisMonth: boolean =
				listOfAllTasks[Month].listOfAllTasks != undefined;
			const dayBelongsToTheNextMonthOrThePreviousMonth: boolean =
				all42CalendarDays < 1 || all42CalendarDays > totalDaysInMonth;
			const endOfTheWeekOrEndOfTheMonth: boolean =
				index % 7 === 0 && index <= 42;

			if (indexDateIsTheCurrentDay) {
				tdID = "currentDay";
			}
			if (thereAreTasksInThisMonth) {
				const thereAreTasksOnThisDay =
					listOfAllTasks[Month].listOfAllTasks!.filter(
						(e) => e.year == Year && e.day == indexDate.getDate()
					).length >= 1;

				if (thereAreTasksOnThisDay) {
					tdClass = "task";
				}
			}
			if (dayBelongsToTheNextMonthOrThePreviousMonth) {
				tdClass = "prevNextMonth";
				TD = (
					<td id={tdID} key={index} className={tdClass}>
						{calendarDay}
					</td>
				);
			} else {
				TD = (
					<td
						id={tdID}
						key={index}
						className={tdClass}
						onClick={(e) =>
							selectedDay(Number((e.target as HTMLElement).innerHTML))
						}
					>
						{calendarDay}
					</td>
				);
			}
			allTDs.push(TD);

			if (endOfTheWeekOrEndOfTheMonth) {
				let TR: JSX.Element = React.createElement("tr", { key: index }, allTDs);
				allTDs = [];
				allTRs.push(TR);
			}
		}
	}

	useEffect(() => {
		allTRs = [];
		createCalendarDays();
		setCalendarWeeks(allTRs);
	}, [Month, listOfAllTasks]);

	useEffect(()=>{
		if (once) {
			once = false;
			selectedDayLS(
				new Date().getMonth(),
				new Date().getFullYear(),
				new Date().getDate()
			);
			firstOpenCalendar()
		}
	},[])
	return <tbody id="days">{calendarWeeks}</tbody>;
}

export default CalendarDays;
