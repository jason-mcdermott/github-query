import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { RepoList } from './components/RepoList';
import { RepoLinks } from './components/RepoLinks';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/repos' component={RepoList} />
        <Route path='/repolinks' component={RepoLinks} />       
      </Layout>
    );
  }
}
