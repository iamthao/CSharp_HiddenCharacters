import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import './boostrap/css/bootstrap.min.css';
import './fontawesome/css/font-awesome.min.css';
import Layout from './Layout';

import registerServiceWorker from './registerServiceWorker';


ReactDOM.render(<Layout />, document.getElementById('root'));

registerServiceWorker();
