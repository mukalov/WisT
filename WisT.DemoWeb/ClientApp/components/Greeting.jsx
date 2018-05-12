import React from 'react';
import axios from 'axios';

export default class Greeting extends React.Component {
    constructor(props) {
        super(props);
        this.state = { greetingMessage: "" };
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
            <div className="greeting"> 
                <h1>{this.state.greetingMessage}</h1>
            </div>
        );
    }
}

