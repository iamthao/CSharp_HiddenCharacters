import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import './App.css';
import Thao from './ZoomImage';


class App extends Component {
    render() {
        return (
            <div className="App">
                <div className="App-header">
                    <h2>Test</h2>
                </div>
            </div>
        );
    }
}
//--------- zoom image -------------
ReactDOM.render(<Thao />, document.getElementById('test'));


export default App;
