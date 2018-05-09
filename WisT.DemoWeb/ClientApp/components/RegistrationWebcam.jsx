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
        const imageSrc = new Array();
        for (var i = 0; i < 1; ++i) {
            imageSrc.push(dataURLtoBlob(this.webcam.getScreenshot()));
            setInterval(500);
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