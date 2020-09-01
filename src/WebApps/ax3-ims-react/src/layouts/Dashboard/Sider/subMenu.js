import React from 'react';
import { Menu } from 'antd';
import menuItem from './menuItem';
import subMenu from './subMenu';
import { useTranslation } from 'react-i18next';

export default (name = '', path = '', item) => {
  const { t } = useTranslation(['routes']);

  return (
    <Menu.SubMenu key={path} title={t(`${name}${item.name}.title`)} icon={item.icon ? <item.icon /> : null}>
      {item.routes.filter(x => x.menu !== false).map(x => (
        x.routes ?
          subMenu(`${name}${item.name}.`, `${path}${x.path}`, x)
          :
          menuItem(`${name}${item.name}.`, `${path}`, x)
      ))}
    </Menu.SubMenu>
  );
};