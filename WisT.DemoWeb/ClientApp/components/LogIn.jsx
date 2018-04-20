import React from 'react';
import WebcamComponent from './Webcam'
import LoginField from './LoginField'

export default class LogIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = { login: '', capture: '' };
    }

    setCapture = imageSrc => {
        this.setState({ capture: imageSrc });
    }

    setLogin = loginSrc => {
        this.setState({ login: loginSrc });
    }

    logIn = () => {
        if (this.state.login != '' && this.state.capture != '') {
            console.log(this.state.login);
            console.log(this.state.capture);
        }
    }

    render() {
        return (
            <div>
                <LoginField setLogin={this.setLogin} />
                <WebcamComponent setCapture={this.setCapture} />
                <button id="send" onClick={this.logIn}>Log in</button>
            </div>
        );
    }
}