import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import logo from './logo.svg';
import './App.css';

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

class Thao extends Component {
    constructor(props) {
        super(props);
        this.state = {
            height: 200,
            width: 300
        }
    };

    render() {
        //console.log(this)
        var {first, last, number, pic} = this.props;
        var {height} = this.state;

        return (
            <div className="div-center">
                <p>{first} {last} {number}</p>

                <p><img src={pic} height={height}/></p>
                <p>
                    <button onClick={this.zoomPicIn.bind(this)}> +</button>
                    <button onClick={this.zoomPicOut.bind(this)}> -</button>
                </p>
            </div>
        );
    }

    zoomPicIn() {
        this.setState({height: this.state.height + 30});
    };

    zoomPicOut() {
        this.setState({height: this.state.height - 30});
    }

}

ReactDOM.render(<Thao first="Thao" last="Nguyen" number="14" pic="https://unsplash.it/458/354"/>,
    document.getElementById('test'));

class Tang extends Component {
    constructor(props) {
        super(props);
        this.state = {
            number: 0
        }
    };

    render() {
        //console.log(this)
        var {number} = this.state;

        return (
            <div className="div-center padding-top-10">
                <p>{number}</p>
                <p>
                    <button onClick={this.tangLen.bind(this)}> +</button>
                    <button onClick={this.giamXuong.bind(this)}> -</button>
                </p>
            </div>
        );
    }

    tangLen() {
        this.setState({number: this.state.number + 1});
    };

    giamXuong() {
        this.setState({number: this.state.number - 1});
    }

}

ReactDOM.render(<Tang/>,
    document.getElementById('test1'));

export default App;
