/**
 * Created by Thao Nguyen on 07/18/2017.
 */
import './Layout.css';
import logo from './logo.svg';
import React from 'react';
import {
    Navbar, Nav, NavItem
} from 'react-bootstrap';
import {
    BrowserRouter as Router,
    Route
} from 'react-router-dom';
import {LinkContainer} from 'react-router-bootstrap';
import Home from "./Home";
import About from "./About";
import Todo2 from "./components/Todo2";

//--- install redux -----------
import {Provider} from 'react-redux'
import {createStore} from 'redux'
import rootReducer from './reducers/index'
let store = createStore(rootReducer);
//end redux --------------


const IndexPage = () => <h2>Index Page</h2>

const Layout = () => (
    <Provider store={store}>
        <Router>
            <div>
                <Navbar inverse collapseOnSelect>
                    <Navbar.Header>
                        <Navbar.Brand>
                            <LinkContainer to="/">
                                <img src={logo} className="App-logo" alt="logo"/>
                            </LinkContainer>
                        </Navbar.Brand>
                        <Navbar.Toggle />
                    </Navbar.Header>
                    <Navbar.Collapse>
                        <Nav className="nav navbar-nav">
                            <LinkContainer to="/home">
                                <NavItem eventKey={1}>Home</NavItem>
                            </LinkContainer>
                            <LinkContainer to="/about">
                                <NavItem eventKey={2}>To Do</NavItem>
                            </LinkContainer>
                            <LinkContainer to="/todo2">
                                <NavItem eventKey={3}>To Do 2</NavItem>
                            </LinkContainer>
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>

                <div id="content" className="container">
                    <Route exact path="/" component={IndexPage}/>
                    <Route path="/home" component={Home}/>
                    <Route path="/about" component={About}/>
                    <Route path="/todo2" component={Todo2}/>

                </div>
            </div>
        </Router>
    </Provider>
)


export default Layout