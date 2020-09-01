import React, { useEffect } from 'react';
import { useTranslation } from 'react-i18next';
import { ConfigProvider } from 'antd';
import moment from 'moment';
import en from 'antd/es/locale/en_US';
import tr from 'antd/es/locale/tr_TR';
import eventBus from 'plugins/eventBus';

export default ({ children }) => {
  const { i18n } = useTranslation();
  const locales = { en, tr };

  useEffect(() => {
    const changeLanguage = (lang) => {
      i18n.changeLanguage(lang);
      moment.locale(lang);
      localStorage.setItem('lang', lang);
    };

    eventBus.$on('changeLanguage', changeLanguage);
  }, [i18n]);

  return (
    <ConfigProvider locale={locales[i18n.language]}>
      {children}
    </ConfigProvider>
  );
};