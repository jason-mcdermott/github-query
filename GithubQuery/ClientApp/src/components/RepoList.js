import React, { Component } from 'react';

export class RepoList extends Component {
    displayName = RepoList.name

    constructor(props) {
        super(props);
        this.state = { repos: [], loading: true };

        let query = props.organization ? props.organization : 'ramda';

        fetch('api/github/search?organization=' + query)
            .then(response => response.json())
            .then(data => {
                this.setState({ repos: data, loading: false });
            });
    }

    //static renderTable(repos) {
    //    return (
    //        <table className='table'>
    //            <thead>
    //                <tr>
    //                    <th>Repo</th>
    //                    <th>Col1</th>
    //                    <th>Col2</th>
    //                    <th>Col3</th>
    //                </tr>
    //            </thead>
    //            <tbody>
    //                {repos.map(repo =>
    //                    <tr key={repo.id}>
    //                        <td>{repo.name}</td>
    //                        <td>{repo.full_name}</td>
    //                        <td>{repo.description}</td>
    //                        <td>{repo.url}</td>
    //                    </tr>
    //                )}
    //            </tbody>
    //        </table>
    //    );
    //}
    
    //static renderTable(repos) {
        
    //    return (
    //        <ul>
    //            {repos.map(function (groupItem, key) {
    //                return (
    //                    Object.entries(groupItem).map(([v, k]) => {
    //                        return (
    //                            <li> {v.toString()} :  </li>
    //                        );
    //                    })
    //                );
    //             })}
    //        </ul>
                    
    //    );
    //}

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
                <h1>Github Repos</h1>
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