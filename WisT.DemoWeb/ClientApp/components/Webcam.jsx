import React from 'react';
import Webcam from 'react-webcam';
import dataURLtoBlob from 'blueimp-canvas-to-blob'

export default class WebcamComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    setRef = (webcam) => {
        this.webcam = webcam;
    }

    capture = () => {
        const imageSrc = dataURLtoBlob( this.webcam.getScreenshot());
        this.props.onUpdate(imageSrc);
    };

    render() {
        return (
            <div className="camera">
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
                    <button className="take" onClick={this.capture}>Take photo</button>
                </div>
            </div>
        );
    }
}