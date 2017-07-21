/**
 * Created by Thao Nguyen on 07/21/2017.
 */
import { connect } from 'react-redux'
import ListToDo from './2_ListTodo'
import { completeTodo,deleteTodo } from '../actions/action_Todo2'

const mapStateToProps2 = state => {
    return  {todoApp2: state.todoApp2};
}

const mapDispatchToProps2 = dispatch => {
    return {
        todo2Click: id => {
            dispatch(completeTodo(id))
        },
        removeItem : id =>{
            dispatch(deleteTodo(id))
        }
    }
}


const MapValueForToDo2 = connect(
    mapStateToProps2,mapDispatchToProps2
)(ListToDo)

export default MapValueForToDo2