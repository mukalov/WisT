import React from 'react';
import WebcamComponent from './RegistrationWebcam'
import LoginField from './LoginField'
import axios from 'axios'
import { log } from 'util';
import dataURLtoBlob from 'blueimp-canvas-to-blob'
import { Spinner } from 'react-activity';
import 'react-activity/dist/react-activity.css';

export default class Register extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            login: '',
            photoData: null,
            photoArray: Array(),
            photoSrc: '',
            message: 'Take photo input your login and send to register.',
            isDisabled: true,
            isNeeded: false
        };
    }

    onLoginUpdate = (val) => {
        this.setState({
            login: val
        })
        this.setState({ isDisabled: !val || val === " " && this.state.photoArray.length == 5 });
    };

    onPhotoUpdate = (imageSrc) => {

        this.state.photoData = new Blob();

        if (imageSrc.length ==5) {
            this.setState({
                photoData: imageSrc[0],
                photoArray: imageSrc,
                photoSrc: window.URL.createObjectURL(imageSrc[0])
            });
        }
        this.setState({ isDisabled: !this.state.login || this.state.login === "" });
    }



    send = () => {

        let wisTMessage = "Please wait.";
        this.setState({
            isDisabled: true,
            message: wisTMessage,
            isNeeded: true
        });

        let data = new FormData();

        console.log(this.state.photoArray);

        for (let i = 0; i < this.state.photoArray.length; i++) {
            console.log(this.state.photoArray[i]);
            data.append('Photoes', this.state.photoArray[i]);
        }

        data.append('Login', this.state.login);

        axios.post('api/Registration', data)
            .then((response) => {
                if (response.status == 200)
                    wisTMessage = "You are registered.";
                this.setState({
                    message: wisTMessage,
                    isDisabled: false,
                    isNeeded: false
                });
            })
            .catch((error) => {
                if (error.response) {
                    if (error.response.status == 400)
                        wisTMessage = "This photo is bad, I don't see you.";
                    this.setState({
                        message: wisTMessage,
                        isDisabled: false,
                        isNeeded: false
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
                <div className="spiner">
                    <Spinner color="#0000cc" size={50} speed={1} animating={this.state.isNeeded} />
                </div>
               
                <img className="image" src={this.state.photoSrc} alt="Taken photo" />
                <div className="temp1">
                    <button className="send" onClick={this.send} disabled={this.state.isDisabled}>Create an account</button>
                </div>
            </div>
        );
    }
}