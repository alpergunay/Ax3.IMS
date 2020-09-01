import React from 'react';
import { Menu } from 'antd';
import route from 'plugins/routes/dashboard';
import menuItem from './menuItem';
import subMenu from './subMenu';

export default ({ collapsed }) => {
  let str = '';
  const { pathname } = window.location, keywords = pathname.split('/');
  const mode = 'inline';
  const defaultSelectedKeys = [pathname];
  const defaultOpenKeys = keywords.slice(1, keywords.length - 1).map(x => {
    str += `/${x}`;
    return str;
  });

  return (
    <>
      <div className={`Logo ${collapsed ? 'Collapsed' : ''}`}>
        <img src={`/static/img/${collapsed ? 'icon' : 'logo'}.svg`} alt="Paket Taxi" />
      </div>
      <Menu {...{ defaultOpenKeys, defaultSelectedKeys, mode }}>
        {route.routes.filter(x => x.menu !== false).map(x => (
          x.routes ?
            subMenu('', x.path, x)
            :
            menuItem('', '', x)
        ))}
      </Menu>
    </>
  );
};