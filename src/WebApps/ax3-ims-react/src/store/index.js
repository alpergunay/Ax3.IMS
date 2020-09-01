import { createStore, applyMiddleware, combineReducers } from 'redux';
import thunk from 'redux-thunk';
import logger from 'redux-logger';
import { auth, global } from './reducers';

const reducer = combineReducers({ auth, global });
let store;

if (process.env.NODE_ENV === 'development') {
  store = createStore(
    reducer,
    applyMiddleware(thunk, logger)
  );
}
else {
  store = createStore(
    reducer,
    applyMiddleware(thunk)
  );
}

export default store;