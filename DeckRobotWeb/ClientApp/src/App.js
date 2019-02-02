import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import PowerPoint from "./components/PowerPoint";

export default () => (
  <Layout>
    <Route exact path='/' component={PowerPoint} />
  </Layout>
);
