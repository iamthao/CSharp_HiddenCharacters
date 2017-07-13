import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import Tang from './IncreamentNumber';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<App />, document.getElementById('root'));
ReactDOM.render(<Tang />, document.getElementById('test1'));
registerServiceWorker();
