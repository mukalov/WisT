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
        var WisTMassage;
        axios.post('api/Login', data)
            .then((response) => {
                if (response.status == 200)
                    WisTMassage = "Welcome, " + response.data + ".";
                this.setState({ Message: WisTMassage });
                console.log(response);
            })
            .catch((error) => {
                if (error.response) {
                    if (error.response.status == 400) 
                        WisTMassage = "This photo is bad, I don't see you.";
                    if (error.response.status == 404)
                        WisTMassage = "You are not registered.";
                    this.setState({ Message: WisTMassage });
                }
            });
    }

    render() {
        return (
            <div className="login">
                <WebcamComponent onUpdate={this.onPhotoUpdate} />
                <h1 className="message">Massage: {this.state.Message}</h1>
                <img className="image" src={this.state.photoSrc} alt="Taken photo" />
                <button className="send" onClick={this.send}>Log in</button>
            </div>
        );
    }
}
