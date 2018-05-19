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
            isDisabled:false
        };
    }

    onLoginUpdate = (val) => {
        this.setState({
            login: val
        })
    };

    onPhotoUpdate = (imageSrc) => {

        this.setState({
            photoData: imageSrc[0],
            photoArray: imageSrc,
            photoSrc: window.URL.createObjectURL(imageSrc[0]),
        });
        console.log(this.state.photoArray);
    }

    send = () => {
         this.setState({ isDisabled: true });
         let data = new FormData();
        console.log(this.state.photoArray);
        for (let i = 0; i < this.state.photoArray.length; i++) {
            data.append('Photoes', this.state.photoArray[i]);
        }

        data.append('Login', this.state.login);

        let wisTMessage;

        axios.post('api/Registration', data)
            .then((response) => {
                if (response.status == 200) {
                    wisTMessage = "You are registrated.";
                    this.setState({ isDisabled: false });
                }
                this.setState({ message: wisTMessage });
            })
            .catch((error) => {
                if (error.response) {
                    if (error.response.status == 400) {
                        wisTMessage = "This photo is bad, I don't see you.";
                        this.setState({ isDisabled: false });
                    }
                    this.setState({ message: wisTMessage });
                }
            });
    }

    render() {
        return (
            <div className="registr">
                <LoginField onUpdate={this.onLoginUpdate} />
                <WebcamComponent onUpdate={this.onPhotoUpdate} />
                <h1 className="response">Message: {this.state.message}</h1>
                <img className="image" src={this.state.photoSrc} alt="Taken photo" />
                <button className="send" onClick={this.send} disabled={this.state.isDisabled}>Create an account</button>
            </div>
        );
    }
}