import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Form, FormGroup, Input, Label, Button } from "reactstrap";

const model = {
    fontFamily: 'serif',
    file: null
};

class PowerPoint extends Component {
    constructor(props) {
        super(props);
        this.state = model;
    }

    submit(e) {
        e.preventDefault();
        alert('Form submitted');
        console.log(e);
        console.log(e.target);
    }

    render() {
        /*http://web.mit.edu/jmorzins/www/fonts.html */

        return (
            <Form
                method="post"
                encType="multipart/form-data"
                onSubmit={e => this.submit(e)}
            >
                <FormGroup>
                    <Label for="fontFamily">Select Font Family</Label>
                    <Input type="select" name="fontFamily" id="fontFamily">
                        <option value="Arial">Arial</option>
                        <option value="Helvetica">Helvetica</option>
                        <option value="Times">Times</option>
                        <option value="Times New Roman">Times New Roman</option>
                        <option value="Courier">Courier</option>
                        <option value="Courier New">Courier New</option>
                    </Input>
                </FormGroup>
                <FormGroup>
                    <Label>PowerPoint File</Label>
                    <Input type="file" name="file" />
                </FormGroup>
                <Button className="btn-primary" type="submit">Submit</Button>
            </Form>
        );
    }
}

export default connect(
    // state => state.Fonts,
    // dispatch => bindActionCreators(actionCreators, dispatch)
)(PowerPoint);