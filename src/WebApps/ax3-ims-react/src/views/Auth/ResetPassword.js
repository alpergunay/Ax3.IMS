import React from 'react';
import { Form, Input, Button } from 'antd';
import { useTranslation } from 'react-i18next';
import { resetPassword } from 'store/requests/auth';

export default () => {
  const [form] = Form.useForm();
  const { t } = useTranslation(['common', 'auth']);

  const onFinish = (values) => {
    resetPassword(values).then(() => {
      
    });
  };

  return (
    <Form layout="vertical" form={form} onFinish={onFinish}>
      <Form.Item label={t('password')} name="password" rules={[{ required: true }]}>
        <Input placeholder={t('password')} />
      </Form.Item>
      <Form.Item label={t('confirmPassword')} name="confirm" rules={[{ required: true }]}>
        <Input placeholder={t('confirmPassword')} />
      </Form.Item>
      <Form.Item>
        <Button block type="primary" htmlType="submit">
          {t('auth:updatePassword')}
        </Button>
      </Form.Item>
    </Form>
  )
};