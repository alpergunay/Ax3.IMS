import React from 'react';
import { Form, Input, Button } from 'antd';
import { useTranslation } from 'react-i18next';
import { login } from 'store/requests/auth';
import { Link } from 'react-router-dom';
import { useSelector } from 'react-redux';

export default ({ history }) => {
  const [form] = Form.useForm();
  const { t } = useTranslation(['common', 'auth']);
  const { loading, error } = useSelector(state => state.auth.login);

  const onFinish = (values) => {
    login(values).then(() => {
      history.push('/home');
    });
  };

  return (
    <Form layout="vertical" form={form} onFinish={onFinish}>
      <Form.Item label={t('email')} name="email" rules={[{ required: true }, { type: 'email' }]}>
        <Input placeholder={t('email')} />
      </Form.Item>
      <Form.Item label={t('password')} name="password" rules={[{ required: true }]}>
        <Input.Password placeholder={t('password')} />
      </Form.Item>
      {error &&
        <div className="text-center text-red mb-20">
          Kullanıcı adı veya parola hatalı
        </div>
      }
      <Form.Item>
        <Button block type="primary" htmlType="submit" loading={loading}>
          {t('auth:login')}
        </Button>
      </Form.Item>
      <div className="text-center">
        <Link to="/register">
          {t('auth:register')}
        </Link>
      </div>
    </Form>
  )
};