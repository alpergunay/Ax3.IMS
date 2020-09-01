import React from 'react';
import routes from 'plugins/routes';
import { RouteProvider } from 'hooks';

export default () => {
  return (
    <div className="App">
      <RouteProvider routes={routes} />
    </div>
  );
};