﻿import React from 'react';
import WebcamComponent from './Webcam'
import LoginField from './LoginField'
import axios from 'axios'

export default class LogIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            photoData: new Blob(),
            photoSrc: '',
            message: 'Take photo and send to login.',
            isDisabled: true
        };
    }

    onPhotoUpdate = (imageSrc) => {
        this.setState({
            photoData: imageSrc,
            photoSrc: window.URL.createObjectURL(imageSrc),
            isDisabled: false
        });
    }

    send = () => {

        let wisTMessage = "Please wait.";
        this.setState({
            isDisabled: true,
            message: wisTMessage
        });

        let data = new FormData();
        data.append('Photo', this.state.photoData);

        axios.post('api/Login', data)
            .then((response) => {
                if (response.status == 200)
                    wisTMessage = "Welcome, " + response.data + ".";
                this.setState({
                    message: wisTMessage,
                    isDisabled: false
                });
                console.log(response);
            })
            .catch((error) => {
                if (error.response) {
                    if (error.response.status == 400)
                        wisTMessage = "This photo is bad, I can't see you.";
                    if (error.response.status == 404)
                        wisTMessage = "You are not recognized.";
                    this.setState({
                        message: wisTMessage,
                        isDisabled: false
                    });
                }
            });
    }

    render() {
        return (
            <div >
                <WebcamComponent onUpdate={this.onPhotoUpdate} />
                <h1 className="message">{this.state.message}</h1>
                <img className="image" src={this.state.photoSrc} alt="Taken photo" />
                <div className="temp1">
                    <button className="send" onClick={this.send} disabled={this.state.isDisabled}>Log in</button>
                </div>
            </div>
        );
    }
}
