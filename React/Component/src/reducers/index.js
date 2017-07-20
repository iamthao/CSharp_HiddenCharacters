/**
 * Created by Thao Nguyen on 07/20/2017.
 */
import { combineReducers } from 'redux'
import todos from './todos'
import visibilityFilter from './visibilityFilter'

const rootReducer = combineReducers({
    todos,
    visibilityFilter
})

export default rootReducer;