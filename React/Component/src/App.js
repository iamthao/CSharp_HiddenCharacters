import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';
import Header from "./AppHeader";

class App extends Component {
    constructor(props){
        super(props);
        this.state = {
            name:"Thao",
            value:"123"
        };
    }
    handleChange(event) {
        var a = event.target.value;
        this.setState({name: a,value:a});
    }

    render() {
        return (
            <div className="App">
                <div className="App-header">
                    <img src={logo} className="App-logo" alt="logo"/>
                    <h2>Welcome to React, {this.state.name}</h2>
                </div>
                <Header title = {this.state.name}/>
                <input maxLength={10} type="text" value={this.state.value}  onChange={this.handleChange.bind(this)} />
            </div>
        );
    }

}

export default App;
