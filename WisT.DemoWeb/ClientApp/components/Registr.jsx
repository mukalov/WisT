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
            photoArray: Array(5).fill(new Blob()),
            photoSrc: ''
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
            photoSrc: window.URL.createObjectURL(imageSrc[0])
        });
        console.log(this.state.photoArray);
    }

    send = () => {
        let data = new FormData();
        console.log(this.state.photoArray);
        for (var i = 0; i < 5; i++) {
            data.append('Photoes', this.state.photoArray[i]);
        }

        data.append('Login', this.state.login);

        axios.post('api/Registration', data)
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });

        getResponse = () => {
            axios.get('api/Registration')
                .then(res => {
                    const Message = res.status;
                    this.setState({ Message });
                });
        }
    }

    render() {
        return (
            <div className="registr">
                <LoginField onUpdate={this.onLoginUpdate} />
                <WebcamComponent onUpdate={this.onPhotoUpdate} />
                <h1>Greeting message is: {this.state.Message}</h1>
                <button id="send" onClick={this.send}>Create an account</button>
                <img src={this.state.photoSrc} alt="Taken photo" />
            </div>
        );
    }
}