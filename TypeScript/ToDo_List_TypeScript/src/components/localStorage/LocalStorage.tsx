import { IListOfAllTasks, IListOfTasks } from "../interfaces/IListOfAllTasks";
import { IMonthsAndListOfTasks } from "../interfaces/IMonthsAndListOfTasks";

const keyLS = "ToDoList";
const keyCurrent = "currentMYD";

interface ICurrent {
	month: number;
	year: number;
	day: number;
}
// ------------------------- // -------------------------
function GetLS(Key: string) {
	return localStorage.getItem(Key);
}
function SetLS(Key: string, months: IMonthsAndListOfTasks[] | ICurrent) {
	localStorage.setItem(Key, JSON.stringify(months));
}
function isThereContentSavedInLS(key: string): boolean {
	return GetLS(key) ? true : false;
}
// ------------------------- // -------------------------
export function getListOfAllTasksFromLS(): IMonthsAndListOfTasks[] {
	const months: IMonthsAndListOfTasks[] = [
		{ month: "janeiro" },
		{ month: "fevereiro" },
		{ month: "março" },
		{ month: "abril" },
		{ month: "maio" },
		{ month: "junho" },
		{ month: "julho" },
		{ month: "agosto" },
		{ month: "setembro" },
		{ month: "outubro" },
		{ month: "novembro" },
		{ month: "dezembro" },
	];

	if (!isThereContentSavedInLS(keyLS)) {
		SetLS(keyLS, months);
	} else {
		months.forEach((e, i) => {
			let LS = localStorage.getItem("ToDoList");
			if (LS) {
				months[i] = JSON.parse(LS)[i];
			}
		});
	}
	return months;
}
// ------------------------- // -------------------------
export function getMonthYear(): number[] {
	let currentMYD: ICurrent = {
		month: new Date().getMonth(),
		year: new Date().getFullYear(),
		day: new Date().getDate(),
	};
	if (isThereContentSavedInLS(keyCurrent)) {
		let LSC = GetLS(keyCurrent);
		if (LSC) {
			currentMYD = JSON.parse(LSC);
		}
	}
	SetLS(keyCurrent, currentMYD);
	return [currentMYD.month, currentMYD.year];
}
// ------------------------- // -------------------------
export function getDayMonthYearSelected(): number[] {
	let currentMYD: ICurrent = {
		month: new Date().getMonth(),
		year: new Date().getFullYear(),
		day: new Date().getDate(),
	};
	if (isThereContentSavedInLS(keyCurrent)) {
		let LSC = GetLS(keyCurrent);
		if (LSC) {
			currentMYD = JSON.parse(LSC);
		}
	}
	SetLS(keyCurrent, currentMYD);
	return [currentMYD.day, currentMYD.month, currentMYD.year];
}
// ------------------------- // -------------------------
export function prevNextMonth(
	ePrevNext: React.MouseEvent<HTMLButtonElement, MouseEvent>
): void {
	let LSC = GetLS(keyCurrent);
	if (!LSC) {
		return;
	}
	let crrMonthYear: ICurrent = JSON.parse(LSC);
	const isTheNextButton: boolean =
		(ePrevNext.target as HTMLButtonElement).className == "btn-next";
	const isItDecember: boolean = crrMonthYear.month == 11;
	const isItJanuary: boolean = crrMonthYear.month == 0;

	if (isTheNextButton) {
		if (isItDecember) {
			crrMonthYear.month = 0;
			crrMonthYear.year += 1;
		} else {
			crrMonthYear.month += 1;
		}
		SetLS(keyCurrent, crrMonthYear);
	} else {
		if (isItJanuary) {
			crrMonthYear.month = 11;
			crrMonthYear.year -= 1;
		} else {
			crrMonthYear.month -= 1;
		}
		SetLS(keyCurrent, crrMonthYear);
	}
}
// ------------------------- // -------------------------
export function selectedDayLS(month: number, year: number, day: number): void {
	let LSC = GetLS(keyCurrent);
	if (!LSC) {
		return;
	}
	let crrMYD = JSON.parse(LSC);
	crrMYD.month = month;
	crrMYD.year = year;
	crrMYD.day = day;
	SetLS(keyCurrent, crrMYD);
}
// ------------------------- // -------------------------
export function addNewTaskLS(
	month: number,
	year: number,
	day: number,
	TX: string
) {
	let LS = GetLS(keyLS);
	if (!LS) {
		return;
	}
	let fullLS = JSON.parse(LS);
	let LSMonth: IMonthsAndListOfTasks = fullLS[month];
	let newTask: IListOfAllTasks = {
		year: year,
		day: day,
		tasks: [],
	};

	const isItTheFirstTaskOfTheMonth: boolean = !LSMonth.listOfAllTasks;

	if (isItTheFirstTaskOfTheMonth) {
		LSMonth.listOfAllTasks = [];
	}
	const areThereTasksOnTheSameDay: boolean =
		LSMonth.listOfAllTasks!.filter(
			(e: IListOfAllTasks) => e.year == year && e.day == day
		).length > 0;

	if (areThereTasksOnTheSameDay) {
		newTask = LSMonth.listOfAllTasks!.filter(
			(e: IListOfAllTasks) => e.year == year && e.day == day
		)[0];
		newTask.tasks.push({ id: randomID(), cont: TX, check: "working" });
	} else {
		newTask.tasks.push({ id: randomID(), cont: TX, check: "working" });
		LSMonth.listOfAllTasks!.push(newTask);
	}
	SetLS(keyLS, fullLS);
}
// ------------------------- // -------------------------
export function updateTaskLS(
	month: number,
	year: number,
	day: number,
	ID: string,
	TX: string
) {
	let LS = GetLS(keyLS);
	if (!LS) {
		return;
	}
	let fullLS = JSON.parse(LS);
	let LSMonth = fullLS[month].listOfAllTasks;
	let LSDay = LSMonth.filter(
		(e: IListOfAllTasks) => e.year == year && e.day == day
	)[0].tasks;
	let LSTask = LSDay.filter((e: IListOfTasks) => e.id == ID)[0];
	LSTask.cont = TX;

	SetLS(keyLS, fullLS);
}
// ------------------------- // -------------------------
export function switchCheckLS(
	month: number,
	year: number,
	day: number,
	ID: string
) {
	let LS = GetLS(keyLS);
	if (!LS) {
		return;
	}
	let fullLS = JSON.parse(LS);
	let task = fullLS[month].listOfAllTasks
		.filter((e: IListOfAllTasks) => e.year == year && e.day == day)[0]
		.tasks.filter((e: IListOfTasks) => e.id == ID)[0];
	const taskCompleted: boolean = task.check == "working";

	if (taskCompleted) {
		task.check = "check";
	} else {
		task.check = "working";
	}

	SetLS(keyLS, fullLS);
}
// ------------------------- // -------------------------
export function deleteTaskLS(
	month: number,
	year: number,
	day: number,
	ID: string
) {
	let LS = GetLS(keyLS);
	if (!LS) {
		return;
	}
	let fullLS = JSON.parse(LS);
	let fullLSWithoutDelTask = fullLS[month].listOfAllTasks
		.filter((e: IListOfAllTasks) => e.year == year && e.day == day)[0]
		.tasks.filter((e: IListOfTasks) => e.id != ID);

	fullLS[month].listOfAllTasks.filter(
		(e: IListOfAllTasks) => e.year == year && e.day == day
	)[0].tasks = fullLSWithoutDelTask;

	const isTheLastTaskOfTheDay: Boolean =
		fullLS[month].listOfAllTasks.filter(
			(e: IListOfAllTasks) => e.year == year && e.day == day
		)[0].tasks.length < 1;

	if (isTheLastTaskOfTheDay) {
		let removingDayFromHistory = fullLS[month].listOfAllTasks.filter(
			(e: IListOfAllTasks) => e.year != year || e.day != day
		);
		fullLS[month].listOfAllTasks = removingDayFromHistory;
	}
	localStorage.setItem("ToDoList", JSON.stringify(fullLS));
}
// ------------------------- // -------------------------
function randomID() {
	return Math.random().toString(36).substring(2, 12);
}
