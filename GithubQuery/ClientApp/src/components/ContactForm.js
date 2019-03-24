import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';

class ContactForm extends Component {

    submitForm(e) {
        e.preventDefault()
        const form = new FormData(e.target);
        let data = form.get('searchInput');
        this.props.history.push(`/repos?organization=${data}`);
    }

    render() {
        return (
            <div>
                <form onSubmit={this.submitForm.bind(this)}>
                    <input type="text" placeholder="search" name="searchInput"/>
                    <button type="submit">Submit</button>
                </form>
            </div>
        )

    }
}
export default withRouter(ContactForm);