import { useState } from "react";
import "./Home.css";
import "./mediaHome.css";
import Days from "../../components/calendar/Days";
import Tasks from "../../components/TodoList/Tasks";
import {
	LocalS,
	prevNextMonth,
	selectedDay,
	addNewTaskLS,
	updateTaskLS,
	switchCheckLS,
	deleteTaskLS,
} from "../../components/localStorage/LocalStorage";

function App() {
	const [LS, setLS] = useState(LocalS());
	const [Month, setMonth] = useState(LS[2][LS[0]].month);
	const [Year, setYear] = useState(LS[1]);
	const [taskDay, setTaskDay] = useState([LS[3], Year, LS[0]]);
	const [updateTaskClass, setUpdateTaskClass] = useState([])

	function PrevNext(e) {
		prevNextMonth(e);
		setLS(LocalS());
		setMonth(LS[2][LocalS()[0]].month);
		setYear(LocalS()[1]);
	}

	function updateDay(month, eDay) {
		selectedDay(month, Year, eDay);
		setLS(LocalS())
		setTaskDay([LocalS()[3], Year, month]);
	}
	function updateAdd(e){
		setUpdateTaskClass(e)
	}
	return (
		<div className="container">
			<div id="Table">
				<header id="Header">
					<button className="btn-prev" id="Btn-Prev" onClick={PrevNext}>
						&lt;
					</button>
					<h2 id="month">{Month}</h2>
					<button className="btn-next" id="Btn-Next" onClick={PrevNext}>
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
					<Days ls={LocalS} selectedDay={updateDay} upClass={updateTaskClass} />
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
				<Tasks ls={LocalS} taskDay={taskDay} add={addNewTaskLS} Switch={switchCheckLS} tAdd={updateAdd} update={updateTaskLS} delete={deleteTaskLS} />
			</div>
			<div id="shadow"></div>
		</div>
	);
}

export default App;
