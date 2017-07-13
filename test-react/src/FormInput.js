/**
 * Created by Thao Nguyen on 07/13/2017.
 */
//----------FormInput-----------
import React from 'react';
//import ReactDOM from 'react-dom';
import {FormGroup, ControlLabel, FormControl, Form, Button,Col} from 'react-bootstrap';

class FormInput extends React.Component {
    constructor(props) {
        super(props);
        this.state = {value: ''};

        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(event) {
        this.setState({value: event.target.value});
    }

    render() {
        return (
            <div>
                <Form inline>
                    <FormGroup>
                        <ControlLabel>Name</ControlLabel>
                        {' '}
                        <FormControl type="text" placeholder="Jane Doe" value={this.state.value}
                                     onChange={this.handleChange}/>
                        {' '}
                        <ControlLabel>{this.state.value} </ControlLabel>
                    </FormGroup>
                </Form>
                <Form inline>
                    <FormGroup>
                        <Button bsSize="lg" disabled>Default</Button>
                        {' '}
                        {/* Provides extra visual weight and identifies the primary action in a set of buttons */}
                        <Button bsSize="large" bsStyle="primary">Primary</Button>
                        {' '}
                        {/* Indicates a successful or positive action */}
                        <Button bsSize="sm" bsStyle="success">Success</Button>
                        {' '}
                        {/* Contextual button for informational alert messages */}
                        <Button bsSize="small" bsStyle="info">Info</Button>
                        {' '}
                        {/* Indicates caution should be taken with this action */}
                        <Button bsSize="xs" bsStyle="warning">Warning</Button>
                        {' '}
                        {/* Indicates a dangerous or potentially negative action */}
                        <Button bsSize="xsmall" bsStyle="danger">Danger</Button>
                        {' '}
                        {/* Deemphasize a button by making it look like a link while maintaining button behavior */}
                        <Button bsStyle="link">Link</Button>
                    </FormGroup>
                </Form>
                <Form horizontal>
                    <FormGroup>
                        <Col md={1} sm={1} xs={3}>
                            <ControlLabel>Email</ControlLabel>
                        </Col>
                        <Col md={11} sm={11} xs={9}>
                            <FormControl type="email" placeholder="Email" />
                        </Col>
                    </FormGroup>
                </Form>
            </div>
        );
    }
}

export default FormInput;
