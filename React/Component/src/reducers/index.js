/**
 * Created by Thao Nguyen on 07/20/2017.
 */
import { combineReducers } from 'redux'
import todos from './todos'
import visibilityFilter from './visibilityFilter'
import todoApp2 from './todo2'

const rootReducer = combineReducers({
    todos,
    visibilityFilter,
    todoApp2
})
export default rootReducer;