import CustomerSignIn from '../views/SignIn/CustomerSignIn';
import MerchantSignIn from '../views/SignIn/MerchantSignIn';

export default [{
  path: '/',
  redirect: '/Customer/SignIn'
}, {
  path: "/Customer/SignIn", name: 'clogin', component: CustomerSignIn
}, {
  path: "/Merchant/SignIn", component: MerchantSignIn
}]