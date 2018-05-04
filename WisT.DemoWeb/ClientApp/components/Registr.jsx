import React from 'react';
import WebcamComponent from './Webcam'
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

        var ph = this.state.photoArray;
        for (var i = 0; i < 5; i++) {

            ph[i] = new Blob();
            ph[i] = imageSrc;
        }
        console.log(ph);
        this.setState({
            photoData: imageSrc,
            photoArray: ph,
            photoSrc: window.URL.createObjectURL(imageSrc)
        });
        console.log(this.state.photoArray);
    }

    send = () => {
        let data = new FormData();
        console.log(this.state.photoArray);
        data.append('Photoes', this.state.photoArray);
        
        data.append('Login', this.state.login);

        axios.post('api/Registration', data)
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    }

    render() {
        return (
            <div className="registr">
                <LoginField onUpdate={this.onLoginUpdate} />
                <WebcamComponent onUpdate={this.onPhotoUpdate} />
                <button id="send" onClick={this.send}>Create an account</button>
                <img src={this.state.photoSrc} alt="Taken photo" />
            </div>
        );
    }
}