import React, { useState, useEffect } from "react";
import './TodoList.css';
import TodoItem from './TodoItem';

/**
 * Todo component represents the main TODO list application.
 * It allows users to add new tasks, delete tasks, and move tasks up or down in the list.
 * The component maintains the state of the task list and the new task input.
 */
function TodoList() {
    // Define state to store data and loading state
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    // Define the API URL
    const apiUrl = "http://localhost:5299/api/ToDo/GetAll?UserID=1";

    useEffect(() => {
        // Create a function to fetch the data
        const fetchData = async () => {
            try {
                const response = await fetch(apiUrl);
                if (!response.ok) {
                    throw new Error("Network response was not ok");
                }
                const result = await response.json();
                setData(result);  // Assuming result has the form { toDos: [...] }
            } catch (error) {
                setError(error.message);
            } finally {
                setLoading(false);
            }
        };

        // Call the fetchData function
        fetchData();
    }, []); // Empty dependency array means this effect runs once when the component mounts

    const [tasks, setTasks] = useState([]);

    useEffect(() => {
        if (data && data.toDos) {
            setTasks(data.toDos);  // Set tasks from the toDos property in the API response
        }
    }, [data]);

    const [newTaskText, setNewTaskText] = useState('');

    function handleInputChange(event) {
        setNewTaskText(event.target.value);
    }

    //function addTask(event) {
    //    if (newTaskText.trim()) {
    //        setTasks(t => [...t, { id: self.crypto.randomUUID(), text: newTaskText }]);
    //        setNewTaskText('');
    //    }
    //    event.preventDefault();
    //}

    // Function to add a task
    async function addTask(event) {
        if (newTaskText.trim()) {
            const newTask = { title: newTaskText, createdBy: "1" };

            // Step 1: Send POST request to add the task to the server
            try {
                const response = await fetch("http://localhost:5299/api/ToDo", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(newTask),
                });

                if (!response.ok) {
                    throw new Error("Failed to add task");
                }

                // Step 2: If the request is successful, update the tasks list locally
                const result = await response.json();
                setTasks((prevTasks) => [...prevTasks, result]);  // Assuming API returns the added task
                setNewTaskText('');  // Clear input field
            } catch (error) {
                setError(error.message);
            }
        }
        event.preventDefault();
    }

    async function deleteTask(id) {

        let deleteApiUrl = "http://localhost:5299/api/ToDo?userId=1&toDoId=" + id;

        // Step 1: Send POST request to add the task to the server
        try {
            const response = await fetch(deleteApiUrl, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json"
                }
            });

            if (!response.ok) {
                throw new Error("Failed to delete task");
            }

            // Step 2: If the request is successful, update the tasks list locally
            const result = await response.json();
            if (result.responseCode == 100) {
                const updatedTasks = tasks.filter(task => task.id !== id);
                setTasks(updatedTasks);
            }
        } catch (error) {
            setError(error.message);
        }
    }

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <article className="todo-list" aria-label="task list manager">
            <header>
                <h1>CY's TODO</h1>
                <form className="todo-input" onSubmit={addTask} aria-controls="todo-list">
                    <input
                        type="text"
                        required
                        autoFocus
                        placeholder="Enter a task"
                        value={newTaskText}
                        aria-label="Task text"
                        onChange={handleInputChange}
                    />
                    <button className="add-button" aria-label="Add task">
                        Add
                    </button>
                </form>
            </header>
            <ol id="todo-list" aria-live="polite" aria-label="task list">
                {tasks.map((task) => (
                    <TodoItem
                        key={task.id}
                        task={task.title}  // Display the task text
                        deleteTaskCallback={() => deleteTask(task.id)}
                    />
                ))}
            </ol>
        </article>
    );
}

export default TodoList;