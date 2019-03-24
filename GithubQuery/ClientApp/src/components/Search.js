import React, { Component } from 'react'
//import Suggestions from './Suggestions'

export class Search extends Component {
    constructor() {
        super();

        this.state = {
            queryInput: '',
            query: '',
            repos: []
        };

        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        //event.preventDefault();
        const form = new FormData(event.target);
        let data = form.get('searchInput');

        this.setState({
            query: data
        });

        this.search(data);
    }

    search = query => {
        let url = `https://localhost:44354/api/github/search?organization=${query}`;
        console.log(url)
        fetch(url)
            .then(response => response.json())
            .then(data => {
                this.setState({
                    repos: data
                })
            });
    };

    componentDidMount() {
        this.search("");
    }

    render() {
        return (
            <form name="searchForm" >
                <input
                    type="text"
                    className="search-box"
                    placeholder="Search for..."
                    name="searchInput"
                    onChange={this.handleSubmit}
                />
                <input type="submit" value="Submit" />
                {this.state.repos.map(repo => (
                    <ul key={repo.id}>
                        <li>{repo.name}</li>
                    </ul>
                ))}
            </form>
        );
    }
}