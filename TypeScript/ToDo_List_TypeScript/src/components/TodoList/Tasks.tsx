import React, { useState, useEffect } from "react";
import "./Tasks.css";
import "./mediaTasks.css";
import { IMonthsAndListOfTasks } from "../interfaces/IMonthsAndListOfTasks";
import { IListOfAllTasks, IListOfTasks } from "../interfaces/IListOfAllTasks";

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
	MONTH: number;
	YEAR: number;
	day: number;
}

function Tasks({
	listOfAllTasks,
	addNewTaskLS,
	switchCheckLS,
	updateListOfAllTasks,
	updateTaskLS,
	deleteTaskLS,
	MONTH,
	YEAR,
	day,
}: TasksProps) {
	const [listOfTasksToDisplay, setListOfTasksToDisplay] = useState<
		JSX.Element[]
	>([]);

	let month = MONTH
	let year = YEAR
	let allElements: JSX.Element[] = [];

	if(listOfAllTasks[month].listOfAllTasks){
		showTasks(listOfAllTasks[month].listOfAllTasks!)
	}
	// ----- // ------ //
	function showTasks(LOfAT: IListOfAllTasks[]) {
		let allTasksOfTheDay = LOfAT.filter(
			(e) => e.year == year && e.day == day
		)[0];

		for (let tasks of allTasksOfTheDay.tasks) {
			const taskCompleted =
				allTasksOfTheDay.tasks.filter((e) => e.id == tasks.id)[0].check ==
				"check";

			let working: JSX.Element = React.createElement("div", {
				className: `check ${tasks.check == "check" ? "checkPin" : ""}`,
				key: randomID(),
				onClick: (e: React.MouseEvent) => {
					switchCheckLS(month, year, day, tasks.id);
					if (taskCompleted) {
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
					updateTask(
						tasks,
						(e.target as HTMLElement).parentNode!.parentNode!,
						ID
					),
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
		setListOfTasksToDisplay(allElements);
	}
	// -------------------- // -------------------- //
	function updateTask(tasks: IListOfTasks, eUpdate: ParentNode, ID: string) {
		let updateTx: string = (eUpdate.children[1].children[0] as HTMLInputElement)
			.value;
		let allTasksOfTheDay = listOfAllTasks[month].listOfAllTasks!.filter(
			(e) => e.year == year && e.day == day
		)[0];

		let working: JSX.Element = React.createElement("div", {
			className: `check ${tasks.check == "check" ? "checkPin" : ""}`,
			key: randomID(),
			onClick: (e: React.MouseEvent) => {
				switchCheckLS(month, year, day, tasks.id);
				if (
					allTasksOfTheDay.tasks.filter((e) => e.id == tasks.id)[0].check ==
					"check"
				) {
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
		let updateLine: JSX.Element = React.createElement(
			"div",
			{ key: tasks.id, className: "line" },
			[working, contentTx, edit]
		);

		updateTaskLS(month, year, day, ID, updateTx);
		let lineIndex: number = allElements.findIndex((e) => e.key == ID);
		allElements[lineIndex] = updateLine;
		setListOfTasksToDisplay(allElements);
	}
	// -------------------- // -------------------- //
	function deleteTask(ID: string) {
		deleteTaskLS(month, year, day, ID);

		let newAllElements = allElements.filter((e) => e.key != ID);
		setListOfTasksToDisplay(newAllElements);
	}
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
		showTasks(listOfAllTasks[month].listOfAllTasks!);
		setListOfTasksToDisplay(allElements);
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
		<>
			<header>
				<div id="divTop">
					<div id="menuBtn">
						<img src="img/menuBtn.png" alt="Botão Menu" onClick={showMenu} />
					</div>
					<h3 id="Day">
						{day}/{month+1}/{year}
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
				{listOfTasksToDisplay}
			</div>
		</>
	);
}

export default Tasks;
