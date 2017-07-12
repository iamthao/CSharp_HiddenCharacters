import React, { Component } from 'react';
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
      height: 200
    }
  }
  render() { 
    //console.log(this)
    var {first, last, number, pic} = this.props;
    var {height} = this.state;
    //console.log(height);

    return (
        <div className="div-center">
          <p>First : {first}</p>
          <p>Last : {last}</p>
          <p>Number : {number}</p>
          <p><img src={pic} height= {height} /></p>
          <p><button onClick={this.zoomPicIn.bind(this)}> + </button>    
            <button onClick={this.zoomPicOut.bind(this)}> - </button></p>
        </div>
    );
  }
  zoomPicIn() {
    this.setState({height : this.state.height + 30});
  };

  zoomPicOut() {
    this.setState({height : this.state.height - 30});
  }
}

ReactDOM.render(<Thao first="Thao" last="Nguyen" number="14" pic="https://unsplash.it/458/354"/>, 
    document.getElementById('test'));

export default App;
