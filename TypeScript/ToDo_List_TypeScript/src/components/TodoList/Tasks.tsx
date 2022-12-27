import React, { useState, useEffect } from "react";
import "./Tasks.css";
import "./mediaTasks.css";
import { IMonthsAndListOfTasks } from "../interfaces/IMonthsAndListOfTasks";
import { IListOfAllTasks, IListOfTasks } from "../interfaces/IListOfAllTasks";
import { getListOfAllTasksFromLS } from "../localStorage/LocalStorage";

interface TasksProps {
	listOfAllTasks: IMonthsAndListOfTasks[];
	updateListOfAllTasks: () => void;
	addNewTaskLS: (month: number, year: number, day: number, TX: string) => void;
	switchCheckLS: (month: number, year: number, day: number, ID: string) => void;
	updateTaskLS: (
		month: number,
		year: number,
		day: number,
		ID: string,
		TX: string
	) => void;
	deleteTaskLS: (month: number, year: number, day: number, ID: string) => void;
	month: number;
	year: number;
	day: number;
}

function Tasks({
	listOfAllTasks,
	updateListOfAllTasks,
	addNewTaskLS,
	switchCheckLS,
	updateTaskLS,
	deleteTaskLS,
	month,
	year,
	day,
}: TasksProps) {
	const [listOfTasksToDisplay, setListOfTasksToDisplay] = useState<
		JSX.Element[]
	>([]);
	const [listOfTasksEditMode, setListOfTasksEditMode] = useState<
		JSX.Element[] | undefined
	>(undefined);

	let allElements: JSX.Element[] = [];

	if (listOfAllTasks[month].listOfAllTasks) {
		showTasks(getListOfAllTasksFromLS()[month].listOfAllTasks!);
	}

	// -------------------- // -------------------- //
	function showTasks(LOfAT: IListOfAllTasks[]) {
		if (!LOfAT) {
			return;
		}
		let allTasksOfTheDay = LOfAT.filter(
			(e) => e.year == year && e.day == day
		)[0];
		if (!allTasksOfTheDay) {
			return;
		}

		for (let tasks of allTasksOfTheDay.tasks) {
			let working: JSX.Element = React.createElement("div", {
				className: `check ${tasks.check == "check" ? "checkPin" : ""}`,
				key: randomID(),
				onClick: (e: React.MouseEvent) => {
					switchCheckLS(month, year, day, tasks.id);
					if ((e.target as HTMLElement).classList.length > 1) {
						(e.target as HTMLElement).classList.remove("checkPin");
					} else {
						(e.target as HTMLElement).classList.add("checkPin");
					}
				},
			});

			let contentTx: JSX.Element = React.createElement(
				"div",
				{
					className: "content",
					key: randomID(),
				},
				tasks.cont
			);
			let edit: JSX.Element = React.createElement(
				"div",
				{ className: "edit", key: randomID() },
				React.createElement("img", {
					src: "img/editBtn.png",
					onClick: (e: React.MouseEvent) =>
						openEditMenu(
							tasks,
							(e.target as HTMLElement).parentNode!.parentNode!,
							tasks.id
						),
				})
			);
			let line: JSX.Element = React.createElement(
				"div",
				{ key: tasks.id, className: "line" },
				[working, contentTx, edit]
			);
			allElements.push(line);
		}
	}
	// -------------------- // -------------------- //
	useEffect(() => {
		setListOfTasksToDisplay(allElements);
	}, [day]);
	// -------------------- // -------------------- //
	function addNewTask(eAdd: Element | EventTarget) {
		if (
			listOfTasksToDisplay.length > 14 ||
			(eAdd as HTMLInputElement).value.trim() == ""
		) {
			return;
		}
		addNewTaskLS(month, year, day, (eAdd as HTMLInputElement).value);
		updateListOfAllTasks();
		(eAdd as HTMLInputElement).value = "";
		(eAdd as HTMLInputElement).focus();
		allElements = [];
		showTasks(getListOfAllTasksFromLS()[month].listOfAllTasks!);
		setListOfTasksToDisplay(allElements);
	}
	// -------------------- // -------------------- //
	function openEditMenu(tasks: IListOfTasks, eEdit: ParentNode, ID: string) {
		let editTx: string = eEdit.children[1].innerHTML;

		let Delete: JSX.Element = React.createElement(
			"div",
			{ className: "delete", key: randomID() },
			React.createElement("img", {
				src: "img/delete.png",
				onClick: () => deleteTask(ID),
			})
		);
		let editInput: JSX.Element = React.createElement(
			"div",
			{ className: "content", key: randomID() },
			React.createElement("input", {
				type: "text",
				className: "editInput",
				defaultValue: editTx,
				maxLength: 79,
			})
		);
		let editBtn: JSX.Element = React.createElement(
			"div",
			{ className: "edit", key: randomID() },
			React.createElement("img", {
				onClick: (e: React.MouseEvent) =>
					updateTask((e.target as HTMLElement).parentNode!.parentNode!, ID),
				src: "img/editBtn.png",
			})
		);
		let editLine: JSX.Element = React.createElement(
			"div",
			{ key: ID, className: "line" },
			[Delete, editInput, editBtn]
		);

		let lineIndex = allElements.findIndex((e) => e.key == ID);
		allElements[lineIndex] = editLine;
		setListOfTasksEditMode(allElements);
	}
	// -------------------- // -------------------- //
	function updateTask(eUpdate: ParentNode, ID: string) {
		let updateTx: string = (eUpdate.children[1].children[0] as HTMLInputElement)
			.value;

		updateTaskLS(month, year, day, ID, updateTx);
		allElements = [];
		showTasks(getListOfAllTasksFromLS()[month].listOfAllTasks!);
		setListOfTasksToDisplay(allElements);
		setListOfTasksEditMode(undefined);
	}
	// -------------------- // -------------------- //
	function deleteTask(ID: string) {
		deleteTaskLS(month, year, day, ID);

		let newAllElements = allElements.filter((e) => e.key != ID);
		setListOfTasksToDisplay(newAllElements);
	}
	// -------------------- // -------------------- //
	function showMenu() {
		let Table = document.getElementById("Calendar") as HTMLElement;
		let Shadow = document.getElementById("shadow") as HTMLElement;
		Table.classList.add("show");
		Shadow.classList.add("show");
		Shadow.addEventListener("click", (e) => {
			Table.classList.remove("show");
			Shadow.classList.remove("show");
		});
	}
	function randomID() {
		return Math.random().toString(36).substring(2, 12);
	}

	return (
		<div id="toDoList">
			<header>
				<div id="divTop">
					<div id="menuBtn">
						<img src="img/menuBtn.png" alt="Botão Menu" onClick={showMenu} />
					</div>
					<h3 id="Day">
						{day}/{month + 1}/{year}
					</h3>
					<h1>ToDo List</h1>
				</div>
				<div id="divInput">
					<input
						type="text"
						id="addTask"
						placeholder="Nova tarefa..."
						maxLength={79}
						autoComplete="off"
						onKeyUp={(e) => {
							let key = e.key;
							if (key == "Enter") {
								addNewTask(e.target);
							}
						}}
					/>
					<button
						id="AddBtn"
						onClick={(e) =>
							addNewTask((e.target as HTMLElement).parentNode!.children[0])
						}
					>
						Add <img src="img/add.png" />
					</button>
				</div>
			</header>
			<div id="tasksTable">
				{listOfTasksEditMode ? listOfTasksEditMode : listOfTasksToDisplay}
			</div>
		</div>
	);
}

export default Tasks;
