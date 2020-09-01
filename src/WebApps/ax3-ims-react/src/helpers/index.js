import { cloneDeep } from 'lodash';

/**
 * Removes empty strings, arrays, objects from an object.
 * @param {Object} payload
 */
export const clear = (payload, isSub) => {
  if (!payload || (payload && typeof payload !== 'object')) return {};
  let _payload = isSub ? payload : cloneDeep(payload);
  Object.keys(_payload).forEach(key => {
    if (_payload[key] && typeof _payload[key] === 'object') {
      clear(_payload[key], true);
      if (Object.keys(_payload[key]).length < 1) {
        delete _payload[key];
      }
    }
    else if (_payload[key] === null || _payload[key] === '') delete _payload[key];
  });
  return _payload;
};