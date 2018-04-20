import React from 'react';
import WebcamComponent from './Webcam'
import LoginField from './LoginField'

export default class Register extends React.Component {
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

    registr = () => {
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
                <button id="send" onClick={this.registr}>Create an account</button>
            </div>
        );
    }
}