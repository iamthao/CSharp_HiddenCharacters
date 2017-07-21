/**
 * Created by Thao Nguyen on 07/20/2017.
 */
const todos = (state = [], action) => {
    switch (action.type) {
        case 'ADD_TODO':
            return [
                ...state,
                {
                    id: action.id,
                    text: action.text,
                    completed: false
                }
            ]
        case 'TOGGLE_TODO':
            return state.map(a =>
                (a.id === action.id)
                    ? {...a, completed: !a.completed}
                    : a
            )
        default:
            return state
    }
}

export default todos;