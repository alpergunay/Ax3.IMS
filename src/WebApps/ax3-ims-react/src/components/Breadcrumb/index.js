import React, { useEffect, useState } from 'react';
import { Breadcrumb } from 'antd';
import { HomeOutlined } from '@ant-design/icons';
import { useHistory } from 'react-router-dom';

export default () => {
  const history = useHistory();
  const [url, setUrl] = useState(history.location.pathname.split('/'));

  useEffect(() => {
    history.listen((location, action) => {
      setUrl(location.pathname.split('/'))
    })
  }, [history]);

  return (
    <div className="Breadcrumb">
      <Breadcrumb>
        {url.map((x, i) => (
          <Breadcrumb.Item key={x}>
            {x ? x : <HomeOutlined />}
          </Breadcrumb.Item>
        ))}
      </Breadcrumb>
    </div>
  );
};