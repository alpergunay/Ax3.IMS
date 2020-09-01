import { initReactI18next } from 'react-i18next';
import i18n from 'i18next';
import resources from './locales';

const fallbackLng = 'en';
const defaultNS = 'common';
const lng = localStorage.getItem('lang') || fallbackLng;

i18n.use(initReactI18next).init({ lng, fallbackLng, resources, defaultNS });