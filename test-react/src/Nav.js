/**
 * Created by Thao Nguyen on 07/13/2017.
 */
import React from 'react';
//import ReactDOM from 'react-dom';
import {Nav,NavItem} from 'react-bootstrap';

class Navi extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            numberSelect: 1
        }
        //this.handleClick = this.handleClick.bind(this,1);
    }

    render() {
        return (
            <div>
                <Nav bsStyle="pills" activeKey={this.state.numberSelect}>
                    <NavItem onClick={this.handleClick.bind(this,1)} className={(this.state.numberSelect == 1) ? "active" : ""}>Home</NavItem>
                    <NavItem onClick={this.handleClick.bind(this,2)} className={(this.state.numberSelect == 2) ? "active" : ""}>Template</NavItem>
                    <NavItem onClick={this.handleClick.bind(this,3)} className={(this.state.numberSelect == 3) ? "active" : ""}>About</NavItem>
                </Nav>
                <span>{this.state.numberSelect}</span>
            </div>
        )
    }

    handleClick(number){
        this.setState({numberSelect:number});
    }
}

export default Navi;

