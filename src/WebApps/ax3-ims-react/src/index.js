import React from 'react';
import { render } from 'react-dom';
import App from './App';
import { unregister } from './serviceWorker';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from 'store';
import 'plugins';
import 'styles/antd.less';
import 'styles/main.less';

render(
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  document.getElementById('root')
);

unregister();