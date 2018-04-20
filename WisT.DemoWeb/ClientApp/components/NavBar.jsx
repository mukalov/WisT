import React from 'react';
import ReactDOM from 'react-dom'
import LogIn from './LogIn'
import Register from './Registr'

export default class NavBar extends React.Component {
    constructor(props) {
        super(props);
    }

    register = () =>
    {
        ReactDOM.render(<Register />, document.getElementById('app'));
    }

    sign_in = () =>
    {
        ReactDOM.render(<LogIn />, document.getElementById('app'));
    }

    render() {
        return (
            <ul>
                <li ><a onClick={this.register}>Create an account</a></li>
                <li><a onClick={this.sign_in}>Sign In</a></li>
            </ul>
        );
    }
}