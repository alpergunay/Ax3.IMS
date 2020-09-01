import React, { useEffect } from 'react';

export default (props) => {

  useEffect(() => {
    window.$route = props.route;
  }, [props.route]);

  return (
    <props.route.component {...props} route={props.route} />
  );
};