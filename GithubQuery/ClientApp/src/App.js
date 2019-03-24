import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { RepoList } from './components/RepoList';
import { Search } from './components/Search';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/search' component={Search} />
        <Route path='/repos' component={RepoList} />
      </Layout>
    );
  }
}
