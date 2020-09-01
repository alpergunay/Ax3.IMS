import React, { useEffect } from 'react';
import { Card } from 'antd';
import { useHistory } from 'react-router-dom';

export default ({ children }) => {
  const history = useHistory();

  useEffect(() => {
    if (localStorage.getItem('token')) {
      history.push('/');
    }
  }, [history]);

  return (
    <div className="AuthLayout">
      <Card className="AuthContent">
        {children}
      </Card>
    </div>
  );
};