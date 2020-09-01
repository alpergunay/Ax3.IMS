import React from 'react';
import { Dropdown, Menu, Button } from 'antd';
import { LogoutOutlined } from '@ant-design/icons';

export default () => {
  return (
    <Dropdown className="AccountDropdown" overlay={
      <Menu>
        <Menu.Item icon={<LogoutOutlined />}>
          Çıkış Yap
        </Menu.Item>
      </Menu>
    }>
      <Button className="AccountButton" type="link">
        Test User
      </Button>
    </Dropdown>
  );
};