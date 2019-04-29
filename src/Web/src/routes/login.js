import CustomerSignIn from '../views/SignIn/CustomerSignIn';
import MerchantSignIn from '../views/SignIn/MerchantSignIn';
import ManagerSignIn from '../views/SignIn/ManagerSignIn';

export default [{
  path: '/',
  redirect: '/Customer/SignIn'
}, {
  path: "/Customer/SignIn", name: 'clogin', component: CustomerSignIn
}, {
  path: "/Merchant/SignIn", component: MerchantSignIn
}, {
  path: "/Manager/SignIn", component: ManagerSignIn
}]