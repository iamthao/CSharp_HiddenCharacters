/**
 * Created by Thao Nguyen on 07/18/2017.
 */
import './Layout.css';
import logo from './logo.svg';
import React from 'react';
import { Navbar, Nav, NavItem
} from 'react-bootstrap';
import {
    BrowserRouter as Router,
    Route
} from 'react-router-dom';
import {LinkContainer} from 'react-router-bootstrap';

import Home from "./Home";
import About from "./About";

const Sandwiches = () => <h2>About</h2>
////////////////////////////////////////////////////////////
// then our route config
const routes = [
    {
        path: '/home',
        component: Home
    },
    {
        path: '/about',
        component: About,
        routes: [
            {
                path: '/tacos/bus',
                component: Sandwiches
            },
            {
                path: '/tacos/cart',
                component: Sandwiches
            }
        ]
    }
]


// wrap <Route> and use this everywhere instead, then when
// sub routes are added to any route it'll work
const RouteWithSubRoutes = (route) => (
    <Route path={route.path} render={props => (
        // pass the sub-routes down to keep nesting
        <route.component {...props} routes={route.routes}/>
    )}/>
)

const Layout = () => (
    <Router>
        <div>
            <Navbar inverse collapseOnSelect>
                <Navbar.Header>
                    <Navbar.Brand>
                        <LinkContainer to="/home">
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
                            <NavItem eventKey={2}>About</NavItem>
                        </LinkContainer>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>

            <div id="content" className="container">
                {routes.map((route, i) => (
                    <RouteWithSubRoutes key={i} {...route}/>
                ))}
            </div>
        </div>
    </Router>
)


export default Layout