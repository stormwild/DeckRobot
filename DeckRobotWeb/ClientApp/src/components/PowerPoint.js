import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Form, FormGroup, Input, Label, Button } from "reactstrap";
import axios from 'axios';

class PowerPoint extends Component {
    constructor(props) {
        super(props);

        // @TODO Retrieve available font families on the server from an api
        // for now hard code list of common fonts
        this.fontFamilies = ['Arial', 'Helvetica', 'Times', 'Times New Roman', 'Courier', 'Courier New'];
        
        this.fontFamilyRef = null;
        this.state = {
            fontFamily: this.fontFamilies[0],
            file: null,
            loaded: 0
        };
    }

    submit(e) {
        e.preventDefault();

        if(this.state.fontFamily && this.state.file) {
            const data = new FormData();
            data.append('file', this.state.file, this.state.file.name);
            axios.post('/api/powerpoint', data, {
                onUploadProgress: ProgressEvent => {
                    this.setState({
                        loaded: (ProgressEvent.loaded / ProgressEvent.total * 100)
                    });
                }
            })
            .then(res => {
                console.log(res.statusText);
            }, err => {
                console.log(err);
            });
        }
        // @TODO show errors for invalid fields
        console.log('form errors');
    }

    fileSelected = e => {
        this.setState({
            file: e.target.files[0],
            loaded: 0
        });
    }

    fontFamilyChanged = e => {
        const { name, value } = e.target;
        this.setState({
            [name]: value
        });
    }

    componentDidUpdate() {
        console.log('state', this.state);
    }

    render() {
        /*http://web.mit.edu/jmorzins/www/fonts.html */

        return (
            <Form
                method="post"
                encType="multipart/form-data"
                onSubmit={e => this.submit(e)}
            >
                {this.state.loaded > 0 && <p>{this.state.loaded}</p>}
                <FormGroup>
                    <Label for="fontFamily">Select Font Family</Label>
                    <Input type="select"
                        name="fontFamily" 
                        id="fontFamily" 
                        onChange={this.fontFamilyChanged}
                        ref={ el => this.fontFamilyRef = el }>
                        {this.fontFamilies.map((f, i) => <option key={f} value={f}>{f}</option>)}
                    </Input>
                </FormGroup>
                <FormGroup>
                    <Label>PowerPoint File</Label>
                    <Input type="file" name="file" onChange={this.fileSelected} />
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