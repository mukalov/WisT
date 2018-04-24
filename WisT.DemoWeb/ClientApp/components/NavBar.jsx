import React from 'react';


export default class NavBar extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <ul className="nav_bar">
                <li ><a href="">Create an account</a></li>
                <li><a href="">Sign In</a></li>
            </ul>
        );
    }
}