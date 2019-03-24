import React, { Component } from 'react';

export class RepoLinks extends Component {
    displayName = RepoLinks.name

    constructor(props) {
        super(props);
        this.state = { loading: false };
    }

    static renderTable() {
        return (
            <ul>
                <li><a href="/api/ramda/repos">All Ramda repos</a></li>
                <li><a href="/api/ramda/repos/count">All Ramda repos (count)</a></li>
                <li><a href="/api/ramda/repos/page/1?resultsperpage=5">Ramda repos (page 1 with 5 results per page)</a></li>
                <li><a href="/api/ramda/ramda/pulls/page/1?resultsperpage=5&state=closed">Ramda/ramda pull requests where state is 'closed' (page 1 with 5 results per page)</a></li>
                <li><a href="/api/ramda/pulls">All Ramda pull requests (??!!)</a></li>
                <li><a href="/api/ramda/pulls/count">All Ramda pull requests (count)</a></li>
            </ul>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : RepoLinks.renderTable();

        return (
            <div>
                <h1>Github Query</h1>
                <p>Links to query the Github V3 API.</p>
                {contents}
            </div>
        );
    }
}
