import React from 'react';
import WebcamComponent from './Webcam'
import LoginField from './LoginField'
import axios from 'axios'

export default class LogIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            photoData: new Blob(),
            photoSrc: ''
        };
    }

    onPhotoUpdate = (imageSrc) => {
        this.setState({
            photoData: imageSrc,
            photoSrc: window.URL.createObjectURL(imageSrc)
        });
    }

    send = () => {
        let data = new FormData();
        data.append('Photo', this.state.photoData);
        

        axios.post('api/Login', data)
            .then((response) => {
                console.log(response);
            })
            .catch((error) => {
                console.log(error);
            });
    }

    render() {
        return (
            <div className="login">
                <WebcamComponent onUpdate={this.onPhotoUpdate} />
                <button id="take" onClick={this.send}>Log in</button>
                <img src={this.state.photoSrc} alt="Taken photo" />
            </div>
        );
    }
}
