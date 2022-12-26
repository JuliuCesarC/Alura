import React, { useState, useEffect } from "react";
import "./Tasks.css";
import "./mediaTasks.css";
import { IMonthsAndListOfTasks } from "../interfaces/IMonthsAndListOfTasks";
import { IListOfAllTasks } from "../interfaces/IListOfAllTasks";

interface TasksProps {
	listOfAllTasks: IMonthsAndListOfTasks[];
	addNewTaskLS: (month: number, year: number, day: number, TX: string) => void;
	switchCheckLS: (month: number, year: number, day: number, ID: string) => void;
	updateListOfAllTasks: () => void;
	updateTaskLS: (
		month: number,
		year: number,
		day: number,
		ID: string,
		TX: string
	) => void;
	deleteTaskLS: (month: number, year: number, day: number, ID: string) => void;
	DAY: number;
	MONTH: number;
	YEAR: number;
}

function Tasks({
	listOfAllTasks,
	addNewTaskLS,
	switchCheckLS,
	updateListOfAllTasks,
	updateTaskLS,
	deleteTaskLS,
	DAY,
	MONTH,
	YEAR,
}: TasksProps) {
	const [listOfTasksToDisplay, setListOfTasksToDisplay] = useState<
		JSX.Element[]
	>([]);
	const [taskListInEditMode, setTaskListInEditMode] = useState<JSX.Element[]>(
		[]
	);

	let day = DAY;
	let month = MONTH;
	let year = YEAR;
	let content: JSX.Element[] = [];

	listOfAllTasks[month].listOfAllTasks
		? showTasks(listOfAllTasks[month].listOfAllTasks!)
		: null;
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
			
			let contentTx = React.createElement(
				"div",
				{
					className: "content",
					key: randomID(),
				},
				tasks.cont
			);
			let edit = React.createElement(
				"div",
				{ className: "edit", key: randomID() },
				React.createElement("img", {
					src: "img/editBtn.png",
					onClick: (e) =>
						openEditMenu(e.target.parentNode.parentNode, tasks.id),
				})
			);
			let line = React.createElement(
				"div",
				{ key: tasks.id, className: "line" },
				[working, contentTx, edit]
			);
			content.push(line);
		}
	}
	// ----- // ------ //
	useEffect(() => {
		setListOfTasksToDisplay(content);
		setShowMonthYear([props.ls()[0] + 1, props.ls()[1]]);
	}, [day]);
	// ----- // ------ //
	function openEditMenu(eEdit, ID) {
		let editTx = eEdit.children[1].innerHTML;

		let Delete = React.createElement(
			"div",
			{ className: "delete", key: randomID() },
			React.createElement("img", {
				src: "img/delete.png",
				onClick: () => deleteTask(ID),
			})
		);
		let editInput = React.createElement(
			"div",
			{ className: "content", key: randomID() },
			React.createElement("input", {
				type: "text",
				className: "editInput",
				defaultValue: editTx,
				maxLength: 79,
			})
		);
		let editBtn = React.createElement(
			"div",
			{ className: "edit", key: randomID() },
			React.createElement("img", {
				onClick: (e) => updateTask(e.target.parentNode.parentNode, ID),
				src: "img/editBtn.png",
			})
		);
		let editLine = React.createElement("div", { key: ID, className: "line" }, [
			Delete,
			editInput,
			editBtn,
		]);

		let indexTr = content.findIndex((e) => e.key == ID);
		content[indexTr] = editLine;
		setListOfTasksToDisplay(undefined);
		setTaskListInEditMode(content);
	}
	// ----- // ------ //
	function updateTask(eUpdate, ID) {
		let updateTx = eUpdate.children[1].children[0].value;

		props.update(month, year, day, ID, updateTx);
		content = [];
		showTasks(props.ls()[2][month].listOfAllTasks);
		setListOfTasksToDisplay(content);
		setTaskListInEditMode(undefined);
	}
	// ----- // ------ //
	function deleteTask(ID) {
		props.delete(month, year, day, ID);
		content = [];
		showTasks(props.ls()[2][month].listOfAllTasks);
		setListOfTasksToDisplay(content);
		setTaskListInEditMode(undefined);
		props.tAdd(undefined);
	}
	// ----- // ------ //
	function addNewTask(eAdd) {
		if (listOfTasksToDisplay.length > 14 || eAdd.value.trim() == "") {
			return;
		}
		props.add(month, year, day, eAdd.value);
		eAdd.value = "";
		eAdd.focus();
		content = [];
		showTasks(props.ls()[2][month].listOfAllTasks);
		setListOfTasksToDisplay(content);
		props.tAdd(listOfTasksToDisplay);
	}
	// ----- // ------ //
	function showMenu() {
		let Table = document.getElementById("Table");
		let Shadow = document.getElementById("shadow");
		Table.classList.add("show");
		Shadow.classList.add("show");
		Shadow.addEventListener("click", (e) => {
			Table.classList.remove("show");
			Shadow.classList.remove("show");
		});
	}
	function randomID() {
		return Math.random().toString(36).substring(2, 9);
	}

	return (
		<>
			<header>
				<div id="divTop">
					<div id="menuBtn">
						<img src="img/menuBtn.png" alt="Botão Menu" onClick={showMenu} />
					</div>
					<h3 id="Day">
						{day}/{month}/{year}
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
						onClick={(e) => addNewTask(e.target.parentNode.children[0])}
					>
						Add <img src="img/add.png" />
					</button>
				</div>
			</header>
			<div id="tasksTable">
				{listOfTasksToDisplay ? listOfTasksToDisplay : taskListInEditMode}
			</div>
		</>
	);
}

export default Tasks;
