import React from 'react';
import { Link } from 'react-router-dom';
import { PlusOutlined } from '@ant-design/icons';
import { Button } from 'antd';

export default ({ t, addKey, addUrl }) => (
  <div className="mb-15">
    <Link to={addUrl}>
      <Button type="primary" icon={<PlusOutlined />}>
        {t(addKey)}
      </Button>
    </Link>
  </div>
);