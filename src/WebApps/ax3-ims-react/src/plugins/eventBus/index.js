var e = {};

const $on = (type, callback) => {
  if (!type || !callback) {
    console.error('Type and callback arguments cannot be empty.');
    return;
  }
  if (callback && typeof callback !== 'function') {
    console.error('Invalid argument supplied for callback. (' + typeof callback + ') Callback must be a function.');
    return;
  }
  if (type && typeof type !== 'string') {
    console.error('Invalid event type: ' + typeof callback + '. Event type must be a string.');
    return;
  }

  if (e[type]) e[type].push(callback);
  else e[type] = [callback];
};

const $off = (type, callback) => {
  if (!type || !callback) {
    console.error('Type and callback arguments cannot be empty.');
    return;
  }
  if (callback && typeof callback !== 'function') {
    console.error('Invalid argument supplied for callback. (' + typeof callback + ') Callback must be a function.');
    return;
  }
  if (type && typeof type !== 'string') {
    console.error('Invalid event type: ' + typeof callback + '. Event type must be a string.');
    return;
  }

  if (e[type]) {
    const index = e[type].indexOf(callback);
    if (index > -1) e[type].splice(index, 1);
  }
};

const $emit = (type, data) => {
  if (!type) {
    console.error('Type argument cannot be empty.');
    return;
  }
  if (type && typeof type !== 'string') {
    console.error('Invalid event type: ' + typeof callback + '. Event type must be a string.');
    return;
  }
  if (e[type]) {
    for (var i = 0, len = e[type].length; i < len; i++) {
      e[type][i](data);
    }
  }
};

export default { $on, $off, $emit };