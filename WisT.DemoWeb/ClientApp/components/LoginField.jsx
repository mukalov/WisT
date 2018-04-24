import React from 'react';

export default class LoginField extends React.Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.state = { text: '' };
    }

    handleChange(e) {
        this.props.onUpdate(e.target.value);
        this.setState({ text: e.target.value });
    }

    send_login = () => {
        var val = this.state.text;
        console.log(val);
    }

    render() {
        return (
            <div className="login">
                <p>Login:</p>
                <input id="text_area" type="text"
                    onChange={this.handleChange}
                    value={this.state.text}
                />

            </div>
        );
    }
}