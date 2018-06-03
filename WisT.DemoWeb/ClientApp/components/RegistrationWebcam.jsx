import React from 'react';
import Webcam from 'react-webcam';
import dataURLtoBlob from 'blueimp-canvas-to-blob'
import { setTimeout } from 'timers';

export default class WebcamComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isDisabled: false,
            counter: 1,
            imageSrc: Array()
        };
    }

    setRef = (webcam) => {
        this.webcam = webcam;
    }

    capture = () => {
        this.setState({ isDisabled: false });
        const numOfPhotoes = 5;
        this.state.imageSrc.push();

        var images = this.state.imageSrc;
        images.push(dataURLtoBlob(this.webcam.getScreenshot()));
        this.setState({ imageSrc: images });

        this.setState({ counter: this.state.counter + 1 });

        if (this.state.counter == numOfPhotoes) {
            this.setState({ isDisabled: true });
        }
        this.props.onUpdate(this.state.imageSrc);
    };

    render() {
        return (
            <div className="camera">
                <h1 className="message">Take {6 - this.state.counter} photos</h1>
                <div className="temp">
                    < Webcam
                        audio={false}
                        screenshotFormat="image/jpeg"
                        ref={this.setRef}
                        height={600}
                        weight={600}
                    />
                </div>
                <br></br>
                <div className="temp1">
                    <button className="take" onClick={this.capture} disabled={this.state.isDisabled}>Take photo</button>
                </div>
            </div>
        );
    }
}