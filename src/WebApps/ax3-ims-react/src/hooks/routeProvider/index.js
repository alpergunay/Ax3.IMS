import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
import RouteComponent from './routeComponent';
import RouteSwitch from './routeSwitch';

export default ({ routes }) => {

  return (
    <Switch>
      {routes.map((x, i) =>
        x.redirect ?
          <Redirect key={i} from={x.path} to={x.redirect} />
          :
          <Route
            key={i}
            exact={x.routes ? x.routes.some(y => y.exact) : x.exact}
            path={x.routes ? x.routes.map(y => y.path) : x.path}
          >
            <x.component>
              {x.routes && x.routes.map((y, j) =>
                <Route key={j} path={y.path} render={(props) => (
                  y.routes ?
                    <RouteSwitch {...props} path={y.path} routes={y.routes} />
                    :
                    <RouteComponent {...props} route={y} />
                )} />
              )}
            </x.component>
          </Route>
      )}
      {/* <Redirect to="/home" /> */}
    </Switch>
  );
};