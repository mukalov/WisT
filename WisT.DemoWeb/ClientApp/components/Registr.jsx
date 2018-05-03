import React from 'react';
import WebcamComponent from './Webcam'
import LoginField from './LoginField'
import axios from 'axios'

export default class Register extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            login: '',
            photoData: new Blob(),
            photoArray: new Array(5),
            photoSrc: ''
        };
    }

    onLoginUpdate = (val) => {
        this.setState({
            login: val
        })
    };

    onPhotoUpdate = (imageSrc) => {

        var ph = new Array(5);
        for (var i = 0; i < 5; i++) {
            ph[i] = new Blob();
            this.onPhotoUpdate;
            ph.push(this.state.photoData);
        }

        this.setState({
            photoData: imageSrc,
            photoArray: ph,
            photoSrc: window.URL.createObjectURL(imageSrc)
        });
    }

    send = () => {
        let data = new FormData();
        data.append('photo', this.state.photoArray);
        data.append('login', this.state.login);
        axios.post('api/UploadUserInfo', data)
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