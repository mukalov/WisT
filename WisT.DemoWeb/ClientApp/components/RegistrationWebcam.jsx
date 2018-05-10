import React from 'react';
import Webcam from 'react-webcam';
import dataURLtoBlob from 'blueimp-canvas-to-blob'
import { setTimeout } from 'timers';

export default class WebcamComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    setRef = (webcam) => {
        this.webcam = webcam;
    }

    capture = () => {
        const numOfPhotoes = 1;
        const imageSrc = new Array();
        for (let i = 0; i < numOfPhotoes; i++) {
            imageSrc.push(dataURLtoBlob(this.webcam.getScreenshot()));
        }
        this.props.onUpdate(imageSrc);
    };

    render() {
        return (
            <div className="camera">
                < Webcam
                    audio={false}
                    screenshotFormat="image/jpeg"
                    ref={this.setRef}
                    height={400}
                    weight={400}
                />
                <br></br>
                <button id="take" onClick={this.capture}>Take photo</button>
            </div>
        );
    }
}