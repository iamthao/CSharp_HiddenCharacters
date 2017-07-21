/**
 * Created by Thao Nguyen on 07/21/2017.
 */
let nextTodoId = 0
const addTodo = (message) => {
    return {
        type: '2_ADD_TODO',
        message: message,
        id: nextTodoId++
    };
}

const  completeTodo = (id) =>  {
    return {
        type: '2_COMPLETE_TODO',
        id: id
    };
}

function deleteTodo(id) {
    return {
        type: '2_DELETE_TODO',
        id: id
    };
}

function clearTodo() {
    return {
        type: '2_CLEAR_TODO'
    };
}

export {addTodo, deleteTodo, completeTodo, clearTodo}