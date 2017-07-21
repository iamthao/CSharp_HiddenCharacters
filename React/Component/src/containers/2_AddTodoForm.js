/**
 * Created by Thao Nguyen on 07/21/2017.
 */
import React from 'react';
import {connect} from 'react-redux'
import {addTodo} from '../actions/action_Todo2'


let AddTodoForm = ({dispatch}) => {
    let input;
    return (
        <div >
            <input type="text" placeholder="Todo..."  ref={node => {
                input = node
            }}/>
            {' '}

            <button onClick={e => {
                e.preventDefault()
                if (!input.value.trim()) {
                    return
                }
                dispatch(addTodo(input.value))
                input.value = ''
            }}>
                Add Todo
            </button>
        </div>
    )
}
AddTodoForm = connect()(AddTodoForm)

export default AddTodoForm;