import React from 'react';
import Webcam from 'react-webcam';

export default class WebcamComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = { capture: '' };
    }

    setRef = (webcam) => {
        this.webcam = webcam;
    }

    capture = () => {
        const imageSrc = this.webcam.getScreenshot();
        this.props.setCapture(imageSrc);
    };

    render() {
        return (
            <div id="camera">
                < Webcam
                    audio={false}
                    screenshotFormat="image/webp"
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