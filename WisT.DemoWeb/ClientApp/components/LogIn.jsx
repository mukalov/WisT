import React from 'react';
import WebcamComponent from './Webcam'
import LoginField from './LoginField'
import axios from 'axios'

export default class LogIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            photoData: new Blob(),
            photoSrc: '',
            Message: 'Take photo and send to login.'
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
        this.getResponse();
    }

    getResponse = () => {
        axios.get('api/Login')
            .then(res => {
                if (res.status == 200)
                    WisTMassage = "You are logined!";
                if (res.status == 204)
                    WisTMassage = "You have bad photo I don't see you.";
                if (res.status >= 400)
                    WisTMassage = "You are not logined";
                this.setState({ Message: WistMassage });
            }).catch;
    }

    render() {
        return (
            <div className="login">
                <WebcamComponent onUpdate={this.onPhotoUpdate} />
                <button id="take" onClick={this.send}>Log in</button>
                <h1>Massage: {this.state.Message}</h1>
                <img src={this.state.photoSrc} alt="Taken photo" />
            </div>
        );
    }
}
