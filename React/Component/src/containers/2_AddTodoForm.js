/**
 * Created by Thao Nguyen on 07/21/2017.
 */
import React from 'react';
import {connect} from 'react-redux'
import {addTodo} from '../actions/action_Todo2'

import {FormControl,Col,FormGroup,Button} from 'react-bootstrap'


let AddTodoForm = ({dispatch}) => {
    let input;
    return (
        <div >
            <Col xs={8} md={8}><FormControl type="text" placeholder="Todo..."  ref={node => {
                input = node
            }}/></Col>
            {' '}

            <Button onClick={e => {
                e.preventDefault()
                if (!input.value.trim()) {
                    return
                }
                dispatch(addTodo(input.value))
                input.value = ''
            }}>
                Add Todo
            </Button>
        </div>
    )
}
AddTodoForm = connect()(AddTodoForm)

export default AddTodoForm;