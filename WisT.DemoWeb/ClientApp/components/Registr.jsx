import React from 'react';
import WebcamComponent from './RegistrationWebcam'
import LoginField from './LoginField'
import axios from 'axios'
import { log } from 'util';
import dataURLtoBlob from 'blueimp-canvas-to-blob'

export default class Register extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            login: '',
            photoData: new Blob(),
            photoArray: Array(1).fill(new Blob()),
            photoSrc: '',
            message: 'Take photo input your login and send to register.',
            isDisabled: true
        };
    }

    onLoginUpdate = (val) => {
        this.setState({
            login: val
        })
        this.setState({ isDisabled: !val || val === " " || !this.state.photoData });
    };

    onPhotoUpdate = (imageSrc) => {

        this.setState({
            photoData: imageSrc[0],
            photoArray: imageSrc,
            photoSrc: window.URL.createObjectURL(imageSrc[0])
        });
        this.setState({ isDisabled: !this.state.login || this.state.login === "" });
    }

    send = () => {

        let wisTMessage = "Please wait.";
        this.setState({
            isDisabled: true,
            message: wisTMessage
        });

        let data = new FormData();
        for (let i = 0; i < this.state.photoArray.length; i++) {
            data.append('Photoes', this.state.photoArray[i]);
        }
        data.append('Login', this.state.login);

        let wisTMessage;

        axios.post('api/Registration', data)
            .then((response) => {
                if (response.status == 200)
                    wisTMessage = "You are registered.";
                this.setState({
                    message: wisTMessage,
                    isDisabled: false
                });
            })
            .catch((error) => {
                if (error.response) {
                    if (error.response.status == 400)
                        wisTMessage = "This photo is bad, I don't see you.";
                    this.setState({
                        message: wisTMessage,
                        isDisabled: false
                    });
                }
            });
    }

    render() {
        return (
            <div className="registr">
                <LoginField onUpdate={this.onLoginUpdate} />
                <WebcamComponent onUpdate={this.onPhotoUpdate} />
                <h1 className="response">{this.state.message}</h1>
                <img className="image" src={this.state.photoSrc} alt="Taken photo" />
                <div className="temp1">
                    <button className="send" onClick={this.send} disabled={this.state.isDisabled}>Create an account</button>
                </div>
            </div>
        );
    }
}