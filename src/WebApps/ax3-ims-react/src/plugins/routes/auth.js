export default {
  name: 'auth',
  component: require('layouts/Auth').default,
  routes: [
    {
      path: '/login',
      component: require('views/Auth/Login').default,
    },
    {
      path: '/register',
      component: require('views/Auth/Register').default,
    },
    {
      path: '/forgot-password',
      component: require('views/Auth/ForgotPassword').default,
    },
    {
      path: '/reset-password',
      component: require('views/Auth/ResetPassword').default,
    }
  ]
}