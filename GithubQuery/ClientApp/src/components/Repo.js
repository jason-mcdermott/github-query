import React, { Component } from 'react';

export class Repo extends Component {
    displayName = Repo.name

    constructor(props) {
        super(props);
        this.state = { repo: {}, loading: true };

        fetch('api/github/repo')
            .then(response => response.json())
            .then(data => {
                this.setState({
                    repo: data, loading: false
                });
            });
    }

    static renderTable(repo) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Repo</th>
                        <th>Col1</th>
                        <th>Col2</th>
                        <th>Col3</th>
                    </tr>
                </thead>
                <tbody>
                    <tr key={repo.id}>
                        <td>{repo.name}</td>
                        <td>{repo.full_name}</td>
                        <td>{repo.description}</td>
                        <td>{repo.url}</td>
                    </tr>
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Repo.renderTable(this.state.repo);

        return (
            <div>
                <h1>Github Repo</h1>
                <p>Repo from the Ramda organization.</p>
                {contents}
            </div>
        );
    }
}
