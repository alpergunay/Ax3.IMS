import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
import RouteComponent from './routeComponent';
import RouteSwitch from './routeSwitch';

export default ({ path, routes }) => {
  return (
    <Switch>
      {routes.map(x => (
        <Route
          exact={x.exact}
          key={x.name}
          path={`${path}${x.path}`}
          render={(props) => (
            x.routes ?
              <RouteSwitch {...props} path={`${path}${x.path}`} routes={x.routes} />
              :
              <RouteComponent {...props} route={x} />
          )}
        />
      ))}
      <Redirect to="/home" />
    </Switch>
  );
};