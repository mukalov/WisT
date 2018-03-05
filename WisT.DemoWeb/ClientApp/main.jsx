import './css/site.css'
import React from 'react'
import ReactDOM from 'react-dom'
import HelloWorld from './components/Greeting'
import WebCam from './components/Webcam'

ReactDOM.render(<WebCam />, document.getElementById('app'))