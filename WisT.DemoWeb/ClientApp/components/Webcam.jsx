import React from 'react';
import Webcam from 'react-webcam';

export default class WebcamComponent extends React.Component {

    setRef = (webcam) => {
        this.webcam = webcam;
    }

    capture = () => {
        const imageSrc = this.webcam.getScreenshot();
        console.log(imageSrc);
    };

    render() {
        return (
            <div>
                < Webcam
                    audio={false}
                    screenshotFormat="image/webp"
                    ref={this.setRef}
                    height={400}
                    weight={400}
                />
                <button id="take" onClick={this.capture}>Take photo</button>
            </div>
        );
    }
}