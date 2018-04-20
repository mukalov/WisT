import './css/site.css'
import React from 'react'
import ReactDOM from 'react-dom'
import HelloWorld from './components/Greeting'
import NavBar from './components/NavBar'

ReactDOM.render(<NavBar />, document.getElementById('nav_bar'));
ReactDOM.render(<HelloWorld />, document.getElementById('app'));
