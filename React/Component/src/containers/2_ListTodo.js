import React from 'react'
import PropTypes from 'prop-types'

const ListToDo = ({todoApp2, todo2Click, removeItem}) => {
    return (
        <ul>
            {todoApp2.map(todo => (
                <li key={todo.id}>
                    <span  style={{textDecoration: todo.completed ? 'line-through' : 'none'}}  key={todo.id} onClick={() => todo2Click(todo.id)}>{todo.message}</span>
                    {' '}
                    <span onClick={() => removeItem(todo.id)} className="fa fa-times"></span>
                </li>
            ))}
        </ul>
    )

}


export default ListToDo