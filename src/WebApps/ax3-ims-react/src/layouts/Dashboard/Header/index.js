import React from 'react';
import { MenuFoldOutlined, MenuUnfoldOutlined } from '@ant-design/icons';
import { Button } from 'antd';
import Account from './Account';

export default ({ collapsed, setCollapsed }) => {

  const onClick = () => {
    localStorage.setItem('collapsed', !collapsed);
    setCollapsed(!collapsed);
  };

  return (
    <>
      <Button
        type="link"
        className="ToggleButton"
        icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
        onClick={onClick}
      />
      <Account />
    </>
  )
};