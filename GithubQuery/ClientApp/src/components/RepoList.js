import React, { Component } from 'react';

export class RepoList extends Component {
    displayName = RepoList.name

    constructor(props) {
        super(props);
        this.state = { repos: [], loading: true };

        let query = props.organization ? props.organization : 'ramda';

        fetch('api/ramda/repos')
            .then(response => response.json())
            .then(data => {
                this.setState({ repos: data, loading: false });
            });
    }
    
    static renderTable(repos) {

        return (
            <ul>
                {repos.map(function (groupItem, key) {
                    return (
                        Object.entries(groupItem).map(function(v, k) {
                            let values = v.toString().split(',');
                            if (values[1] && typeof values[1] !== 'object' && values[1].constructor !== Object && values[1].toString() !== '[object Object]') {
                                return (
                                    <li> {values[0].toString()} :  {values[1].toString()} </li>
                                );
                            } else if (values[1]) {
                                Object.entries(values[1]).map(function (innerV) {
                                    let innerValues = innerV.toString().split(',');
                                    return (
                                        <li> {innerValues[0].toString()} :  {innerValues[1].toString()} </li>
                                    );
                                }); 
                            }
                        })
                    );
                })}
            </ul>

        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : RepoList.renderTable(this.state.repos);

        return (
            <div>
                <h1>Github Query</h1>
                <p>Repos from the Ramda organization.</p>
                {contents}
            </div>
        );
    }
}

class Repo extends React.Component {
    render() {
        return <li>{this.props.key + ": " + this.props.value}</li>;
    }
}