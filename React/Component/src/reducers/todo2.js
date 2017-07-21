/**
 * Created by Thao Nguyen on 07/21/2017.
 */
const todoApp2 = (state = [], action) => {
    switch (action.type) {
        case '2_ADD_TODO':
            return [
                ...state,
                {
                    id: action.id,
                    message: action.message,
                    completed: false
                }
            ]

        case '2_COMPLETE_TODO':
            return state.map(a =>
                (a.id === action.id)
                    ? {...a, completed: !a.completed}
                    : a
            )

        case '2_DELETE_TODO':
             let items = state, data;
             return items.filter( el=> {
                 return el.id != action.id;
             })

        default:
            return state;
    }
}

export default todoApp2;