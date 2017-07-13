/**
 * Created by Thao Nguyen on 07/13/2017.
 */
import React, {Component} from 'react';
import {Tabs, Tab} from 'react-bootstrap';


//-------------TabControl--------
class TabControl extends Component {
    render() {
        return (
            <Tabs defaultActiveKey={2} id="uncontrolled-tab-example">
                <Tab eventKey={1} title="Tab 1">
                    Tab 1 content
                </Tab>
                <Tab eventKey={2} title="Tab 2">
                    Tab 2 content
                </Tab>
                <Tab eventKey={3} title="Tab 3">
                    Tab 3 content
                </Tab>
            </Tabs>
        );
    }
}


export default TabControl;