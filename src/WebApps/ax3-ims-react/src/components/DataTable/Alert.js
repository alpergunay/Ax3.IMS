import React from 'react';
import { Alert } from 'antd';

export default ({ t, total }) => (
  <Alert type="info" message={
    <>
      {t('totalRecord')} : <span className="text-bold">{total}</span>
    </>
  } showIcon />
);