import React from 'react';
import axios from 'axios';

export default class Greeting extends React.Component {
    constructor(props) {
        super(props);
        this.state = { greetingMessage: "Initial Message" };
    }

    componentDidMount() {
        axios.get('api/Greeting')
            .then(res => {
                const greetingMessage = res.data;
                this.setState({ greetingMessage });
            });
    }

    render() {
        return (
            <div>
                <h1>Greeting message is: {this.state.greetingMessage}</h1>
            </div>
        );
    }
}

