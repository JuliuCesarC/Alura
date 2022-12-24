import React, { ReactHTMLElement, useEffect, useState } from "react";
import { IAllTasks } from "../interfaces/IAllTasks";
import "./Days.css";
import "./mediaDays.css";
let once = true;
let crrDay: string;

interface DaysProps{
	ls: () => IAllTasks[],
	selectedDay: string,
	upClass: IAllTasks[]
}

function Days({ls, selectedDay, upClass}: DaysProps) {
	const [trState, setTrState] = useState([]);

	let month = ls()[0];
	let year = ls()[1];
	let MONTHS = ls()[2];
	let upClassTask = upClass;
	let allTDs = [];
	let allTRs = [];

	function createDays() {
		allTDs = [];
		allTRs = [];
		month = ls()[0];
		year = ls()[1];
		MONTHS = ls()[2];

		let fistDayOfWeek = new Date(year, month, 1).getDay() - 1;
		let totalDaysInMonth = new Date(year, month + 1, 0).getDate();
		let fullMonth = -fistDayOfWeek;

		for (let index = 1; index <= 42; index++, fullMonth++) {
			let indexDate = new Date(year, month, fullMonth);
			let Now = new Date();

			let tdInnerHTML = indexDate.getDate();
			let tdID = "";
			let tdClass = "";

			if (
				indexDate.getFullYear() == Now.getFullYear() &&
				indexDate.getMonth() == Now.getMonth() &&
				indexDate.getDate() == Now.getDate()
			) {
				//Checks if the day is the current day.
				tdID = "currentDay";
				crrDay = indexDate.getDate().toString();
			}
			if (fullMonth < 1 || fullMonth > totalDaysInMonth) {
				//Whether the day belongs to the last month or the next month
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
						onClick: (e) => selectedDay(month, e.target.innerHTML),
					},
					tdInnerHTML
				);
			} else {
				TD = React.createElement(
					"td",
					{ id: tdID, key: index, className: tdClass },
					tdInnerHTML
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
		createDays();
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
