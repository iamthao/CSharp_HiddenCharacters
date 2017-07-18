/**
 * Created by Thao Nguyen on 07/18/2017.
 */
import React, {Component} from 'react';
import './App.css';


class About extends Component {
    constructor(props){
        super(props);
        this.state = {
            name:"Thao",
            value:"123"
        };
    }

    render() {
        return (
            <div>
                About
            </div>
        );
    }

}

export default About;