import React from 'react';
import Webcam from './Webcam'
import LoginField from './LoginField'
import axios from 'axios';

export default class Logon extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            photoData: new Blob(),
            photoSrc: '',
            login: ''
        };
    }

    onLoginUpdate = (val) => {
        this.setState({
            login: val
        })
    };

    onPhotoUpdate = (val) => {
        this.setState({
            photoData: val,
            photoSrc: window.URL.createObjectURL(val)
        })
    };

    send = () => {
        let data = new FormData();
        data.append('photo', this.state.photoData);
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
            <div className="logon">
                <LoginField onUpdate={this.onLoginUpdate} />
                <Webcam onUpdate={this.onPhotoUpdate} />
                <button id="take" onClick={this.send}>Send</button>
                <img src={this.state.photoSrc} alt="Taken photo" />
            </div>
        );
    }
}