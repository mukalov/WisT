import React from 'react'
import NavBar from './NavBar'
import HelloWorld from './Greeting'
import Logon from './Logon'

export default class App extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <nav>
                    <NavBar />
                </nav>
                <main>
                    <HelloWorld />
                    <Logon />
                </main>
            </div>
        );
    }
}